using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BulletController : MonoBehaviour
{
    private Enemy target;

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
        if(other.gameObject.tag == "EnemyTarget"){
            target = other.gameObject.GetComponent<Enemy>();
            target.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
