using UnityEngine;

[System.Serializable]
public class Spell
{
    public ElementoSO elemento;
    public EjecucionSO ejecucion;
    public ModificadorSO modificador;

    public float daño;
    public float velocidad;
    public float tamaño;
    public float costoMana;

    // Constructor
    public Spell(ElementoSO el, EjecucionSO ej, ModificadorSO mod)
    {
        elemento = el;
        ejecucion = ej;
        modificador = mod;

        // Stats calculados con multiplicadores
        daño = ej.danoBase * mod.multiplicadorDaño;
        velocidad = ej.velocidadBase * mod.multiplicadorVelocidad;
        tamaño = ej.tamanoBase; // podés multiplicar por un modificador si querés
        costoMana = ej.costoBase * mod.multiplicadorCosto;
    }

    // ? Método para imprimir en consola (para SpellTester)
    public void ImprimirStats()
    {
        Debug.Log("?? Hechizo creado:");
        Debug.Log("Elemento: " + elemento.nombreElemento);
        Debug.Log("Ejecución: " + ejecucion.nombreEjecucion);
        Debug.Log("Modificador: " + modificador.nombreModificador);
        Debug.Log("Daño: " + daño);
        Debug.Log("Velocidad: " + velocidad);
        Debug.Log("Tamaño: " + tamaño);
        Debug.Log("Costo de maná: " + costoMana);
    }
}
