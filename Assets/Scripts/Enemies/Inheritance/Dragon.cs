using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : Enemy
{
    [Header("Dragon")]
    public bool isAttacking;
    public GameObject fireball;
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
        if(player != null && !isAttacking)
        {
            StartCoroutine(Attack());
        }

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
        Instantiate(fireball, firePoint.position, firePoint.rotation, transform);
        yield return new WaitForSeconds(1.5f);
        //Reset our bool
        isAttacking = false;
    }
}
