using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds2 : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip birdSound2;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        float randomSoundTime = Random.Range(10, 50);
        InvokeRepeating("BirdSounds", 15, randomSoundTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void BirdSounds()
    {
        audioSource.PlayOneShot(birdSound2, 1f);
    }
}
