using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public float fireRate = 1.0f;
    public GameObject projectilePrefab;
    public Transform firePoint;
    public string playerTag = "Player";
    public float projectileSpeed = 10.0f;

    private Transform player;
    private float nextFireTime;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag(playerTag).transform;
    }

    void Update()
    {
        if (player == null)
        {
            // Player not found, stop shooting
            return;
        }

        if (Time.time > nextFireTime)
        {
            nextFireTime = Time.time + 1 / fireRate;
            Fire();
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
        if (other.CompareTag(playerTag))
        {
            nextFireTime = Time.time; // Fire immediately when player is in range
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            nextFireTime = Time.time + 1 / fireRate; // Reset fire timer when player exits range
        }
    }
}
