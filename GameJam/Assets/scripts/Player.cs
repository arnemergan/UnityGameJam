using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float health;
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        
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
        //animator.SetTrigger("Death");
    }
}
