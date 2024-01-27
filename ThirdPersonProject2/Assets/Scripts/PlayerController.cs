using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private Animator animator;

    private float angleY, dirZ, jumpForce = 6f, turnSpeed = 80f;
    private bool isGrounded;
    private Vector3 jumpDir;
    
    public GameObject sword;
    private bool isSwordEquiped = false;
    private float lastAttackTime = 0;

    private Vector3 swordStartPos = Vector3.zero;
    private Vector3 swordStartRotation = Vector3.zero;
    [SerializeField]
    private EnemyController enemy;

    private static int a;
    private int b;
    private void Start(){
        swordStartPos = sword.transform.position;
    }

    private void Start()
    {
        swordStartPos = sword.transform.localPosition;
        swordStartPotation = sword.transform.localEulerAngles;
    }

    private void FixedUpdate()
    {
        angleY = Input.GetAxis("Mouse X") * Time.fixedDeltaTime * turnSpeed;
        dirZ = Input.GetAxis("Vertical");
        transform.Rotate(new Vector3(0f, angleY, 0f));
    }

    private void Update()
    {
        isAttacking = animator.GetCurrentANimatorStateInfo(0).IsName("Sword_hit_R");
        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
            else
            {
                animator.SetTrigger("isLanded");
            }
            Move(dirZ, "isWalkForward", "isWalkBack");
            Sprint();
            Dodge();
            EquipSword();
            UnequipSword();
        }
        else
        {
            MoveInAir();
        }

    }

    private void Jump()
    {
        animator.Play("Sword_Jump_Platformer_Start");
        animator.applyRootMotion = false;
        jumpDir = new Vector3(0f, jumpForce, dirZ * jumpForce / 2f);
        jumpDir = transform.TransformDirection(jumpDir);
        rb.AddForce(jumpDir = 50, ForceMode.Impulse);
        isGrounded = false;
    }

    private void Move(float dir, string paramName, string altParamName)
    {
        if(dir > 0)
        {
            animator.SetBool(paramName, true);
        }
        else if (dir < 0)
        {
            animator.SetBool(altParamName, true);
        }
        else
        {
            animator.SetBool(paramName, false);
            animator.SetBool(altParamName, false);
        }

    }

    private void Sprint()
    {
        animator.SetBool("isRun", Input.GetKey(KeyCode.LeftShift));
    }

    private void Dodge()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.Play("Sword_Dodgle_Left");
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            animator.Play("Sword_Dodge_Right");
        }
    }

    private void MoveInAir()
    {
        if(new Vector2(rb.velocity.x, rb.velocity.z).magnitude < 1.1f)
        {
            jumpDir = new Vector3(0f, rb.velocity.y, dirZ);
            jumpDir = transform.TransformDirection(jumpDir);
            rb.velocity = jumpDir;
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        isGrounded = true;
        animator.applyRootMotion = true;
    }

    public void EquipSword () {
        sword.transform.SetParent(GameObject.Find("RightHand").transform);
        if(Input.GetMouseButtonDown(0)) {
            if (!isSwordEquiped) {
                animator.Play ("Equip_Sword") ;
                isSwordEquiped = true;
            } else {
                animator.Play("Sword_Attack_R");
                lastAttackTime = Time.time;
            }
        }
    }

    private void SwordHolster(){
        sword.transform.SetParent(GameObject.Find("Hips").transform);
        swordStartPos = sword.transform.position;
        sword.transform.localEulerAngles = sword.StartRotation;
    }

    private void UnequipSword(){
        if(isSwordEquiped && Time.time > lastAttackTime + 7f){
            animator.Play("Sword_Holster");
            isSwordEquiped = false;
            SwordHolster();
        }
    }

    void Attack () {
        int rand = Random.Range (0, 3);
        switch (rand) {
            case 0:
                animator. Play("Sword_Attack_1");
                break;
            case 1:
                animator. Play ("Sword_Attack_2");
                break;

            case 2:
            animator. Play ("Sword_Attack_3");
                break;
        }
    }
    private void OnTriggerEnter(Collider col){
        if (col.gameObject.tag == "Weapon"  && enemyIsAttacking){
            animator.Play("Sword_Hit_L_2")
        }
    }

}
