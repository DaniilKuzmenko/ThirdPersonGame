using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transform_position : MonoBehaviour
{
[SerializeField]
private Rigidbody rb;
private Vector3 moveDir;
private CharacterController controller;

private const float SPEED = 4f;
private float moveX, moveY, moveZ;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //MovingWithTransformPosition();
        MovingWithTransformTranslate();
    }

    private void MovingWithTransformPosition()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.01f);
        }
    }

    private void MovingWithTransformTranslate()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.fixedDeltaTime);
        }
    }

    private void MovingWithVelocity() 
    {
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(moveX, moveY, moveZ);
    }
    private void MovingWithCharController()
    {
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");
        if(controller.isGrounded)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                moveY = 0.15f;
            }
            else 
            {
                moveY = 0f;
            }
        }
        else
        {
            moveY -= 1f * Time.fixedDeltaTime;
        }
        moveDir = new Vector3(moveX * Time.fixedDeltaTime, moveZ * Time.fixedDeltaTime);
        controller.Move(moveDir * SPEED);
    }
    
}
