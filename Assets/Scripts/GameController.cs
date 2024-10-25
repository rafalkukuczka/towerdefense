using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    ScoreTextController _scoreTextController;
    RocketHUDController _rocketController;
    Image _bombHUDImage;
    // Start is called before the first frame update
    void Awake()
    {
        _scoreTextController = GameObject.Find("ui_ScoreText").GetComponent<ScoreTextController>();
        _rocketController = GameObject.Find("ui_rocketHUD").GetComponent<RocketHUDController>();
        _bombHUDImage = GameObject.Find("ui_bombHUD").GetComponent<Image>();
        GameData.Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _scoreTextController.Text = GameData.Score.ToString();
        _rocketController.Text = GameData.CurrentNumberOfRockets.ToString();
        _bombHUDImage.enabled = GameData.EnableBombHUD;
    }
}
