using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPackLogic : MonoBehaviour
{
    private GameManager gameManager;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    private void OnTriggerEnter(Collider collisionInfo)
    {
        if(collisionInfo.gameObject.tag.ToLower() == "player")
        {
            if (gameObject.tag.ToLower() == "left")
            {
                gameManager.IncreaseHealthLeft();
            }
            else
            {
                gameManager.IncreaseHealthRight();
            }
        }
        
    }
}
