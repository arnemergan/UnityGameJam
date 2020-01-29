using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    public float damage;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage){
        if(health <= 0){
            Death();
        }else{
            health = health - damage;
            if(health <= 0){
                Death();
            }
        }
    }

    void Death(){
        Destroy(gameObject);
    }
}
