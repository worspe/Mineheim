using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingSound : MonoBehaviour
{
    public AudioClip walkingSound;

    private AudioSource playerAudio;
    private PlayerAnim playerAnimScript;
    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        playerAnimScript = GameObject.Find("Player").GetComponent<PlayerAnim>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && playerAnimScript.isWalking)
        {
            playerAudio.clip = walkingSound;
            playerAudio.Play();
        }
        if (collision.gameObject.CompareTag("Ground") && !playerAnimScript.isWalking)
        {
            playerAudio.Stop();
        }
    }
}
