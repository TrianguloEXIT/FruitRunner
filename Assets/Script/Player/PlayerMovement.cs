using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;
    private Rigidbody2D Rig;
    public float Jumpforce;
    public bool IsJumping, doubleJump;
    private Animator anim;

    private void Start()
    {
        Rig=GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        Move();
        Jump();

    }


    void Move()
    {
        if (Input.GetAxis("Horizontal")>0f)
        {
            anim.SetBool("Run", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        if (Input.GetAxis("Horizontal") < 0f)
        {
            anim.SetBool("Run", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);

        }
        if (Input.GetAxis("Horizontal") == 0f)
        {
            anim.SetBool("Run", false);
        }
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f,0f);
        transform.position += movement * Time.deltaTime * Speed;
       

    }

    void Jump()
    {
        if(IsJumping==false)
        {

            if (Input.GetButtonDown("Jump"))
            {
                Rig.AddForce(new Vector2(0f, Jumpforce), ForceMode2D.Impulse);
                doubleJump = true;
                anim.SetBool("Jump", true);

            }


        }
        else
        {
            if (doubleJump == true)
            {

                if (Input.GetButtonDown("Jump"))
                {
                    Rig.AddForce(new Vector2(0f, Jumpforce), ForceMode2D.Impulse);
                    doubleJump = false;
                }
            }


        }



    }
     void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            anim.SetBool("Jump", false);
            IsJumping = false;
        }
    }


     void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3)
        {

            IsJumping = true;
        }

    }

}
