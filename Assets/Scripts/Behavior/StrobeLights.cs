﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class StrobeLights : MonoBehaviour
{
    [SerializeField] private float period;
    Light dirLight;
    Color initialColor;
    const float tau = Mathf.PI * 2;

    // Start is called before the first frame update
    void Start()
    {
        dirLight = GetComponent<Light>();
        initialColor = dirLight.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon)
            return;
        float cycles = Time.time / period;
        float rawSinWave = Mathf.Sin(cycles * tau);
        float strobeFactor = (rawSinWave / 2f) + 0.5f;
        dirLight.color = new Color(initialColor.r + strobeFactor * 2, initialColor.g, initialColor.b);
    }
}

