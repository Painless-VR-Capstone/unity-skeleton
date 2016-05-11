using UnityEngine;
using System.Collections;

public class KillParticleSystemOnEnd : MonoBehaviour
{
    private ParticleSystem ps;
<<<<<<< HEAD
    public string soundFileName;
=======
>>>>>>> 0a6a02c7630a6a10656409243cf8ba4d103576eb

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
<<<<<<< HEAD
        AudioSource mySource = gameObject.GetComponent<AudioSource>();
        mySource.Stop();
        mySource.clip = Resources.Load("SharedSounds/" + soundFileName) as AudioClip;
        mySource.Play();

=======
>>>>>>> 0a6a02c7630a6a10656409243cf8ba4d103576eb
    }

    void Update()
    {
        if (ps)
        {
            if (!ps.IsAlive())
            {
                Destroy(gameObject);
            }
        }
    }
}