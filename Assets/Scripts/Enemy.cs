
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent navMeshAgent;
    public float rotationSpeed = 15f;

    public int GetCurrentHealth = 50;
    private HighScores highScores;
    bool enemyDead;

    private void Start()
    {
        highScores = (HighScores)FindObjectOfType(typeof(HighScores));
        // Get a reference to the NavMeshAgent component on the enemy
        navMeshAgent = GetComponent<NavMeshAgent>();

        if (player == null)
        {
            // Find the player's GameObject by tag if not assigned in the Inspector
            player = GameObject.FindGameObjectWithTag("Player").transform;

            if (player == null)
            {
                Debug.LogError("Player not found! Make sure the player has the 'Player' tag.");
            }
        }
    }

    private void Update()
    {
        if (player != null)
        {
            // Move the enemy towards the player's position
            navMeshAgent.SetDestination(player.position);

            // Optionally, you can make the enemy rotate to face the player
            RotateTowardsPlayer();
        }
    }

    private void RotateTowardsPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }






    public void TakeDamage(int damage)
    {
        GetCurrentHealth -= damage;
        if (GetCurrentHealth <= 0)
        {

            if (!enemyDead)
            {

                enemyDead = true;
                highScores.UpdateAndSaveScore(highScores.scores.Length - 1, highScores.scores[highScores.scores.Length - 1] + 1);
                Debug.Log("Enemy destroyed");
                gameObject.SetActive(false);
            }
       
        }
        
    }

}
    

