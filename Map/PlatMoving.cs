using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatMoving : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 5f, changeDirection = -1;
    Vector3 move;
    public PausedUI paused;
    // Start is called before the first frame update
    void Start()
    {
        move = this.transform.position;
        paused = GameObject.FindGameObjectWithTag("MainCamera").GetComponentInParent<PausedUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (paused.paused)
            this.transform.position = this.transform.position;
        if(paused.paused==false)
        {
            move.x+= speed*Time.deltaTime;
            this.transform.position = move;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            speed *= changeDirection;
        }
    }
}
