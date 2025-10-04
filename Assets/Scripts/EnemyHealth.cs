using UnityEngine;

public class VidaEnemigo : MonoBehaviour
{
    public float vidaMaxima = 50f;
    public float vidaActual;

    void Start()
    {
        vidaActual = vidaMaxima;
    }

    public void RecibirDa�o(float cantidad)
    {
        vidaActual -= cantidad;
        Debug.Log($"{gameObject.name} recibi� {cantidad} de da�o. Vida restante: {vidaActual}");
        Debug.Log($"{gameObject.name} recibi� {cantidad} de da�o. Vida restante: {vidaActual}");

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
