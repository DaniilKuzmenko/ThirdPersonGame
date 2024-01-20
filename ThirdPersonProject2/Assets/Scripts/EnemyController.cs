using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private int health = 3;
    private float prewHitTime, ignoreDamageWindow = 1.5f;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Transform playerT;
    private float prevAttackTime, pauseAttackWindow = 2.5f;
    [SerializeField]
    private Transform[] patrolTargets;
    private int currentTargetIndex = 0;
    public bool isAttacked = false;
    

    void Start()
    {
        prewHitTime = 0f;
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider col){
    if(col.gameObject.tag == "Weapon" && Time.time > prewHitTime * ignoreDamageWindow){
        health--;
        prewHitTime = Time.time;
        if(health > 1){
            animator.Play("KnockdownRight");
        } else if (health == 1){
            animator.SetTrigger("isDead");
        }
    }
   }

   private void Update(){
    isAttacking = animator.GetCurrentAnimatorStateInfo(0).IsName("Sword_Attack_R");
    if (health > 1){
        if (distanceToPlayer < 2.5f){
            //attack
        } else if (distanceToPlayer > 30f){
            //patrol
        } else {
            //moveToPlayer
        }
    }
   }
   private void moveToPlayer(){
    animator.SetBool("isWalk", true);
    agent.destination = playerT.positionl
   }
   private void Attack(){
    animator. SetBool("isWalk", false);
    agent.destination = transform.position;
    transform.LookAt(playerT.position);
    if (Time.time > prevAttackTime + pauseAttackWindow && !animator.GetCurrentAnimatorStateInfo(0).IsName("KnockdownRight"))
    {
        animatorPlay("Sword_Attack_R");
        prevAttackTime = Time.time;
    }
    }
    private void PatrolBehaviour () {

    if (patrolTargets.Length > 0)

    animator.SetBool ("isWalk", true); //


    agent.destination:
    patrolTargets[currentTargetIndex].position;
    CheckNewPatrolTarget();
}
    private void CheckNewPatrolTarget(){
        
    }
}

   
