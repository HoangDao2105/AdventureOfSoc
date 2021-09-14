using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCone : MonoBehaviour
{
    public CreepAI creep;
    public bool lookRight = true;
    // Start is called before the first frame update
    private void Awake()
    {
        creep = gameObject.GetComponentInParent<CreepAI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            if (lookRight)
            {
                creep.Shootin(true);
            }
            else
            {
                creep.Shootin(false);
            }
        }
    }
}
