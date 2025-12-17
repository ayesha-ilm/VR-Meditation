using UnityEngine;

public class BreathParticlesController : MonoBehaviour
{
    public ParticleSystem inhaleParticles;
    public ParticleSystem exhaleParticles;

    void Start()
    {
        inhaleParticles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        exhaleParticles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
    }

    void Update()
    {
        bool leftGrip = Input.GetKey(KeyCode.G);   // LEFT controller
        bool rightGrip = Input.GetKey(KeyCode.H);  // RIGHT controller

        // INHALE — Left controller
        if (leftGrip && !rightGrip)
        {
            if (!inhaleParticles.isPlaying)
            {
                exhaleParticles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
                inhaleParticles.Play();
            }
        }
        // EXHALE — Right controller
        else if (rightGrip && !leftGrip)
        {
            if (!exhaleParticles.isPlaying)
            {
                inhaleParticles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
                exhaleParticles.Play();
            }
        }
        // Neither or both pressed → stop
        else
        {
            inhaleParticles.Stop();
            exhaleParticles.Stop();
        }
    }
}
