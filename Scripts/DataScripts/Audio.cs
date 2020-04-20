using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Audio", menuName = "Data/Audio")]
public class Audio : ScriptableObject
{
    public string Name;
    public AudioClip Clip;
}
