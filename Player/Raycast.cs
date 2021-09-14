using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public float timedelay = 0, damaged = 20;
    public LayerMask whattopoint;
    public Transform firepoint;
    // Start is called before the first frame update
    void Start()
    {
        firepoint = transform.Find("Shootin");
    }

    // Update is called once per frame
    void Update()
    {
        timedelay += Time.deltaTime;
        
        if (timedelay >= 0.5)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                timedelay = 0;
                shoot();
            }
        }
    }
    void shoot()
    {
        Vector2 mousePos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firepointpos = new Vector2(firepoint.position.x, firepoint.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firepointpos, (mousePos - firepointpos), 7, whattopoint);
        if (hit.collider != null)
        {
            Debug.DrawLine(firepointpos, hit.point, Color.red);
            Debug.Log("We hit " + hit.collider.name);
            hit.collider.SendMessageUpwards("Damage", damaged);
        }
    }
}
