using UnityEngine;
using System.Collections;

public class Medicine : MonoBehaviour
{
    public delegate void TherapyAction();
    public static event TherapyAction TakeAPillAction;

    private Transform _mouth;

    private float _distance = 0.75f;
    private bool _takeAPill;

    private void Start()
    {
        if (GameObject.Find("Mouth") != null)
            _mouth = GameObject.Find("Mouth").transform;
    }

    private void Update()
    {
        ChekPosition();
    }

    private void ChekPosition()
    {
        if (Vector2.Distance(transform.position, _mouth.position) < _distance && !_takeAPill)
        {
            _takeAPill = true;
            TakeAPillAction();
            gameObject.SetActive(false);
        }
    }

}
