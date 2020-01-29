using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float health;
    public float damage;
    public float damagePerSecond;
    private float lastTimeDamaged;
    private Actions actions;
    // Start is called before the first frame update
    void Start()
    {
        actions = GetComponent<Actions>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage){
        if(lastTimeDamaged + 1 / damagePerSecond < Time.time){
            Debug.Log(damage);
            if(health <= 0){
                Death();
            }else{
                health = health - damage;
                actions.Damage();
                if(health <= 0){
                    Death();
                }
            }
            lastTimeDamaged = Time.time;                     
        }
    }

    void Death(){
        actions.Death();
        //animator.SetTrigger("Death");
    }
}
