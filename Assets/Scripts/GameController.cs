using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    ScoreTextController _scoreTextController;
    RocketHUDController _rocketHUDController;
    BombHUDController _bombHUDController;
    void Awake()
    {
        _scoreTextController = GameObject.Find("ui_ScoreText").GetComponent<ScoreTextController>();
        
        _rocketHUDController = GameObject.Find("ui_rocketHUD").GetComponent<RocketHUDController>();

        _bombHUDController = GameObject.Find("ui_bombHUD").GetComponent<BombHUDController>();

        //initial
        if (!GameData.WasShoped)
        {
            GameData.Init(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    //Sync Data with controls
    _scoreTextController.Text = GameData.Score.ToString();

    _rocketHUDController.Text = GameData.CurrentNumberOfRockets.ToString();
    _rocketHUDController.Visible = GameData.CurrentNumberOfRockets>0;

    _bombHUDController.Text = GameData.BombCount.ToString();
    _bombHUDController.Visible = GameData.BombCount > 0;
    }
}
