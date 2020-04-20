using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private PacientManager _pacientManager;
    [SerializeField]
    private DoctorManager _doctorManager;
    [SerializeField]
    private AudioManager _audioManager;
    [SerializeField]
    private ScopeController _scopeController;
    [SerializeField]
    private DeseaseList _deseaseList;
    [SerializeField]
    private AudioList _audioList;
    [SerializeField]
    private AnimationsDataList _animationsDataList;
    [SerializeField]
    private GameObject _panel;

    public delegate void DrinkingAction();
    public static event DrinkingAction Drank;

    private void Awake()
    {
        _pacientManager.CharacterSelection();
        DeseaseSelection();
    }

    private void Start()
    {
        _pacientManager.WaitAnim();
        _doctorManager.WaitAnimation();

        StartCoroutine(StartCoroutine());

        _audioManager.onFinishSound.AddListener(WhereWeAreAudio);
        _doctorManager.onFinishAnim.AddListener(WhereWeAreAnim);
        _pacientManager.onFinishAnim.AddListener(WhereWeAreAnim);
        _scopeController.therapy.AddListener(WhereWeAreTherapy);
        Medicine.TakeAPillAction += PacientTherapy;
        Water.DrinkingWater += WaterDrink;
    }

    private void FirstPhrase()
    {
        _doctorManager.TalkAnimation();
        _audioManager.PlayAudioWithPause(FindAudio("ListenToTheZones"));
    }

    private void WhereWeAreAudio(string nameOfTheLastAudio)
    {
        switch (nameOfTheLastAudio)
        {
            case "ListenToTheZones":
                _doctorManager.TakingSkopeAnim();
                break;
            case "DragScope":
                _doctorManager.WaitWithSkopeAnim_2();
                break;
            case "ChekTheRestOfTheZones":
                _doctorManager.WaitWithSkopeAnim_2();
                break;
            case "ContinueTreatment":
                _scopeController.DeActivate();
                _doctorManager.RemoveSkopeAnim();
                _doctorManager.TalkAnimation();
                _audioManager.PlayAudioWithPause(FindAudio("GiveMedicine"));
                break;
            case "GiveMedicine":
                _doctorManager.WaitAnimation();
                break;
        }
    }

    private void WhereWeAreAnim(string nameOfTheAnim)
    {
        for (int i = 0; i < _animationsDataList.AnimationsData.Count; i++)
        {
            if (nameOfTheAnim == _animationsDataList.AnimationsData[i].Animation.name)
            {
                if (_animationsDataList.AnimationsData[i].Key == "Doctor_SkopOUT")
                {
                    _doctorManager.TalkWithSkopeAnim();
                    _audioManager.PlayAudioWithPause(FindAudio("DragScope"));
                    _scopeController.Activate(_pacientManager.Spots);
                }
                else
                {
                    if (_animationsDataList.AnimationsData[i].Key == "Doctor_SkopRemove")
                    {
                        _doctorManager.WaitAnimation();
                    }
                    else
                    {
                        if (_animationsDataList.AnimationsData[i].Key == "Tablete")
                        {
                            _pacientManager.WaitAnim();
                        }
                        else
                        {
                            if (_animationsDataList.AnimationsData[i].Key == "WaterDrink")
                            {
                                _pacientManager.HappyAnim();
                                Drank();
                                _panel.SetActive(true);
                            }
                        }
                    }
                }
            }
        }
    }

    private void WhereWeAreTherapy(string position)
    {
        switch (position)
        {
            case "Leg":
                _audioManager.PlayAudioWithOutPause(FindAudio("LegSound"));
                break;
            case "Lungs":
                _audioManager.PlayAudioWithOutPause(FindAudio("BreathSound"));
                break;
            case "Heart":
                _audioManager.PlayAudioWithOutPause(FindAudio("HeartSound"));
                break;
            case "Stomach":
                _audioManager.PlayAudioWithOutPause(FindAudio("StomakSound"));
                break;
            case "Continue":
                _audioManager.StopAudio();
                _doctorManager.TalkWithSkopeAnim();
                _audioManager.PlayAudioWithPause(FindAudio("ChekTheRestOfTheZones"));
                break;
            case "Successfull":
                _audioManager.StopAudio();
                _doctorManager.TalkWithSkopeAnim();
                _audioManager.PlayAudioWithPause(FindAudio("ContinueTreatment"));
                break;
            default:
                _audioManager.StopAudio();
                break;
        }
    }

    private void PacientTherapy()
    {
        _pacientManager.TableteAnim();
    }

    private void WaterDrink()
    {
        _pacientManager.DrinkingWaterAnim();
    }

    private Audio FindAudio(string name)
    {
        for (int i = 0; i < _audioList.Audios.Count; i++)
        {
            if (_audioList.Audios[i].Name == name)
                return _audioList.Audios[i];
        }
        return null;
    }

    private void DeseaseSelection()
    {
        var rand = Random.Range(0, _deseaseList.Deseases.Count);

        for (int i = 0; i < _deseaseList.Deseases.Count; i++)
        {
            if (i == rand)
            {
                _deseaseList.Deseases[i].ActualDesease = true;
            }
            else
                _deseaseList.Deseases[i].ActualDesease = false;
        }
    }

    private IEnumerator StartCoroutine()
    {
        yield return new WaitForSeconds(2f);
        FirstPhrase();
    }

}
