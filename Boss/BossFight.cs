using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFight : MonoBehaviour
{
    public Animator anmt;
    public Rigidbody2D rb;
    public int damaged = 1;
    public float speed = 3f;
    public int health = 300;
    public SoundManager audio;
    public float wakeRange = 8;
    public Transform Target;
    public bool attacking;
    bool awake;
    public bool Range;
    bool face = true;
    float distance;
    public float RangeAttack = 1f;
    public GameObject treasure;
    // Start is called before the first frame update
    void Start()
    {
        Range = false;
        awake = false;
        attacking = false;
        anmt = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        treasure.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        anmt.SetBool("Awake", awake);
        anmt.SetBool("isAttack", attacking);
        anmt.SetFloat("Speed", speed);
        anmt.SetBool("Range", Range);
        RangeCheck();
        if (awake)
        {
            Vector2 target = new Vector2(Target.position.x, Target.position.y);
            Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
            rb.MovePosition(newPos);
        }
        if(Vector2.Distance(transform.position, Target.transform.position) <= RangeAttack)
        {
            attacking = true;
        }
        else
        {
            attacking = false;
        }

        if (Target.position.x > transform.position.x && !face)
            Flip();
        if (Target.position.x<transform.position.x && face)
            Flip();
        if (health <= 100)
        {
            Range = true;
        }
        if (Range)
        {
            speed = 6f;
        }
        if (health <= 0)
        {
            treasure.SetActive(false);
            Destroy(gameObject, 1f);
        }
    }
    void Flip()
    {
        face = !face;
        Vector3 scale;
        scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    void RangeCheck()
    {
        distance = Vector2.Distance(transform.position, Target.transform.position);
        if (distance < wakeRange)
            awake = true;

    }
    public void Damage(int dame)
    {
        health -= dame;
        gameObject.GetComponent<Animation>().Play("redflash");
    }
}
