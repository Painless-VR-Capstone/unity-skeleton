using UnityEngine;
using System.Collections;

public class KillParticleSystemOnEnd : MonoBehaviour
{
    private ParticleSystem ps;
    public string soundFileName;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        AudioSource mySource = gameObject.GetComponent<AudioSource>();
        mySource.Stop();
        mySource.clip = Resources.Load("SharedSounds/" + soundFileName) as AudioClip;
        mySource.Play();

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