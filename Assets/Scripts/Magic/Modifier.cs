using UnityEngine;

[CreateAssetMenu(fileName = "NuevoModificador", menuName = "Elementary Magic/Modificador")]
public class ModificadorSO : ScriptableObject
{
    [Header("Datos del Modificador")]
    public string nombreModificador;

    [Header("Multiplicadores")]
    public float multiplicadorDaño = 1f;
    public float multiplicadorVelocidad = 1f;
    public float multiplicadorCosto = 1f;
}
