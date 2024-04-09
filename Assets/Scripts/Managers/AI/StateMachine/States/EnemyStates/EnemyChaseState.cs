using UnityEngine;
using UnityEngine.AI;

internal class EnemyChaseState : EnemyBaseState
{
    private NavMeshAgent _agent;
    private Transform _player;
    private Animator _animator;
    public EnemyChaseState(Enemy enemy, Animator animator, NavMeshAgent agent, Transform player) : base(enemy, animator)
    {
        _agent = agent;
        _player = player;
        _animator = animator;
    }
    public override void OnEnter()
    {
        Debug.Log("Entered Chase State");
        //_animator.SetBool("IsMoving", true);
        //set animation
        //set sound
        //Debug.Log("Started Chase");

    }

    public override void Update()
    {
        _animator.SetTrigger(WalkHash);
        _agent.SetDestination(_player.position);
    }
}