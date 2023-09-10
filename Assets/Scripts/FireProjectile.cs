using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;




public class FireProjectile : MonoBehaviour
{
    public GameObject projectile;
    public Transform spawnTransform;
    public float force;

    private StarterAssetsInputs inputs;




    void Start()
    {
        inputs = GetComponent<StarterAssetsInputs>();
    }


    void Update()
    {
        if(inputs.fire)
        {
            GameObject temp = Instantiate(projectile, spawnTransform.position, spawnTransform.rotation);
            temp.GetComponent<Rigidbody>().AddForce(temp.transform.forward * force);
            inputs.fire = false;
        }
    }
}
