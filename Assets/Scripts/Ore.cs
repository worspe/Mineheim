using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ore : MonoBehaviour
{
    private MineCollect playerScript;
    private SpawnM spawnManager;
    private PlayerAnim playerAnim;
    private AudioSource playerAudio;

    public AudioClip miningSound;

    public Slider healthBar;
    public int oreValue;
    public int hitToBreak;
    public bool isTrigger;


    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<MineCollect>();
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnM>();
        playerAnim = GameObject.Find("Player").GetComponent<PlayerAnim>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = hitToBreak;
    }

    private void OnTriggerEnter(Collider other)
    {
        // 1'st Pickaxe settings and collect money
        if (other.gameObject.CompareTag("Pickaxe") && playerAnim.isMining && hitToBreak <= 1)
        {
            playerScript.money += oreValue;
            playerScript.isMineBroken = true;
            StartCoroutine(Wait());
        }
        if (other.gameObject.CompareTag("Pickaxe") && playerAnim.isMining && hitToBreak > 0)
        {
            StartCoroutine(Wait2());
            //StartCoroutine(MiningSound());
            playerAudio.PlayOneShot(miningSound, 0.65f);
        }

        // 2'nd Pickaxe setting sand collect money
        if (other.gameObject.CompareTag("Pickaxe2") && playerAnim.isMining && hitToBreak > 0)
        {
            StartCoroutine(Wait3());
            //StartCoroutine(MiningSound());
            playerAudio.PlayOneShot(miningSound, 0.5f);
        }
        if (other.gameObject.CompareTag("Pickaxe2") && playerAnim.isMining && hitToBreak <= 2)
        {
            playerScript.money += oreValue;
            playerScript.isMineBroken = true;
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.53f);
        Destroy(gameObject);
        spawnManager.oreCount -= 1;
        playerAnim.isMining = false;
    }
    IEnumerator Wait2()
    {
        yield return new WaitForSeconds(0.1f);
        hitToBreak -= 1;       
    } IEnumerator Wait3()
    {
        yield return new WaitForSeconds(0.1f);
        hitToBreak -= 2;
    }
    IEnumerator MiningSound()
    {
        yield return new WaitForSeconds(0.4f);
        playerAudio.PlayOneShot(miningSound, 0.5f);
    }
}
