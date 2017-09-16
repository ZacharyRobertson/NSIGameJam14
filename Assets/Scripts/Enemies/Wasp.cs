using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wasp : Enemy
{

    // Use this for initialization
    protected override void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        player = GameObject.Find("Player").GetComponent<Player>();
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
}
