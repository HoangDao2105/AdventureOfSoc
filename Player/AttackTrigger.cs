using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    public int damaged = 20;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.isTrigger != true && collider.CompareTag("Enemy"))
        {
            collider.SendMessageUpwards("Damage", damaged);
        }
    }
    
}
