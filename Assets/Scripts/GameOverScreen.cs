using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
//using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameOverScreen : MonoBehaviour
{
    internal TextMeshProUGUI _textMeshPro;
    void Awake()
    {
        _textMeshPro = gameObject.transform.Find("PointsText").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        _textMeshPro.text = GameData.Text;
    }
}
