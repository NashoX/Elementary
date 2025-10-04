using UnityEngine;

public class EnemyGolpe : MonoBehaviour
{
    [Header("Referencias")]
    public Transform objetivo; // el Player
    public Vida vidaJugador;

    [Header("Movimiento")]
    public float velocidad = 3f;

    [Header("Ataque")]
    public float distanciaAtaque = 2f;  // distancia mínima para intentar golpear
    public float daño = 20f;            // daño que hace el golpe
    public float tiempoEntreGolpes = 1.5f;
    [Range(0f, 1f)]
    public float chanceAcertar = 0.7f;   // 70% de probabilidad de acertar

    private float contadorGolpe = 0f;

    void Start()
    {
        if (objetivo != null)
            vidaJugador = objetivo.GetComponent<Vida>();
    }

    void Update()
    {
        if (objetivo == null) return;

        // Mover hacia el jugador
        Vector3 direccion = (objetivo.position - transform.position).normalized;
        transform.position += direccion * velocidad * Time.deltaTime;

        // Mirar al jugador
        transform.LookAt(new Vector3(objetivo.position.x, transform.position.y, objetivo.position.z));

        // Contador de cooldown
        contadorGolpe -= Time.deltaTime;

        // Intentar ataque si está cerca y el cooldown terminó
        float distancia = Vector3.Distance(transform.position, objetivo.position);
        if (distancia <= distanciaAtaque && contadorGolpe <= 0f)
        {
            LanzarGolpe();
            contadorGolpe = tiempoEntreGolpes;
        }
    }

    void LanzarGolpe()
    {
        // Probabilidad de acierto
        if (Random.value <= chanceAcertar)
        {
            vidaJugador.RecibirDaño(daño);
            Debug.Log("Enemy golpeó al Player!");
        }
        else
        {
            Debug.Log("Enemy falló el golpe!");
        }
    }
}
