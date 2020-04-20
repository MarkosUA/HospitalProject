using UnityEngine;
using Spine.Unity;
using System.Collections;

public class DoctorManager : CharacterBase
{
    [SerializeField]
    private DoctorAnimationNames _animationNames;
    [SerializeField]
    private SkeletonAnimation _skeleton;

    public void WaitAnimation()
    {
        SetCharacterState(_animationNames.WAIT_ANIMATION, _skeleton, true, false);
    }

    public void WaitWithSkopeAnim_1()
    {
        SetCharacterState(_animationNames.WAIT_WITH_SKOPE_1, _skeleton, true, false);
    }

    public void WaitWithSkopeAnim_2()
    {
        SetCharacterState(_animationNames.WAIT_WITH_SKOPE_2, _skeleton, true, false);
    }

    public void TalkAnimation()
    {
        SetCharacterState(_animationNames.TALK_ANIMATION, _skeleton, true, false);
    }

    public void TalkWithSkopeAnim()
    {
        SetCharacterState(_animationNames.TALK_WITH_SKOPE, _skeleton, true, false);
    }

    public void TakingSkopeAnim()
    {
        SetCharacterState(_animationNames.TAKES_OUT_SKOPE, _skeleton, false, true);
    }

    public void RemoveSkopeAnim()
    {
        SetCharacterState(_animationNames.REMOVE_SKOPE, _skeleton, false, true);
    }

}
