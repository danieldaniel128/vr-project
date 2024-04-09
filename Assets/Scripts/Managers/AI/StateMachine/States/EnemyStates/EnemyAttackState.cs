using UnityEngine;
using UnityEngine.AI;

public class EnemyAttackState : EnemyBaseState
{
    private NavMeshAgent _agent;
    private Transform _player;
    private GameObject _vfx;
    private readonly int AttackID = Animator.StringToHash("IsAttacking");
    public EnemyAttackState(Enemy enemy, Animator animator, GameObject vfx, NavMeshAgent agent, Transform player) : base(enemy, animator)
    {
        _agent = agent;
        _player = player;
        _vfx = vfx;
    }

    public override void OnEnter()
    {
        //animator.SetBool(AttackID, false);
        Debug.Log("Entered Attack State");

    }

    public override void Update()
    {
        float distance = Vector3.Distance(_player.position, enemy.transform.position);

        if (distance <= 0.2f)
        {
            animator.SetBool(AttackHash, true);
        }
        else
        {
            OnExit();
        }
    }
    public override void OnExit()
    {
        animator.SetBool(AttackHash, false);
    }
}