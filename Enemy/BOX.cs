using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOX : MonoBehaviour
{
    public Animator anmt;
    public int health = 100;
    public SoundManager audio;
    // Start is called before the first frame update
    void Start()
    {
        anmt = gameObject.GetComponent<Animator>();
        audio = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void Damage(int dame)
    {
        health -= dame;
        audio.PlaySound("destroy");
        gameObject.GetComponent<Animation>().Play("redflash");
    }
}
