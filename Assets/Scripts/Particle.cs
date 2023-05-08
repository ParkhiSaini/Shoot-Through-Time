using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    public ParticleSystem Smoke;
    // Start is called before the first frame update
    void Awake()
    {
        Smoke.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
