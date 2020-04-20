using UnityEngine;
using System.Collections.Generic;

public class ScopeController : MonoBehaviour
{
    public MyEvent therapy;

    [SerializeField]
    private GameObject _scopeAndRope;
    [SerializeField]
    private SliderProgress _slider;
    [SerializeField]
    private DeseaseList _deseaseList;
    [SerializeField]
    private MedicineManager _medicineManager;

    [SerializeField]
    private float _distance;
    [SerializeField]
    private float _sliderSpeed;

    private bool _deseaseIsFind;
    private float _sliderValue;
    private GameObject _selectedSpot;

    private List<GameObject> _spotsPositions = new List<GameObject>();

    private void Update()
    {
        if (!_deseaseIsFind)
            ChekPosition();
    }

    public void Activate(List<GameObject> spots)
    {
        for (int i = 0; i < spots.Count; i++)
        {
            _spotsPositions.Add(spots[i]);
            _spotsPositions[i].SetActive(true);
            _scopeAndRope.SetActive(true);
        }
    }

    public void DeActivate()
    {
        _scopeAndRope.SetActive(false);
    }

    private void ChekPosition()
    {
        var position = new Vector2(transform.position.x, transform.position.y);

        if (_spotsPositions != null)
        {
            for (int i = 0; i < _spotsPositions.Count; i++)
            {
                if (_selectedSpot == null && _spotsPositions[i].activeSelf)
                {
                    if (Vector2.Distance(position, _spotsPositions[i].transform.position) < _distance)
                    {
                        _selectedSpot = _spotsPositions[i];
                        therapy.Invoke(_spotsPositions[i].name);
                    }
                }
                else
                {
                    if (_selectedSpot == _spotsPositions[i])
                    {
                        if (Vector2.Distance(position, _spotsPositions[i].transform.position) < _distance)
                        {
                            if (_sliderValue <= 100)
                            {
                                _slider.gameObject.SetActive(true);
                                _slider.SliderChange(_sliderValue, 100f);
                                _sliderValue += Time.deltaTime * _sliderSpeed;
                            }
                            else
                            {
                                if (!SuccessfulDeseaseChek(_spotsPositions[i]))
                                {
                                    _spotsPositions[i].SetActive(false);
                                    _sliderValue = 0;
                                    _spotsPositions.Remove(_spotsPositions[i]);
                                    _slider.gameObject.SetActive(false);
                                    _selectedSpot = null;
                                }
                            }
                        }
                        else
                        {
                            _selectedSpot = null;
                            _slider.gameObject.SetActive(false);
                            _sliderValue = 0;
                            therapy.Invoke("Cancel");
                        }
                    }
                }
            }
        }
    }

    private bool SuccessfulDeseaseChek(GameObject spot)
    {
        for (int i = 0; i < _deseaseList.Deseases.Count; i++)
        {
            if (spot.name == _deseaseList.Deseases[i].BodyPart && _deseaseList.Deseases[i].ActualDesease == true)
            {
                for (int j = 0; j < _spotsPositions.Count; j++)
                {
                    _spotsPositions[j].SetActive(false);
                }
                _slider.gameObject.SetActive(false);
                _deseaseIsFind = true;
                _medicineManager.Therapy(_deseaseList.Deseases[i]);
                therapy.Invoke("Successfull");
                return true;
            }
        }
        therapy.Invoke("Continue");
        return false;
    }
}

