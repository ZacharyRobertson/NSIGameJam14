using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wasp : Enemy
{

    // Use this for initialization
    protected override void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        spawner = GetComponentInParent<EnemySpawner>();
        player = spawner.player; 
    }

    // Update is called once per frame
    protected override void Update()
    {
        Move();
    }

    protected override void Move()
    {
        rigid.AddForce(Vector3.right * moveSpeed);
    }

    protected override void OnCollisionEnter(Collision hit)
    {
        if(hit.collider.tag == "Player")
        {
            Destroy(hit.gameObject);
        }
    }
}
