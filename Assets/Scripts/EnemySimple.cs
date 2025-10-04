using UnityEngine;

public class EnemySimple : MonoBehaviour
{
    [Header("References")]
    public Transform target;        // Player
    private Health playerHealth;

    [Header("Movement")]
    public float speed = 3f;

    [Header("Attack")]
    public float attackRange = 1.5f;
    public float damage = 10f;
    public float timeBetweenAttacks = 1f;

    private float attackCooldown = 0f;

    void Start()
    {
        if (target != null)
            playerHealth = target.GetComponent<Health>();
    }

    void Update()
    {
        if (target == null) return;

        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;

        transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));

        attackCooldown -= Time.deltaTime;

        if (Vector3.Distance(transform.position, target.position) <= attackRange && attackCooldown <= 0f)
        {
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
                Debug.Log("Enemy hit the Player!");
            }
            attackCooldown = timeBetweenAttacks;
        }
    }
}
