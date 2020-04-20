using UnityEngine;

[CreateAssetMenu(fileName = "DoctorAnimationNames", menuName = "Data/AnimationNames/DoctorAnimationNames")]

public class DoctorAnimationNames : ScriptableObject
{
    public string TALK_ANIMATION = "Doctor_Talk";
    public string TALK_WITH_SKOPE = "Doctor_TalkWithSkope";
    public string WAIT_ANIMATION = "Doctor_Wait";
    public string WAIT_WITH_SKOPE_1 = "Doctor_WaitWithSkope_1";
    public string WAIT_WITH_SKOPE_2 = "Doctor_WaitWithSkope_2";
    public string TAKES_OUT_SKOPE = "Doctor_SkopOUT";
    public string REMOVE_SKOPE = "Doctor_SkopRemove";
}
