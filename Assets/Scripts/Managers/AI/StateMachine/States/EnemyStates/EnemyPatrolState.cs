using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrolState : EnemyBaseState
{
    private NavMeshAgent _agent;
    private Transform[] _patrolPoints;
    private int _currentPatrolPoint = 0;
    private Animator _animator;

    private readonly int MoveID = Animator.StringToHash("IsMoving");
    public EnemyPatrolState(Enemy enemy, Animator animator, NavMeshAgent agent, Transform[] patrolPoints) : base(enemy, animator)
    {
        _agent = agent;
        _animator = animator;
        _patrolPoints = patrolPoints;
    }

    public override void OnEnter()
    {
        Debug.Log("Entered Patrol State");
    }


    public override void Update()
    {
        _animator.SetBool(WalkHash, true);
        SetDestinationPoint();
    }
    public override void OnExit()
    {
        _agent.isStopped = false;
        _animator.SetBool(WalkHash, false);
    }

    void SetDestinationPoint()
    {
        //check if the agent reach its final destination/objective.
        if(!HasReachedObjective())
            // Check if the agent has reached its destination
            if (HasReachedDestination())
            {
                _agent.SetDestination(_patrolPoints[_currentPatrolPoint].position);
                _currentPatrolPoint++;
            }
    }
    bool HasReachedDestination()
    {
        return !_agent.pathPending
               && _agent.remainingDistance <= _agent.stoppingDistance
               && (!_agent.hasPath);
    }
    bool HasReachedObjective()
    {
        return _currentPatrolPoint == _patrolPoints.Length;
    }
}