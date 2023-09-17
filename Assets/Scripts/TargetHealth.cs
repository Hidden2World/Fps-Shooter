using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Health
{


    public class TargetHealth : MonoBehaviour
    {
        public int maxHealth;

        

        private int currentHealth;
        

        public GameObject deadexplosionPrefab;




        // Start is called before the first frame update
        void Start()
        {
            currentHealth = maxHealth;
        }

        private void TargetDestroy()
        {
            gameObject.SetActive(false);
        }

        public void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Projectile"))
            {
                currentHealth -= collision.gameObject.GetComponent<HandleProjectile>().damage;

                if (currentHealth <= 0)
                {
                    
                    
                    TargetDestroy();
                    Dead();
                }
            }

        }

        private void Dead()
        {
            // Instantiate the explosion effect at the projectile's position
            GameObject explosion = Instantiate(deadexplosionPrefab, transform.position, Quaternion.identity);

            // Destroy the explosion effect after its duration 
            Destroy(explosion, explosion.GetComponent<ParticleSystem>().main.duration);
        }

    }
}

