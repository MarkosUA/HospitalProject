using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleStarScript : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem _particleSystem;

    private void Start()
    {
        GameController.Drank += StartParticleSystem;
    }

    private void StartParticleSystem()
    {
        _particleSystem.Play();
    }

}
