using UnityEngine;

[CreateAssetMenu(fileName = "Desease", menuName = "Data/Desease")]
public class Desease : ScriptableObject
{
    public string Name;
    public string BodyPart;
    public Medicine Medicines;
    public bool ActualDesease;
}
