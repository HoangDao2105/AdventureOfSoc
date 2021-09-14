using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackdelay = 0.3f;
    public bool attacking = false;
    public Animator anmt;
    public Collider2D collider;
    public SoundManager audio;
    private void Awake()
    {
        anmt = gameObject.GetComponent<Animator>();
        audio = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundManager>();
        collider.enabled = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z)&&!attacking)
        {

            attacking = true;
            collider.enabled = true;
            audio.PlaySound("attack");
            attackdelay = 0.3f;
        }
        if (attacking)
        {
            if (attackdelay > 0)
            {
                attackdelay -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                collider.enabled = false;
            }
        }
        anmt.SetBool("Attacking", attacking);
    }
}
