using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightGunBoxLogic : MonoBehaviour
{
    public GameObject gun;
    public GunLogic gunLogic;
    private GameManager gameManager;
    private UIManager UIcomponent;
    private void Start()
    {
        gun = GameObject.Find("SciFiRifleRight");
        gunLogic = gun.GetComponent<GunLogic>();
        gameManager = FindObjectOfType<GameManager>();
        UIcomponent = gameManager.GetComponent<UIManager>();
    }

    private void OnTriggerEnter(Collider collisionInfo)
    {
        if (collisionInfo.gameObject.tag.ToLower() == "player")
        {
            gunLogic.increaseFireRate();
            UIcomponent.SetRightStatus("Increased fire rate");
        }

    }
}
