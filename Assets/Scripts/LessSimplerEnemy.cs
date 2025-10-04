using UnityEngine;

public class EnemyMelee : MonoBehaviour
{
    [Header("References")]
    public Transform target;       // Player
    private Health playerHealth;   // reference to player's Health

    [Header("Movement")]
    public float speed = 3f;

    [Header("Attack")]
    public float attackRange = 2f;      // minimum distance to attack
    public float damage = 20f;          // damage dealt per hit
    public float timeBetweenAttacks = 1.5f;
    [Range(0f, 1f)]
    public float hitChance = 0.7f;      // 70% chance to hit

    private float attackCooldown = 0f;

    void Start()
    {
        if (target != null)
            playerHealth = target.GetComponent<Health>();
    }

    void Update()
    {
        if (target == null) return;

        // Move towards the player
        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;

        // Look at the player
        transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));

        // Cooldown timer
        attackCooldown -= Time.deltaTime;

        // Attempt attack if close and cooldown finished
        float distance = Vector3.Distance(transform.position, target.position);
        if (distance <= attackRange && attackCooldown <= 0f)
        {
            PerformAttack();
            attackCooldown = timeBetweenAttacks;
        }
    }

    void PerformAttack()
    {
        if (playerHealth == null) return;

        // Chance to hit
        if (Random.value <= hitChance)
        {
            playerHealth.TakeDamage(damage);
            Debug.Log("Enemy hit the Player!");
        }
        else
        {
            Debug.Log("Enemy missed the attack!");
        }
    }
}
