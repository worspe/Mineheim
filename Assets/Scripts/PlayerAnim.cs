using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAnim : MonoBehaviour
{
    public AudioClip[] hitSounds;
    private Animator animationPlayer;
    private Market marketScript;
    private AudioSource playerAudio;

    public bool isWalking;
    public bool isMining;
    // Start is called before the first frame update
    void Start()
    {
        marketScript = GameObject.Find("Shop").GetComponent<Market>();
        animationPlayer = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        isMining = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)&& isMining == false)
        {
            animationPlayer.SetBool("RunF", true);
            isWalking = true;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            animationPlayer.SetBool("RunF", false);
            isWalking = false;
        }

        if (Input.GetKey(KeyCode.S) && isMining == false)
        {
            animationPlayer.SetBool("RunB", true);
            isWalking = true;
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            animationPlayer.SetBool("RunB", false);
            isWalking = false;
        }

        if (Input.GetKey(KeyCode.D) && isMining == false)
        {
            animationPlayer.SetBool("RunR", true);
            isWalking = true;
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            animationPlayer.SetBool("RunR", false);
            isWalking = false;
        }

        if (Input.GetKey(KeyCode.A) && isMining == false)
        {
            animationPlayer.SetBool("RunL", true);
            isWalking = true;
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            animationPlayer.SetBool("RunL", false);
            isWalking = false;
        }

        if (Input.GetButtonDown("Fire1") && !isMining && !marketScript.onShopRange)
        {
            isMining = true;
            animationPlayer.SetBool("RunMining", true);
            animationPlayer.SetBool("Mining", true);
            PlayHitSounds();
            StartCoroutine(Mining());
        }
        if (Input.GetButtonUp("Fire1"))
        {
            
        }

        if (Input.GetKeyDown(KeyCode.D) && Input.GetKeyDown(KeyCode.A))
        {
            animationPlayer.SetBool("RunF", false);
        }
    }

    IEnumerator Mining() 
    {
        yield return new WaitForSeconds(0.8f);
        animationPlayer.SetBool("Mining", false);
        yield return new WaitForSeconds(0.3f);
        isMining = false;

    }

    private void PlayHitSounds()
    {
        int randomIndex = Random.Range(0, hitSounds.Length);

        playerAudio.clip = hitSounds[randomIndex];
        playerAudio.PlayDelayed(0.4f);
    }
}
