using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerUI : MonoBehaviour
{
    public Vida vidaJugador; // referencia al script Vida del Player
    public Slider sliderVida;
    public TMP_Text textoVida; // opcional, para mostrar "50 / 100"

    void Update()
    {
        
        if (vidaJugador == null) return;

        sliderVida.value = vidaJugador.vidaActual / vidaJugador.vidaMaxima;

        if (textoVida != null)
            textoVida.text = $"{vidaJugador.vidaActual} / {vidaJugador.vidaMaxima}";
    }
}
