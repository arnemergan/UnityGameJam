using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private AudioSource source;
    public float health;
    public float damage;
    private Animator animator;
    private GameManager game;
    private Transform lastDamaged;
    public GameObject blood;

    // Start is called before the first frame update
    void Start()
    {
        game = FindObjectOfType<GameManager>();
        animator = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Moan();
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
        Instantiate(blood,transform.position,Quaternion.identity);
    }

    void Moan(){
        if(Random.Range(0, 500) == 1){
            source.Play();
        }
    }
}
