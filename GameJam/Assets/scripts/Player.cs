using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float health;
    public float damage;
    public float damagePerSecond;
    private float lastTimeDamaged;
    private GameManager game;
    private Actions actions;
    // Start is called before the first frame update
    void Start()
    {
        game = FindObjectOfType<GameManager>();
        actions = GetComponent<Actions>();
        game.LeftHealth = health;
        game.RightHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage, Transform player){
        if(lastTimeDamaged + 1 / damagePerSecond < Time.time){
            if(health <= 0){
                Death(player);
            }else{
                health = health - damage;
                if(player.name == "soldier1"){
                    game.RightHealth = health;
                }else if(player.name == "soldier2"){
                    game.LeftHealth = health;
                }
                actions.Damage();
                if(health <= 0){
                    Death(player);
                }
            }
            lastTimeDamaged = Time.time;                     
        }
    }

    void Death(Transform player){
        if(player.name == "soldier1"){
             game.RightHealth = health;
         }else if(player.name == "soldier2"){
            game.LeftHealth = health;
         }
        actions.Death();
        //animator.SetTrigger("Death");
    }
}
