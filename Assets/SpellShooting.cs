using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellShooting : MonoBehaviour
{
    [SerializeField] Transform _spellSpawnPoint;
    public GameObject spellProjectile;
    public float projectileSpeed = 30f;
    public float fireRate = 4f;
    private float nextFireTime = 0f;

    // Update is called once per frame
    void Update()
    {
        // Check if Fire1 button is pressed and enough time has passed since the last fire
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + 1f / fireRate; // Calculate next fire time based on fire rate
            ShootSpell();
        }
    }

    void ShootSpell()
    {
        // Instantiate the spell projectile at the appropriate fire point
        Instantiate(spellProjectile, _spellSpawnPoint.position, Quaternion.identity).GetComponent<Rigidbody>().velocity = _spellSpawnPoint.forward.normalized * projectileSpeed;
    }

}
