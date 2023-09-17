using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public float fireRate = 0.0f;
    public GameObject projectilePrefab;
    public Transform firePoint;
    public string playerTag = "Player";
    public float projectileSpeed = 10.0f;


    private float nextFireTime = 0.0f;
    private Transform player;
    private bool playerInRange = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag(playerTag).transform;
    }

    void Update()
    {
        if (player == null || !playerInRange)
        {
            // Player not found or not in range, stop shooting
            return;
        }

        // Check if enough time has passed since the last fire
        if (Time.time >= nextFireTime)
        {
            Fire();
            nextFireTime = Time.time + 1 / fireRate; // Set the next allowed fire time
        }
    }

    void Fire()
    {
        Vector3 fireDirection = (player.position - firePoint.position).normalized;
        Quaternion rotation = Quaternion.LookRotation(fireDirection);
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, rotation);

        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();
        if (projectileRb != null)
        {
            projectileRb.velocity = fireDirection * projectileSpeed;
        }
        else
        {
            Debug.LogError("Projectile is missing a Rigidbody component.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(playerTag))
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(playerTag))
        {
            playerInRange = false;
        }
    }
}
