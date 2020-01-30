using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    public float damage;
    private Animator animator;
    private GameManager game;
    private Transform lastDamaged;

    // Start is called before the first frame update
    void Start()
    {
        game = FindObjectOfType<GameManager>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage,Transform player){
        lastDamaged = player;
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
        if(lastDamaged.tag == "bulletA"){
            game.RightScore = game.RightScore + 10;
        }else if(lastDamaged.tag == "bulletB"){
            game.LeftScore = game.LeftScore + 10;
        }
        Destroy(gameObject);
    }
}
