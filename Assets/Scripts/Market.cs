using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Market : MonoBehaviour
{
    public bool onShopRange;

    [SerializeField] GameObject pressE;
    [SerializeField] GameObject shop;

    [SerializeField] bool onRange;

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Shop Canvas"))
        {
            onShopRange = true;
        } else {
            onShopRange = false;
        }

        if (onRange && Input.GetKeyDown(KeyCode.E))
        {
            shop.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
        }
        else if (!onRange)
        {
            Cursor.lockState = CursorLockMode.Locked;
            shop.gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pressE.SetActive(true);
            onRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pressE.SetActive(false);
            onRange = false;
        }
    }
}
