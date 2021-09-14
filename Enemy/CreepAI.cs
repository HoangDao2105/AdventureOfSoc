using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepAI : MonoBehaviour
{
    public int creepHealth = 120;
    public float distance;
    public float wakerange;
    public float shootinterval;
    public float speedbullet=5;
    public float shootindelay;
    public bool awake=false;
    public bool lookRight = true;
    public GameObject bullet;
    public Transform Target;
    public Animator anmt;
    public Transform shootPointL, shootPointR;
    public SoundManager audio;
    // Start is called before the first frame update
    private void Awake()
    {
        anmt = gameObject.GetComponent<Animator>();
        audio = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundManager>();
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        anmt.SetBool("Awake", awake);
        anmt.SetBool("LookRight", lookRight);
        RangeCheck(); 
        if (Target.transform.position.x > this.transform.position.x)
        {
            lookRight = true;
        }
        else
        {
            lookRight = false;
        }
        if (creepHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    void RangeCheck()
    {
        distance = Vector2.Distance(transform.position, Target.transform.position);
        if (distance < wakerange)
            awake = true;
        else
        {
            awake = false;
            
        }
    }
    public void Shootin(bool attackRight)
    {
        shootindelay += Time.deltaTime;
        if (shootindelay >= shootinterval)
        {
            Vector2 bulletdirect = Target.transform.position - transform.position;
            bulletdirect.Normalize();
            if (attackRight)
            {
                GameObject bulletClone;
                bulletClone = Instantiate(bullet, shootPointR.transform.position, shootPointR.transform.rotation) as GameObject;
                bulletClone.GetComponent<Rigidbody2D>().velocity = bulletdirect * speedbullet;
                shootindelay = 0;
            }
            if (!attackRight)
            {
                GameObject bulletClone;
                bulletClone = Instantiate(bullet, shootPointL.transform.position, shootPointL.transform.rotation) as GameObject;
                bulletClone.GetComponent<Rigidbody2D>().velocity = bulletdirect * speedbullet;
                shootindelay = 0;
            }
        }
    }
    public void Damage(int dame)
    {
        creepHealth -= dame;
        audio.PlaySound("destroy");
        gameObject.GetComponent<Animation>().Play("redflash");
    }
}
