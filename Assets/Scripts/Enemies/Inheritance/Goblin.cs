using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Enemy
{

    protected override void Awake()
    {
        //Set our references
        rigid = GetComponent<Rigidbody>();
        spawner = GetComponentInParent<EnemySpawner>();
        //Get our Player reference from the Spawner
        player = spawner.player;
        //Set our object to be destroyed if too much time passes
        Destroy(gameObject, 15f);
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
        if (hit.collider.tag == "Player")
        {
            Destroy(hit.gameObject);
        }

    }
}
