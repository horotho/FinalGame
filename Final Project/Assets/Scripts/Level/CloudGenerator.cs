using UnityEngine;
using System.Collections;
using LibNoise;

public class CloudGenerator : MonoBehaviour
{

    void Update()
    {
        ParticleSystem.Particle[] particles = new ParticleSystem.Particle[particleSystem.particleCount];
        particleSystem.GetParticles(particles);

        for(int i = 0; i < particles.Length; i++)
        {
            float value2 = Random.value * Mathf.Cos(2 * Mathf.PI * Time.time * Time.time);
            particles[i].velocity = new Vector3(value2, Random.value, 0);
        }

        particleSystem.SetParticles(particles, particles.Length);
    }

}
