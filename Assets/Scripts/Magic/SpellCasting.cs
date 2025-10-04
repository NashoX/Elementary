using UnityEngine;

public class PlayerMagia : MonoBehaviour
{
    [Header("Punto de disparo del hechizo")]
    public Transform puntoDisparo; // dónde aparece el proyectil

    [Header("Hechizo seleccionado")]
    public ElementoSO elementoSeleccionado;
    public EjecucionSO ejecucionSeleccionada;
    public ModificadorSO modificadorSeleccionado;

    [Header("Energía del jugador")]
    public float energia = 100f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) // click izquierdo
        {
            LanzarHechizo();
        }
    }

    void LanzarHechizo()
    {
        // Crear un hechizo combinando Elemento + Ejecución + Modificador
        Spell spell = new Spell(elementoSeleccionado, ejecucionSeleccionada, modificadorSeleccionado);

        // Chequear si el jugador tiene energía suficiente
        if (energia < spell.costoMana)
        {
            Debug.Log("⚠️ No hay suficiente energía!");
            return;
        }

        // Gastar energía
        energia -= spell.costoMana;

        // Instanciar el proyectil desde la ejecución
        GameObject proyectil = Instantiate(spell.ejecucion.prefabProyectil, puntoDisparo.position, puntoDisparo.rotation);

        // Ajustar tamaño
        proyectil.transform.localScale = Vector3.one * spell.tamaño;

        // Aplicar color del elemento si hay partículas
        ParticleSystem ps = proyectil.GetComponent<ParticleSystem>();
        if (ps != null)
        {
            var main = ps.main;
            main.startColor = spell.elemento.colorParticulas;
        }

        // Darle velocidad al proyectil (requiere Rigidbody en el prefab)
        Rigidbody rb = proyectil.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = transform.forward * spell.velocidad;
        }

        Debug.Log($"✨ Lanzado {spell.elemento.nombreElemento} + {spell.ejecucion.nombreEjecucion} con daño {spell.daño}, costo {spell.costoMana}, tamaño {spell.tamaño}");
    }
}
