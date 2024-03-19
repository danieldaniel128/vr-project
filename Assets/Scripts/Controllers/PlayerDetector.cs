using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    [SerializeField] float detectionRadius = 10f; // Large circle around enemy
    [SerializeField] float detectionCooldown = 1f; // Time between detections
    [SerializeField] float attackRange = 2f; // Distance from enemy to player to attack

    public Transform Player => GameManager.Instance.Player.transform;
    float _detectionTimer;


    private void Update()
    {
        _detectionTimer += Time.deltaTime;
        if(_detectionTimer >= detectionCooldown)
        {
            _detectionTimer = 0;
            //logic?
        }
    }

    public bool CanDetectPlayer()
    {
        return DetectPlayer();
    }

    public bool CanAttackPlayer()
    {
        if (Vector3.Distance(Player.position, transform.position) < attackRange)
            return true;
        return false;
    }
    public bool DetectPlayer()
    {
        if (Vector3.Distance(Player.position, transform.position) < detectionRadius)
            return true;
        return false;
    }

}