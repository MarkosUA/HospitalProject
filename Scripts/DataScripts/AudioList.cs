using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "AudioList", menuName = "Data/AudioList")]
public class AudioList : ScriptableObject
{
    public List<Audio> Audios;
}
