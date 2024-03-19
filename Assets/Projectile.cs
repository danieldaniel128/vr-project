using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour, IPoolable
{
    public ObjectPool Parent { get; set; }
    public GameObject GameObject => gameObject;
    [SerializeField] float damage;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.rigidbody.GetComponent<Health>()!=null)
        collision.rigidbody.GetComponent<Health>().TakeDamage(damage);
    }
}
