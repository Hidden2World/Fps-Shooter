using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleProjectile : MonoBehaviour
{

    public float projectileLife;
    private float timer;


    public GameObject explosionPrefab;
    



    public int damage;


    // Start is called before the first frame update
    void Start()
    {
        timer = 0;


    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= projectileLife)
        {
            

            Destroy(gameObject);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody targetRigidbody = collision.gameObject.GetComponent<Rigidbody>();
        PlayExplosionEffect();
        if (targetRigidbody != null)
        {
            
            Destroy(gameObject);
        }
    }

    private void PlayExplosionEffect()
    {
        // Instantiate the explosion effect at the projectile's position
        GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        // Destroy the explosion effect after its duration 
        Destroy(explosion, explosion.GetComponent<ParticleSystem>().main.duration);
    }

    
}
