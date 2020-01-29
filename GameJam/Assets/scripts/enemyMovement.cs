﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyMovement : MonoBehaviour
{
    public float lookRadius = 10;

    public Transform target;

    public Enemy enemy;
    NavMeshAgent navMesh;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Enemy>();
        navMesh = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy.health > 0){
            float distance = Vector3.Distance(target.position,transform.position);
            if(distance <= lookRadius){
                navMesh.SetDestination(target.position);
                if(distance <= navMesh.stoppingDistance){
                    //do damage to player
                    Player player = target.GetComponent<Player>();
                    player.TakeDamage(enemy.damage);
                    Debug.Log("damage");
                }
            }
        }
    }
}
