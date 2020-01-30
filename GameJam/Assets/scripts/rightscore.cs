using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rightscore : MonoBehaviour
{
    private GameManager game;
    public Text scoretext;
    // Start is called before the first frame update
    void Start()
    {
        game = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        scoretext.text = "Score: " + game.RightScore;
    }
}
