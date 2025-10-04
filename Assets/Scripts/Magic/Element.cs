using UnityEngine;

[CreateAssetMenu(fileName = "NuevoElemento", menuName = "Elementary Magic/Elemento")]
public class ElementoSO : ScriptableObject
{
    [Header("Datos del Elemento")]
    public string nombreElemento;
    public Color colorParticulas;   // Para efectos visuales de partículas
}
