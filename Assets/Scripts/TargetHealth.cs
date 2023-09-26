using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace Health
{


    public class TargetHealth : MonoBehaviour
    {

        private HighScores highScores;
        public int maxHealth;

        

        public int currentHealth;
        

        public GameObject deadexplosionPrefab;


        bool enemyDead;

        // Start is called before the first frame update
        void Start()
        {
            currentHealth = maxHealth;
            highScores = (HighScores)FindObjectOfType(typeof(HighScores));
            
        }

        private void TargetDestroy()
        {

            if (!enemyDead ) 
            {
                enemyDead = true;
                highScores.UpdateAndSaveScore(highScores.scores.Length - 1, highScores.scores[highScores.scores.Length - 1] + 1);
                Debug.Log("Enemy destroyed");
                gameObject.SetActive(false);
            }
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

