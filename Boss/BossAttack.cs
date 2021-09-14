using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public BossFight boss;
    public Collider2D collider;
    public SoundManager audio;
    public float attackdelay = 1.5f;
    public float TimeAttack=0;

    // Start is called before the first frame update
    void Start()
    {
        boss = GetComponent<BossFight>();
        audio = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundManager>();
        collider = GameObject.Find("AttackRange").GetComponent<Collider2D>();
        collider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (boss.attacking&&Time.time>TimeAttack+attackdelay)
        {
            collider.enabled = true;
            audio.PlaySound("attack");
            TimeAttack = Time.time;
        }
        else
        {
            boss.attacking = false;
            collider.enabled = false;
        }
    }
}
