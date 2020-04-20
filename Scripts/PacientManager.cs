using UnityEngine;
using Spine.Unity;
using System.Collections.Generic;

public class PacientManager : CharacterBase
{
    [SerializeField]
    private SkeletonAnimation _skeleton;
    [SerializeField]
    private PacientAnimationNames _animationNames;
    [SerializeField]
    private PacientSkinNames _pacientSkinNames;

    [SerializeField]
    private List<GameObject> _spots;

    public List<GameObject> Spots
    {
        get
        {
            return _spots;
        }
    }

    public void CharacterSelection()
    {
        int rand = Random.Range(0, 6);

        switch (rand)
        {
            case 0:
                _skeleton.Skeleton.SetSkin(_pacientSkinNames.SKIN_1);
                break;
            case 1:
                _skeleton.Skeleton.SetSkin(_pacientSkinNames.SKIN_2);
                break;
            case 2:
                _skeleton.Skeleton.SetSkin(_pacientSkinNames.SKIN_3);
                break;
            case 3:
                _skeleton.Skeleton.SetSkin(_pacientSkinNames.SKIN_4);
                break;
            case 4:
                _skeleton.Skeleton.SetSkin(_pacientSkinNames.SKIN_5);
                break;
            case 5:
                _skeleton.Skeleton.SetSkin(_pacientSkinNames.SKIN_6);
                break;
            default:
                _skeleton.Skeleton.SetSkin(_pacientSkinNames.SKIN_7);
                break;
        }
    }

    public void WaitAnim()
    {
        SetCharacterState(_animationNames.START_ANIMATION_1, _skeleton, true, false);
    }

    public void TableteAnim()
    {
        SetCharacterState(_animationNames.TABLE_ANIMATION, _skeleton, false, true);
    }

    public void DrinkingWaterAnim()
    {
        SetCharacterState(_animationNames.WATER_DRINK, _skeleton, true, false);
        StartCoroutine(WaitForDrink(2f));
    }

    public void HappyAnim()
    {
        SetCharacterState(_animationNames.HAPPY_REACTION, _skeleton, true, false);
    }

    private System.Collections.IEnumerator WaitForDrink(float time)
    {
        yield return new WaitForSeconds(time);
        SetCharacterState(_animationNames.WATER_DRINK, _skeleton, false, true);
    }

}
