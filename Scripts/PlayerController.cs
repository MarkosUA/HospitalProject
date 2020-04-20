using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Transform _scope;
    [SerializeField]
    private Transform _tablete1;
    [SerializeField]
    private Transform _tablete2;
    [SerializeField]
    private Transform _water;
    [SerializeField]
    private ParticleSystem _onClickParticleSystem;

    private float _distance = 10f;
    private string layerThatReactsOnMouseClick = "Clickable";
    private int leftMouseClick = 0;
    private GameObject _object;
    private bool _objSelected;

    private void Start()
    {
        GameController.Drank += ClickSelectOff;
    }

    private void Update()
    {
        ClickSelect();
        OnMouseDrag();
    }

    private void OnMouseDrag()
    {
        if (_objSelected)
        {
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _distance);
            Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            _object.transform.position = objPosition;
        }
    }

    private void ClickSelect()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);

            if (hit && hit.transform.tag == "Clickable")
            {
                _object = hit.transform.gameObject;
                _objSelected = true;
            }
            else
            {
                _onClickParticleSystem.transform.position = rayPos;
                _onClickParticleSystem.Play();
            }
        }
        else
        if (Input.GetMouseButtonDown(1))
            ClickSelectOff();
        else
            if (Input.touchCount >= 2)
        {
            var touch = Input.GetTouch(1);
            if (touch.phase == TouchPhase.Began)
                ClickSelectOff();
        }

    }

    private void ClickSelectOff()
    {
        _objSelected = false;
    }

}
