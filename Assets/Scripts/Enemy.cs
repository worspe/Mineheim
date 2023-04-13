using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 1.3f;
    private Rigidbody enemyRigidB;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        enemyRigidB = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float enemyX = player.transform.position.x - transform.position.x;
        float enemyZ = player.transform.position.z - transform.position.z;

        Vector3 enemyMove = new Vector3(enemyX, 0, enemyZ).normalized;
        enemyRigidB.AddForce((enemyMove).normalized * speed, ForceMode.Acceleration);
    }
}
