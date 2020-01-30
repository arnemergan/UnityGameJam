using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject zombieRight;
    public GameObject zombieLeft;
    public float VisibleAreaX;
    public float VisibleAreaY;
    public float SpawnFieldX;
    public float SpawnFieldY;
    public float ZombieSpawnRateLeft;
    public float ZombieSpawnRateRight;
    public float RavineWidth;
    private float LastSpawnLeft;
    private float LastSpawnRight;
    public float LeftScore;
    public float RightScore;
    public float RightHealth;
    public float LeftHealth;

    private float ZombieX, ZombieY, TempX, TempY;

    //X = 0 is dividing line

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(LastSpawnRight + (1 / ZombieSpawnRateRight) < Time.time){
            
            TempX = Random.Range(0f, SpawnFieldX-RavineWidth/2)/2;
            if(TempX > (VisibleAreaX)/2){
                ZombieX = TempX + RavineWidth/2;
                ZombieY = Random.Range(0f, SpawnFieldY) - SpawnFieldY / 2;//REPLACE 75
                
            }
            else{
                ZombieX = TempX + RavineWidth / 2;
                TempY = Random.Range(0, SpawnFieldY-VisibleAreaY);
                if(TempY > (SpawnFieldY-VisibleAreaY) / 2){
                    ZombieY = VisibleAreaY/2 + TempY - (SpawnFieldY - VisibleAreaY) / 2;
                }
                else{
                    ZombieY = -SpawnFieldY/2 + TempY;
                }
            }

            Instantiate(zombieRight, new Vector3(ZombieX, (float)1.5, ZombieY), new Quaternion());
            
            LastSpawnRight = Time.time;
        }

        if(LastSpawnLeft + (1 / ZombieSpawnRateLeft) < Time.time){
            
            TempX = Random.Range(0f, SpawnFieldX-RavineWidth/2)/2;
            if(TempX > (VisibleAreaX)/2){
                ZombieX = -TempX - RavineWidth / 2;
                ZombieY = Random.Range(0f, SpawnFieldY) - SpawnFieldY / 2;//REPLACE 75
                
            }
            else{
                ZombieX = -TempX - RavineWidth /2;
                TempY = Random.Range(0, SpawnFieldY-VisibleAreaY);
                if(TempY > (SpawnFieldY-VisibleAreaY) / 2){
                    ZombieY = VisibleAreaY/2 + TempY - (SpawnFieldY - VisibleAreaY) / 2;
                }
                else{
                    ZombieY = -SpawnFieldY/2 + TempY;
                }
            }

            Instantiate(zombieLeft, new Vector3(ZombieX, (float)1.5, ZombieY), new Quaternion());
            
            LastSpawnLeft = Time.time;
        }
    }
}
