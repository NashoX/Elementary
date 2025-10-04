using UnityEngine;

[CreateAssetMenu(fileName = "NuevaEjecucion", menuName = "Elementary Magic/Ejecucion")]
public class EjecucionSO : ScriptableObject
{
    [Header("Datos de la Ejecución")]
    public string nombreEjecucion;

    [Header("Stats base")]
    public float danoBase = 10f;        // daño inicial
    public float velocidadBase = 5f;    // velocidad del proyectil
    public float tamanoBase = 1f;       // tamaño/escala del proyectil
    public float costoBase = 20f;       // costo base de maná

    [Header("Prefab asociado")]
    public GameObject prefabProyectil;  // el prefab que se va a instanciar
}
