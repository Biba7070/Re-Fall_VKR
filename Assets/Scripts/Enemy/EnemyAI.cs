 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    //Enemy
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask itIsPlayer;
    Animator animator;
    //For Walk

    public Vector3 walkPoint;

    //For attacks
    public float timeBetweenAttacks;
    bool hasAlreadyAttacked;

    //States
    public float sightRange, attackRange; //sightRange - расстояние, на котором враг замечает игрока,  attackRange - расстояние, на котором враг начинает атаковать
    public bool playerInSightRange, playerInAttackRange; //playerInSightRange - игрок находится в зоне обнаружения врагом, playerInAttackRange - в зоне начала аттаки врага

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, itIsPlayer); //Будет пытаться найти объект в заданной области с меткой itIsPlayer
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, itIsPlayer);

        if (playerInSightRange && !playerInAttackRange)
        {
            Chase(); // Если игрок не находится в зоне атаки, но находится в зоне обнаружения, то враг будет преследовать игрока
        }

        if (playerInAttackRange)
        {
            Attack();
        }
    }

    private void Chase()
    {
        agent.SetDestination(player.position);
        animator.SetBool("Attacking", false);
        animator.SetBool("isWalking", true);
    }

    private void Attack()
    {
        animator.SetBool("isWalking", false);
        agent.SetDestination(transform.position);
        transform.LookAt(player);
       animator.SetBool("Attacking", true);
        if (!hasAlreadyAttacked)
        {
            hasAlreadyAttacked = true;
            animator.SetBool("Attacking", false);
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        hasAlreadyAttacked = false;
    }
    

}
