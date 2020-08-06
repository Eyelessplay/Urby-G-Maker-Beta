using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMovement2D : MonoBehaviour
{
    public float speed;
    public float restrainer;
    public float jumpForce;
    int direction;
    public bool damaged;
    public bool canJump;
    public GameObject spawn;
    Rigidbody rb;
    //SpriteRenderer sprite;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        direction = 1;
        damaged = false;
        //sprite = gameObject.GetComponent<SpriteRenderer>();
    }


    void FixedUpdate()
    {
        if (damaged == false)
        {
            rb.velocity = new Vector3((speed + (Input.GetAxis("Horizontal") * restrainer)) * direction, rb.velocity.y, 0f);
            if (Input.GetKeyDown(KeyCode.Space) && (canJump = true))
            {
                rb.AddForce(new Vector3(0, jumpForce, 0));
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Ground")
        {
            direction = direction * -1;
        }

        else if (collision.gameObject.tag == "Ground")
            canJump = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.tag == "trigger")
        //{
        //    other.gameObject.GetComponent<SwitchController>().ActiveSwitch();
        //}

    }
    public void respawn()
    {
        if (damaged == true)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                transform.position = spawn.transform.position;
            }
        }
    }
}
