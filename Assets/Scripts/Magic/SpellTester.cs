using UnityEngine;

public class SpellTester : MonoBehaviour
{
    public ElementoSO elemento;
    public EjecucionSO ejecucion;
    public ModificadorSO modificador;

    void Start()
    {
        Spell nuevoHechizo = new Spell(elemento, ejecucion, modificador);
        nuevoHechizo.ImprimirStats(); // ✅ imprime en consola
    }
}
