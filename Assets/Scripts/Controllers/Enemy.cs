using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour,IPoolable
{

    [SerializeField] PlayerDetector _playerDetector;
    [SerializeField] NavMeshAgent _agent;
    [SerializeField] Animator _animator;
    [SerializeField] GameObject _attackVFX;
    [SerializeField] Transform[] _patrolPoints;
    StateMachine _stateMachine;
    public bool IsAttacking;

    public ObjectPool Parent { get; set; }

    public GameObject GameObject => gameObject;

    void Start()
    {
        //set state machine
        _stateMachine = new StateMachine();

        //set states of enemy
        IState wanderState = new EnemyPatrolState(this, _animator, _agent, _patrolPoints);
        IState chaseState = new EnemyChaseState(this, _animator, _agent, _playerDetector.Player);
        IState attackState = new EnemyAttackState(this, _animator, _attackVFX, _agent, _playerDetector.Player/*, timeBetweenAttacks*/);
        //set states transitions
        At(wanderState, chaseState, () => _playerDetector.CanDetectPlayer());//if agent sees player, from wandering agent will chase the player.
        At(chaseState, wanderState, () => !_playerDetector.CanDetectPlayer());//if player got away from chasing radius, the agent will go back to wandering
        At(chaseState, attackState, () => _playerDetector.CanAttackPlayer());//if chasing player and in attack radius, agent will attack player 
        At(attackState, chaseState, () => !_playerDetector.CanAttackPlayer()  && !IsAttacking);//if player got away from attacking radius, and not in mid attacking, agent will chase the player
        _stateMachine.SetState(wanderState);
    }
    
    void At(IState from, IState to, Func<bool> condition) => _stateMachine.AddTransition(from, to, condition);

    void Update()
    {
        _stateMachine. Update();
    }

    public void Attack()
    {
        Debug.Log("attacked player");
    }
    public void OnDeath()
    {
        Debug.Log("enemy died");
    }

    public void SetAgentPatrolPoints(Transform[] patrolPoints)
    {
        _patrolPoints = patrolPoints;
    }
}
