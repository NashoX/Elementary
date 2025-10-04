using UnityEngine;

public class Vida : MonoBehaviour
{
    public float vidaMaxima = 100f;
    public float vidaActual;

    void Start()
    {
        vidaActual = vidaMaxima;
    }

    // Método para recibir daño
    public void RecibirDaño(float cantidad)
    {
        vidaActual -= cantidad;
        Debug.Log(name + " recibió daño. Vida actual: " + vidaActual);

        if (vidaActual <= 0f)
        {
            Morir();
        }
    }

    void Morir()
    {
        Debug.Log(name + " murió.");
        Destroy(gameObject);
    }
}
