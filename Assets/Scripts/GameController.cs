using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    ScoreTextController _scoreTextController;
    RocketHUDController _rocketController;
    // Start is called before the first frame update
    void Awake()
    {
        _scoreTextController = GameObject.Find("ui_ScoreText").GetComponent<ScoreTextController>();
        _rocketController = GameObject.Find("ui_rocketHUD").GetComponent<RocketHUDController>();
        GameData.Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _scoreTextController.Text = GameData.Score.ToString();
        _rocketController.Text = GameData.CurrentNumberOfRockets.ToString();
    }
}
