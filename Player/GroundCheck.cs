using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public Player player;
    public PlatMoving pm;
    public Vector3 movep;
    // Start is called before the first frame update
    void Start()
    {
        pm = GameObject.FindGameObjectWithTag("movingplat").GetComponent<PlatMoving>();
        player = gameObject.GetComponentInParent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixUpdate()
    {

    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.isTrigger != true)
        {
            player.grounded = true;
        }
        
    }
    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.isTrigger != true || collider.CompareTag("water"))
            player.grounded = true;
        if (collider.isTrigger != true && collider.CompareTag("movingplat"))
        {
            movep = player.transform.position;
            movep.x+= pm.speed*Time.deltaTime;
            player.transform.position = movep;
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.isTrigger != true || collider.CompareTag("water")) 
            player.grounded = false;
    }
}
