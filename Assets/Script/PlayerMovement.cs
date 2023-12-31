using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody rb;
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] Transform groundCheck;
     [SerializeField] LayerMask ground;
     [SerializeField] AudioSource JumpSound;
    // Start is called before the first frame update
    void Start()
    {
         rb =  GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y,verticalInput*movementSpeed);

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
           Jump();
        }
    
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x,jumpSpeed,rb.velocity.z);
        JumpSound.Play();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Head"))
        {
            Destroy(collision.transform.parent.gameObject);
            Jump();
        }
    }
    bool isGrounded()
    {
        return Physics.CheckSphere(groundCheck.position,.1f, ground);
    }
}
