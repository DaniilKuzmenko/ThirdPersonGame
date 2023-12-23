using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerailizeField]
    private Rigidbody rb;
    [SerializeField]
    private Animator animator;

    private angleY, dizZ, jumpForce = 6f, turnSpeed = 80f;
    private bool isGrounded;
    private Vector3 jumpDir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    
    void FixedUpdate(){
        angleY = Input.GetAxis("MouseX") * Time.fixedDeltaTime * turnSpeed;
        dizZ = Input.GetAxis("Vertical");
        transform.Rotate(new Vector3(0f, angleY, 0f));
    }
    private void Update () {
        if (isGrounded) {
            if (Input.GetKeyDown (KeyCode. Space) ) {
                Jump ();
        } else {
            animator.SetTrigger ("isLanded") ;
        }

        //Move (dirz, "isWalkForward", "isWalkBack") ;
        //Sprint ();
        //Dodge () ;
    } else {
        //MoveInAir ();
}
}
    private void Jump() {

    }
    private void Move() {
        
    }
    private void Sprint() {
        
    }
    private void Dodge() {
        
    }
    private void MoveInAir() {
        
    }
}
