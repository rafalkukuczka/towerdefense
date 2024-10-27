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
    Image _bombHUDImage;
    // Start is called before the first frame update
    void Awake()
    {
        _scoreTextController = GameObject.Find("ui_ScoreText").GetComponent<ScoreTextController>();
        _rocketHUDController = GameObject.Find("ui_rocketHUD").GetComponent<RocketHUDController>();
        _bombHUDImage = GameObject.Find("ui_bombHUD").GetComponent<Image>();

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
    _bombHUDImage.enabled = GameData.BombCount>0;
    }
}
