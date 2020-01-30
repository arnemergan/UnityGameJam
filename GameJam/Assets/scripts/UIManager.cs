using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private GameManager Game;
    public RectTransform LeftHealth;
    public RectTransform RightHealth;
    public Text LeftScoreText;
    public Text RightScoreText;
    public Text LeftStatusMessage;
    public Text RightStatusMessage;
    private float TimeOfLeftUpdate;
    private float TimeOfRightUpdate;
    // Start is called before the first frame update
    void Start()
    {
        Game = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        LeftHealth.sizeDelta = new Vector2(Game.LeftHealth / 2, 40);
        RightHealth.sizeDelta = new Vector2(Game.RightHealth / 2, 40);
        LeftScoreText.text = "Score: " + Game.LeftScore;
        RightScoreText.text = "Score: " + Game.RightScore;

        if(TimeOfLeftUpdate + 5 < Time.time)
            ClearLeftStatus();

        if (TimeOfRightUpdate + 5 < Time.time)
            ClearRightStatus();
    }

    public void SetLeftStatus(string message)
    {
        TimeOfLeftUpdate = Time.time;
        LeftStatusMessage.text = message;
    }

    public void SetRightStatus(string message)
    {
        TimeOfRightUpdate = Time.time;
        RightStatusMessage.text = message;
    }

    void ClearLeftStatus()
    {
        LeftStatusMessage.text = "";
    }

    void ClearRightStatus()
    {
        RightStatusMessage.text = "";
    }
}
