using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wasp : Enemy
{

    // Use this for initialization
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
        transform.position += transform.right * Time.deltaTime * moveSpeed;
        transform.position = transform.position + transform.forward * Mathf.Sin(Time.time * moveSpeed) * 0.5f;

    }

    protected override void OnCollisionEnter(Collision hit)
    {
        if(hit.collider.tag == "Player")
        {
            Destroy(hit.gameObject);
        }
    }
}
