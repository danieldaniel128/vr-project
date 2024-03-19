using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireProjectileOnActivate : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float fireSpeed = 10;

    

    void Start()
    {
        XRGrabInteractable grabable= GetComponent<XRGrabInteractable>();
        grabable.activated.AddListener(FireBullet);
    }

    public void FireBullet(ActivateEventArgs arg)
    {
        GameObject spawnedBullet = Instantiate(bullet , spawnPoint.position, spawnPoint.rotation);
        spawnedBullet.GetComponent<Rigidbody>().velocity = spawnedBullet.transform.forward * fireSpeed;
        Destroy(spawnedBullet, 5);
    }
}
