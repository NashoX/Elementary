using UnityEngine;

public class SpellCasting : MonoBehaviour
{
    public Transform firePoint;
    public Spell spellSelected;
    public float energy = 100f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            CastSpell();
    }

    void CastSpell()
    {
        if (spellSelected == null)
        {
            Debug.LogError("❌ No spell selected!");
            return;
        }

        spellSelected.Initialize();

        if (energy < spellSelected.manaCost)
        {
            Debug.Log("Not enough energy!");
            return;
        }

        energy -= spellSelected.manaCost;

        GameObject proj = Instantiate(
            spellSelected.execution.projectilePrefab,
            firePoint.position,
            firePoint.rotation
        );

        proj.transform.localScale = Vector3.one * spellSelected.size;

        ParticleSystem ps = proj.GetComponent<ParticleSystem>();
        if (ps != null)
        {
            var main = ps.main;
            main.startColor = spellSelected.element.particleColor;
        }

        Projectile projScript = proj.GetComponent<Projectile>();
        if (projScript != null)
            projScript.Configure(spellSelected.damage, spellSelected.speed);

        Debug.Log($"🔥 Casted {spellSelected.element.elementName} + {spellSelected.execution.executionName} with damage {spellSelected.damage}");
    }
}
