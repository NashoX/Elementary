using UnityEngine;

public class EnemySimple : MonoBehaviour
{
    public Transform objetivo; // jugador
    public float velocidad = 3f;
    public float distanciaAtaque = 1.5f;
    public float daño = 10f;
    public float tiempoEntreGolpes = 1f;

    private float contadorGolpe = 0f;

    private Vida vidaJugador;

    void Start()
    {
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

        // Ataque si está cerca
        contadorGolpe -= Time.deltaTime;
        if (Vector3.Distance(transform.position, objetivo.position) <= distanciaAtaque && contadorGolpe <= 0f)
        {
            vidaJugador.RecibirDaño(daño);
            contadorGolpe = tiempoEntreGolpes;
        }
    }
}

