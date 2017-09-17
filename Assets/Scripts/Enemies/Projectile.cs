using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public PlayerScript player;
    public Enemy firingEnemy;
    public Transform target;
    public AudioClip playerHit;
    public AudioSource source;
    public AudiManager aManage;

    // Use this for initialization
    void Awake()
    {
        //Get the player reference from the enemy we are firing from
        firingEnemy = GetComponentInParent<Enemy>();
        player = firingEnemy.player;
        //Get our Audio references
        aManage = GameObject.Find("AudioManager").GetComponent<AudiManager>();
        source = aManage.GetComponent<AudioSource>();
        //playerHit = aManage.clips[index];

        //Get our target and move towards it
        target = player.transform;
        Vector3.MoveTowards(transform.position, target.position, 100);
    }
        
    void OnCollisionEnter(Collision col)
    {
        if(col.collider.tag == "Player")
        {
            Destroy(col.gameObject);
            //PLay the sound
            source.PlayOneShot(playerHit);
        }
    }
}
