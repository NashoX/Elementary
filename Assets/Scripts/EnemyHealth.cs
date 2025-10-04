using UnityEngine;

public class VidaEnemigo : MonoBehaviour
{
    public float vidaMaxima = 50f;
    public float vidaActual;

    void Start()
    {
        vidaActual = vidaMaxima;
    }

    public void RecibirDaño(float cantidad)
    {
        vidaActual -= cantidad;
        Debug.Log($"{gameObject.name} recibió {cantidad} de daño. Vida restante: {vidaActual}");
        Debug.Log($"{gameObject.name} recibió {cantidad} de daño. Vida restante: {vidaActual}");

        if (vidaActual <= 0)
        {
            Morir();
        }
    }

    void Morir()
    {
        Debug.Log($"{gameObject.name} ha muerto.");
        Destroy(gameObject);
    }
}
