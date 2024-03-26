using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    private bool hitsomething;
    public GameObject ImpactVFX;
    [SerializeField] private bool isTrigger;
    private void OnCollisionEnter(Collision collision)
    {
        if(!isTrigger)
        if(collision.gameObject.tag != "Spell" && collision.gameObject.tag != "Player" && !hitsomething)
        {
            hitsomething= true;

            var impact = Instantiate(ImpactVFX, collision.contacts[0].point, Quaternion.identity) as GameObject;

            Destroy(impact, 0.25f);
            Destroy (gameObject);
        }
    }

}
