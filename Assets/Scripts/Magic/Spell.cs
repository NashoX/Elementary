using UnityEngine;

[System.Serializable]
public class Spell
{
    public ElementoSO elemento;
    public EjecucionSO ejecucion;
    public ModificadorSO modificador;

    public float da�o;
    public float velocidad;
    public float tama�o;
    public float costoMana;

    // Constructor
    public Spell(ElementoSO el, EjecucionSO ej, ModificadorSO mod)
    {
        elemento = el;
        ejecucion = ej;
        modificador = mod;

        // Stats calculados con multiplicadores
        da�o = ej.danoBase * mod.multiplicadorDa�o;
        velocidad = ej.velocidadBase * mod.multiplicadorVelocidad;
        tama�o = ej.tamanoBase; // pod�s multiplicar por un modificador si quer�s
        costoMana = ej.costoBase * mod.multiplicadorCosto;
    }

    // ? M�todo para imprimir en consola (para SpellTester)
    public void ImprimirStats()
    {
        Debug.Log("?? Hechizo creado:");
        Debug.Log("Elemento: " + elemento.nombreElemento);
        Debug.Log("Ejecuci�n: " + ejecucion.nombreEjecucion);
        Debug.Log("Modificador: " + modificador.nombreModificador);
        Debug.Log("Da�o: " + da�o);
        Debug.Log("Velocidad: " + velocidad);
        Debug.Log("Tama�o: " + tama�o);
        Debug.Log("Costo de man�: " + costoMana);
    }
}
