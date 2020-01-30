using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftGunBoxLogic : MonoBehaviour
{
    public GameObject gun;
    public GunLogic gunLogic;

    private void Start()
    {
        gun = GameObject.Find("SciFiRifleRight");
        gunLogic = gun.GetComponent<GunLogic>();
    }

    private void OnTriggerEnter(Collider collisionInfo)
    {
        if (collisionInfo.gameObject.tag.ToLower() == "player")
        {
            gunLogic.increaseFireRate();
        }

    }
}
