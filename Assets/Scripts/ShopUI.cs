using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    public GameObject shopUI;
    public Button pickaxeBuy;
    public Button speedBuy;
    public Button shopExit;

    public GameObject pickaxeDeafult;
    public GameObject pickaxe2;

    private MineCollect mineCollect;
    private ThirdPersonMovement thirdPersonScript;

    // Start is called before the first frame update
    void Start()
    {
        pickaxeBuy = GetComponent<Button>();
        pickaxeBuy.onClick.AddListener(OnClick);
        speedBuy.onClick.AddListener(OnClickSpeed);
        shopExit.onClick.AddListener(OnClickExit);
        mineCollect = GameObject.Find("Player").GetComponent<MineCollect>();
        thirdPersonScript = GameObject.Find("ThirdPersonCharacter").GetComponent<ThirdPersonMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnClick()
    {
        if(mineCollect.money >= 5000)
        {
            pickaxeBuy.gameObject.SetActive(false);
            mineCollect.money -= 5000;
            pickaxeDeafult.SetActive(false);
            pickaxe2.SetActive(true);
        }

    }
    void OnClickExit()
    {
        shopUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
    void OnClickSpeed()
    {
        if(mineCollect.money >= 500)
        {
            speedBuy.gameObject.SetActive(false);
            mineCollect.money -= 500;
            thirdPersonScript.speed *= 1.5f;
        }
    }
}
