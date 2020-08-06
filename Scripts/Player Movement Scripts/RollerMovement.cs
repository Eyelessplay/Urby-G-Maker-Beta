using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerMovement : MonoBehaviour
{
    public float speed = 10f;
    public float jumpforce;
    public bool Canjump;
    bool isGrounded;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        isGrounded = true;
    }
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement);
        if (Canjump)
        {
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
            {
                isGrounded = false;
                Vector3 jump = new Vector3(0f, jumpforce, 0f);
                rb.AddForce(jump);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
