using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "DeseaseList", menuName = "Data/DeseaseList")]
public class DeseaseList : ScriptableObject
{
    public List<Desease> Deseases;
}
