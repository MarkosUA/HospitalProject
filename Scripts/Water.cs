using UnityEngine;

public class Water : MonoBehaviour
{
    public delegate void WaterAction();
    public static event WaterAction DrinkingWater;

    private Transform _mouth;

    [SerializeField]
    private Animator _animator;

    private float _distance = 1f;

    private bool _alreadyDrink;
    private bool _waterGoAway;
    private bool _takedAPill;

    private void Start()
    {
        if (GameObject.Find("Mouth") != null)
            _mouth = GameObject.Find("Mouth").transform;

        GameController.Drank += WaterGoAway;
        Medicine.TakeAPillAction += Tablete;
    }

    private void Update()
    {
        ChekPosition();

        if (_waterGoAway && transform.rotation.z == 0)
            transform.Translate(-Vector3.up * Time.deltaTime * 10f);
    }

    private void ChekPosition()
    {
        if (Vector2.Distance(transform.position, _mouth.position) < _distance && !_alreadyDrink && _takedAPill)
        {
            _alreadyDrink = true;
            DrinkingWater();
            _animator.SetBool("StartWaterBottleAnim", true);
        }
    }

    private void WaterGoAway()
    {
        _animator.SetBool("FinishWaterBottleAnim", true);
        _waterGoAway = true;
    }

    private void Tablete()
    {
        _takedAPill = true;
    }

}
