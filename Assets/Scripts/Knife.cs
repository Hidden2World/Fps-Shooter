using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Knife : MonoBehaviour
{
       public int damage = 10;

       public int currentHealth;
       public int maxHealth = 15;
     void OnCollisionEnter(Collision collision)
     {
        currentHealth = maxHealth;

        Debug.Log("Collision with: " + collision.gameObject.name); // Debug log to check what the knife is colliding with.
         if (collision.gameObject.CompareTag("Enemy"))
         {
             Enemy enemy = collision.gameObject.GetComponent<Enemy>();
             if (enemy != null)
             {
                 enemy.TakeDamage(damage);
                //Debug.Log("Enemy hit. Current Health: " + enemy.currentHealth());
             }
         }
        // Destroy the knife on impact with anything.
        Destroy(gameObject);
     }
    
 

}
