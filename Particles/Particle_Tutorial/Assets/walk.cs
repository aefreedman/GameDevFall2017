using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walk : MonoBehaviour
{
    private ParticleSystem _particleSystem;

    private bool _trigger;
    public float Speed;

    void Start()
    {
        _particleSystem = GetComponentInChildren<ParticleSystem>();
    }

    void Update()
    {
        
        if (_trigger)
            _particleSystem.Play();
        else

            _particleSystem.Stop();


        
        var direction = Input.GetAxis("Horizontal");
        if (direction != 0)
        {
            transform.Translate(direction * Vector2.right * Speed);
            _trigger = true;
            return;
        }
        _trigger = false;
    }
}