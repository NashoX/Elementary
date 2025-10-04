using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float damage;
    private float speed;
    private float lifeTime = 5f;

    public void Configure(float damage, float speed)
    {
        this.damage = damage;
        this.speed = speed;
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        float distance = speed * Time.deltaTime;
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, distance))
        {
            Health health = hit.collider.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(damage);
                Debug.Log($"Projectile hit {hit.collider.gameObject.name}, damage: {damage}");
            }

            Destroy(gameObject); // destruye proyectil al impactar
            return;
        }

        transform.position += transform.forward * distance;
    }
}
