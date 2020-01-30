using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healtleft : MonoBehaviour
{
    private GameManager game;
    public RectTransform health;
    // Start is called before the first frame update
    void Start()
    {
        game = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        health.sizeDelta = new Vector2(game.LeftHealth / 2,40);
    }
}
