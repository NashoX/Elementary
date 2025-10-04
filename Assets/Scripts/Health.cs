using UnityEngine;

public class Vida : MonoBehaviour
{
    public float vidaMaxima = 100f;
    public float vidaActual;

    void Start()
    {
        vidaActual = vidaMaxima;
    }

    // M�todo para recibir da�o
    public void RecibirDa�o(float cantidad)
    {
        vidaActual -= cantidad;
        Debug.Log(name + " recibi� da�o. Vida actual: " + vidaActual);

        if (vidaActual <= 0f)
        {
            Morir();
        }
    }

    void Morir()
    {
        Debug.Log(name + " muri�.");
        Destroy(gameObject);
    }
}
