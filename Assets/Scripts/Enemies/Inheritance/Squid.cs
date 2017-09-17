using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squid : Enemy
{
    [Header("Squid")]
    public bool isAttacking;
    public GameObject inkBall;
    public Transform firePoint;

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
    IEnumerator Attack()
    {
        //Set our bool for attacking
        isAttacking = true;
        Instantiate(inkBall, firePoint.position, firePoint.rotation, transform);
        yield return new WaitForSeconds(1.5f);
        //Reset our bool
        isAttacking = false;
    }
}
