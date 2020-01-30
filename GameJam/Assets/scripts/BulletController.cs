using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BulletController : MonoBehaviour
{
    private Enemy target;
    public Transform Bullet;
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Math.Abs(transform.position.x) > 260 || Math.Abs(transform.position.y) > 160){
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other) {
        if(Bullet.tag == "bulletB"){
            if(other.gameObject.tag == "EnemyTargetB"){
                target = other.gameObject.GetComponent<Enemy>();
                target.TakeDamage(damage,Bullet);
            }else{
                Destroy(gameObject);
            }
        }else if(Bullet.tag == "bulletA"){
            if(other.gameObject.tag == "EnemyTarget"){
                target = other.gameObject.GetComponent<Enemy>();
                target.TakeDamage(damage,Bullet);
            }else{
                Destroy(gameObject);
            }
        }
    }
}
