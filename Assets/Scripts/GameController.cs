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
    private bool extraForceTimerStarted;
    private bool extraSpeedTimerStarted;

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
        _rocketHUDController.Visible = GameData.CurrentNumberOfRockets > 0;

        _bombHUDController.Text = GameData.BombCount.ToString();
        _bombHUDController.Visible = GameData.BombCount > 0;


        if (GameData.ExtraForceTimeout != 0 && !extraForceTimerStarted)
        {
            extraForceTimerStarted = true;
            StartCoroutine(ExtraForceTimer());
            
        }

        if (GameData.ExtraSpeedTimeout != 0 && !extraSpeedTimerStarted)
        {
            extraSpeedTimerStarted = true;
            StartCoroutine(ExtraSpeedTimer());
            
        }
    }


    IEnumerator ExtraForceTimer()
    {
        UnityEngine.Debug.Log("GameController.ExtraForceTimer started...");

        while (GameData.ExtraForceTimeout-- > 0)
        {
            UnityEngine.Debug.Log("Tick " + GameData.ExtraForceTimeout + " sec");
            yield return new WaitForSeconds(1);
        }

        UnityEngine.Debug.Log("...GameController.ExtraForceTimer ended");
    }

    IEnumerator ExtraSpeedTimer()
    {
        UnityEngine.Debug.Log("GameController.ExtraSpeedTimer started...");

        while (GameData.ExtraSpeedTimeout-- > 0)
        {
            UnityEngine.Debug.Log("Tick " + GameData.ExtraSpeedTimeout + " sec");
            yield return new WaitForSeconds(1);
        }

        UnityEngine.Debug.Log("...GameController.ExtraSpeedTimer ended");
    }

}
