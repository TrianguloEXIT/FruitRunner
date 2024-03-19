using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flowedplataform : MonoBehaviour
{

    public float waitime;
    private TargetJoint2D Plataform;
    private BoxCollider2D BoxCollider;
    void Start()
    {
        Plataform= GetComponent<TargetJoint2D>();
        BoxCollider = GetComponent<BoxCollider2D>();
    }



    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            Invoke("Falling", waitime);
        }
        
    }
    void Falling()
    {

        Plataform.enabled = false;
        BoxCollider.isTrigger = true;

    }

   
}
