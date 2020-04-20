using UnityEngine;
using Spine.Unity;

public class CharacterBase : MonoBehaviour
{
    [SerializeField]
    private AnimationsDataList _animations;

    private string _currentAnim;

    public MyEvent onFinishAnim;

    private void SetAnimation(SkeletonAnimation skeletonAnimation, AnimationReferenceAsset animation, bool loop, bool wait, float timeScale)
    {
        if (!wait)
            skeletonAnimation.state.SetAnimation(0, animation, loop).TimeScale = timeScale;
        else
        {
            skeletonAnimation.state.SetAnimation(0, animation, loop).TimeScale = timeScale;
            skeletonAnimation.state.SetAnimation(0, animation, loop).Complete += Test;
        }
    }

    protected void SetCharacterState(string state, SkeletonAnimation skeletonAnimation, bool loop, bool wait)
    {
        for (int i = 0; i < _animations.AnimationsData.Count; i++)
        {
            if (state == _animations.AnimationsData[i].Key)
            {
                SetAnimation(skeletonAnimation, _animations.AnimationsData[i].Animation, loop, wait, 1f);
            }
        }
    }

    private void Test(Spine.TrackEntry trackEntry)
    {
        onFinishAnim.Invoke(trackEntry.animation.name);
    }

}
