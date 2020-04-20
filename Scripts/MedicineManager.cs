using UnityEngine;
using System.Collections;

public class MedicineManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _box_1;
    [SerializeField]
    private GameObject _box_2;

    [SerializeField]
    private Water _water_prefab;

    [SerializeField]
    private Animator _BoxAnimator;

    public void Therapy(Desease desease)
    {
        var tablete = Instantiate(desease.Medicines.gameObject, _box_2.transform.position, Quaternion.identity);
        tablete.transform.SetParent(_box_2.transform);

        var water = Instantiate(_water_prefab.gameObject, _box_1.transform.position, Quaternion.identity);
        water.transform.SetParent(_box_1.transform);

        _BoxAnimator.SetBool("OpenBoxes", true);
    }
}
