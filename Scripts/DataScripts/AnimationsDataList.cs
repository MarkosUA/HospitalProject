using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "AnimationsDataList", menuName = "Data/AnimationsDataList")]

public class AnimationsDataList : ScriptableObject
{
    public List<AnimationData> AnimationsData;
}
