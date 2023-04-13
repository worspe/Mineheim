using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MineCollect : MonoBehaviour
{
    //private Rigidbody playerRb;

    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI moneyText2;
    public Image inventory;
    public int money;
    public bool isMineBroken;

    private bool isInvOpen;

    // Start is called before the first frame update
    void Start()
    {
        //playerRb = GetComponent<Rigidbody>();
        isInvOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            inventory.gameObject.SetActive(true);
            isInvOpen = true;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && isInvOpen == true)
        {
            inventory.gameObject.SetActive(false);
        }

        moneyText.text = "" + money;
        moneyText2.text = "" + money;
    }
    public IEnumerator WaitMine()
    {
        yield return new WaitForSeconds(1);
        isMineBroken = false;
    }
}
