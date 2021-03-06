﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Stats")]
    public float moveSpeed = 5f;
    public float attackDelay = 1f;
    public int scoreAmount = 10;
    public int health = 1;

    [Header("References")]
    public PlayerScript player;
    public Rigidbody rigid;
    public EnemySpawner spawner;

    // Use this for initialization
    protected virtual void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        //if the player is null
        if (player == null)
            return;

        Move();
    }

    protected virtual void Move()
    {
        rigid.AddForce(Vector3.right * moveSpeed);
    }

    protected virtual void OnCollisionEnter(Collision hit)
    {

    }

}
