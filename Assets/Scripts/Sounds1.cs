using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds1 : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip birdSound;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        float randomSoundTime = Random.Range(20, 60);
        InvokeRepeating("BirdSounds", 5, randomSoundTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BirdSounds()
    {
        audioSource.PlayOneShot(birdSound, 1f);
    }
}
