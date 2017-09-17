using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : Enemy
{
    [Header("Frog")]
    public float jumpForce = 1.5f;
    public bool canJump;

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
        if (transform.position.y <= 1.5)
            canJump = true;


        if(canJump)
        {
            StartCoroutine(Jump());
        }
    }

    protected override void Move()
    {
        transform.position += transform.right * Time.deltaTime * moveSpeed;
        

    }

    protected override void OnCollisionEnter(Collision hit)
    {
        if (hit.collider.tag == "Player")
        {
            Destroy(hit.gameObject);
        }
    }

    IEnumerator Jump()
    {
        rigid.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        canJump = false;
        yield return new WaitForSeconds(2);
    }
}
