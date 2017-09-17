using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : Enemy
{

    protected override void Awake()
    {
        //Set our references
        rigid = GetComponent<Rigidbody>();
        spawner = GetComponentInParent<EnemySpawner>();
        //Get our Player reference from the Spawner
        player = spawner.player;
    }

    // Update is called once per frame
    protected override void Update()
    {
        Move();

    }

    protected override void Move()
    {
        if (player != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
        }
    }

    protected override void OnCollisionEnter(Collision hit)
    {
        if (hit.collider.tag == "Player")
        {
            Destroy(hit.gameObject);
            Destroy(gameObject);
        }
    }
}
