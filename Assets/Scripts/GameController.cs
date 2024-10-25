using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    ScoreTextController _textController;
    // Start is called before the first frame update
    void Awake()
    {
        _textController = GameObject.Find("ui_ScoreText").GetComponent<ScoreTextController>();
        GameData.Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _textController.Text = GameData.Score.ToString();
    }
}
