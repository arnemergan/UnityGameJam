using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject zombieRight;
    public GameObject zombieLeft;
    public GameObject ZombieBoxLeft;
    public GameObject GunBoxLeft;
    public GameObject HealthPackLeft;
    public GameObject ZombieBoxRight;
    public GameObject GunBoxRight;
    public GameObject HealthPackRight;
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
    public float ZombieSpawnIncrease;
    private float LastUpgradeScoreLeft = 0;
    private float LastUpgradeScoreRight = 0;
    private float LastIncrease = 0;

    private float ZombieX, ZombieY, TempX, TempY;

    //X = 0 is dividing line

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        IncreaseSpawnrate();
        SpawnZombies();
        SpawnCrates();
    }

    void SpawnZombies()
    {
        if (LastSpawnRight + (1 / ZombieSpawnRateRight) < Time.time)
        {

            TempX = Random.Range(0f, SpawnFieldX - RavineWidth / 2) / 2;
            if (TempX > (VisibleAreaX) / 2)
            {
                ZombieX = TempX + RavineWidth / 2;
                ZombieY = Random.Range(0f, SpawnFieldY) - SpawnFieldY / 2;

            }
            else
            {
                ZombieX = TempX + RavineWidth / 2;
                TempY = Random.Range(0, SpawnFieldY - VisibleAreaY);
                if (TempY > (SpawnFieldY - VisibleAreaY) / 2)
                {
                    ZombieY = VisibleAreaY / 2 + TempY - (SpawnFieldY - VisibleAreaY) / 2;
                }
                else
                {
                    ZombieY = -SpawnFieldY / 2 + TempY;
                }
            }

            Instantiate(zombieRight, new Vector3(ZombieX, (float)1.5, ZombieY), new Quaternion());

            LastSpawnRight = Time.time;
        }

        if (LastSpawnLeft + (1 / ZombieSpawnRateLeft) < Time.time)
        {

            TempX = Random.Range(0f, SpawnFieldX - RavineWidth / 2) / 2;
            if (TempX > (VisibleAreaX) / 2)
            {
                ZombieX = -TempX - RavineWidth / 2;
                ZombieY = Random.Range(0f, SpawnFieldY) - SpawnFieldY / 2;

            }
            else
            {
                ZombieX = -TempX - RavineWidth / 2;
                TempY = Random.Range(0, SpawnFieldY - VisibleAreaY);
                if (TempY > (SpawnFieldY - VisibleAreaY) / 2)
                {
                    ZombieY = VisibleAreaY / 2 + TempY - (SpawnFieldY - VisibleAreaY) / 2;
                }
                else
                {
                    ZombieY = -SpawnFieldY / 2 + TempY;
                }
            }

            Instantiate(zombieLeft, new Vector3(ZombieX, (float)1.5, ZombieY), new Quaternion());

            LastSpawnLeft = Time.time;
        }
    }

    void SpawnCrates()
    {

        
        if (LeftScore%250 == 0 && LeftScore != LastUpgradeScoreLeft)
        {
            LastUpgradeScoreLeft = LeftScore;

            TempX = Random.Range(0, VisibleAreaX / 2 - RavineWidth / 2) + RavineWidth / 2;
            TempY = Random.Range(10, VisibleAreaY - 10) - VisibleAreaY / 2;
            Instantiate(HealthPackLeft, new Vector3(-TempX, (float)1.5, TempY), new Quaternion());

            TempX = Random.Range(0, VisibleAreaX / 2 - RavineWidth / 2) + RavineWidth / 2;
            TempY = Random.Range(10, VisibleAreaY - 10) - VisibleAreaY / 2;
            Instantiate(GunBoxLeft, new Vector3(-TempX, (float)1.5, TempY), new Quaternion());

            TempX = Random.Range(0, VisibleAreaX / 2 - RavineWidth / 2) + RavineWidth / 2;
            TempY = Random.Range(10, VisibleAreaY - 10) - VisibleAreaY / 2;
            Instantiate(ZombieBoxLeft, new Vector3(-TempX, (float)1.5, TempY), new Quaternion());
        }

        if (RightScore % 250 == 0 && RightScore != LastUpgradeScoreRight)
        {
            LastUpgradeScoreRight = RightScore;

            TempX = Random.Range(0, VisibleAreaX / 2 - RavineWidth / 2) + RavineWidth / 2;
            TempY = Random.Range(10, VisibleAreaY - 10) - VisibleAreaY / 2;
            Instantiate(HealthPackRight, new Vector3(TempX, (float)1.5, TempY), new Quaternion());

            TempX = Random.Range(0, VisibleAreaX / 2 - RavineWidth / 2) + RavineWidth / 2;
            TempY = Random.Range(10, VisibleAreaY - 10) - VisibleAreaY / 2;
            Instantiate(GunBoxRight, new Vector3(TempX, (float)1.5, TempY), new Quaternion());

            TempX = Random.Range(0, VisibleAreaX / 2 - RavineWidth / 2) + RavineWidth / 2;
            TempY = Random.Range(10, VisibleAreaY - 10) - VisibleAreaY / 2;
            Instantiate(ZombieBoxRight, new Vector3(TempX, (float)1.5, TempY), new Quaternion());
        }
    }

    private void IncreaseSpawnrate()
    {
        if(LastIncrease + ZombieSpawnIncrease < Time.time)
        {
            LastIncrease = Time.time;
            ZombieSpawnRateLeft += 0.5f;
            ZombieSpawnRateRight += 0.5f;
        }
    }

    public void IncreaseSpawnRateLeft()
    {
        ZombieSpawnRateLeft += 0.5f;
    }

    public void IncreaseSpawnRateRight()
    {
        ZombieSpawnRateLeft += 0.5f;
    }

    public void IncreaseHealthLeft()
    {
        LeftHealth += 250;
        if(LeftHealth > 1000)
        {
            LeftHealth = 1000;
        }
    }

    public void IncreaseHealthRight()
    {
        RightHealth += 250;
        if (RightHealth > 1000)
        {
            RightHealth = 1000;
        }
    }
}
