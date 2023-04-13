using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    void LateUpdate()
    {
        transform.LookAt(GameObject.Find("CM FreeLook2").transform);
    }
}
