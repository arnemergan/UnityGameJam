using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "EnemyTarget"){
            target = other.gameObject.GetComponent<Enemy>();
            target.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
