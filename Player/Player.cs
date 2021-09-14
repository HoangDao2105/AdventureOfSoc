using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public float speed = 40f, maxspeed = 3,maxhigh=4, jumpPow = 500f;
    public Rigidbody2D rig2d;
    public bool grounded = true, face = true, doublejump = false;
    public Animator anmt;
    public int PlayerHealth;
    public int MaxHealth = 5;
    public gamemaster gm;
    public SoundManager audio;
    // Start is called before the first frame update
    void Start()
    {
        rig2d = gameObject.GetComponent<Rigidbody2D>();
        anmt = gameObject.GetComponent<Animator>();
        PlayerHealth = MaxHealth;
        gm = GameObject.FindGameObjectWithTag("Gamemaster").GetComponent<gamemaster>();
        audio = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        anmt.SetBool("grounded",grounded );
        anmt.SetFloat("Speed", Mathf.Abs(rig2d.velocity.x));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)
            {
                grounded = false;
                doublejump = true;
                rig2d.AddForce((Vector2.up) * jumpPow);
                
            }
            else if (doublejump)
            {
                doublejump = false;
                rig2d.velocity = new Vector2(rig2d.velocity.x, 0);
                rig2d.AddForce((Vector2.up) * jumpPow*0.8f);
            }
            
        }
    }

    void FixedUpdate()
    {
        //Di chuyển qua lại và giới hạn vận tốc
        float h = Input.GetAxis("Horizontal");
        rig2d.AddForce((Vector2.right) * speed * h);
        if (rig2d.velocity.x > maxspeed)
            rig2d.velocity = new Vector2(maxspeed, rig2d.velocity.y);
        if (rig2d.velocity.x < -maxspeed)
            rig2d.velocity = new Vector2(-maxspeed, rig2d.velocity.y);
        if (rig2d.velocity.y > maxhigh)
            rig2d.velocity = new Vector2(rig2d.velocity.x, maxhigh);
        if (rig2d.velocity.y < -maxhigh)
            rig2d.velocity = new Vector2(rig2d.velocity.x, -maxhigh);
        // Rơi xuống nhanh hơn
        if (rig2d.velocity.y < 0)
        {
            rig2d.velocity += Vector2.up * Physics2D.gravity.y * Time.deltaTime;
        }

        if (h > 0 && !face)
            Flip();
        if (h < 0 && face)
            Flip();
        if (grounded)
            rig2d.velocity = new Vector2(rig2d.velocity.x * 0.7f, rig2d.velocity.y);
        if (PlayerHealth <= 0)
            Death();
    }
    public void Flip()
    {
        face = !face;
        Vector3 scale;
        scale = transform.localScale;
        scale.x*= -1;
        transform.localScale = scale;
    }
    public void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        if (PlayerPrefs.GetInt("highScore") < gm.point)
        {
            PlayerPrefs.SetInt("highScore", gm.point);
        }
    }
    public void GetDamage(int damage)
    {
        PlayerHealth -= damage;
        gameObject.GetComponent<Animation>().Play("redflash");
    }
    public void KnockBack(float knockpow,Vector2 knockdir)
    {
        rig2d.velocity = new Vector2(0, 0);
        rig2d.AddForce(new Vector2(knockdir.x * -300, knockdir.y * knockpow));
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Coin"))
        {
            audio.PlaySound("collect");
            Destroy(collider.gameObject);
            gm.point++;
        }
        else if (collider.CompareTag("health"))
        {
            audio.PlaySound("collect");
            Destroy(collider.gameObject);
            PlayerHealth = 5;
        }
        else if (collider.CompareTag("speed"))
        {
            audio.PlaySound("collect");
            Destroy(collider.gameObject);
            speed = 120f;
            maxspeed = 10f;
            StartCoroutine(timecount(4));
        }
    }
    IEnumerator timecount(float time)
    {
        yield return new WaitForSeconds(time);
        maxspeed = 5f;
        speed = 70f;
        yield return 0;
    }
}
