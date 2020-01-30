using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBoxLogic : MonoBehaviour
{
    public GameObject gun;

    private void OnTriggerEnter(Collider other)
    {
        GunLogic gunLogic = gun.GetComponent<GunLogic>();
        gunLogic.increaseFireRate();

        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Left");
        foreach(GameObject gameObject in gameObjects){
            Destroy(gameObject);
        }
    }
}
