using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreTextController : MonoBehaviour
{

    public string Text;
    // Start is called before the first frame update

    TextMeshProUGUI _textBackgound;
    TextMeshProUGUI _text;

    const string SCORE_PREFIX = "SCore:";
    void Awake()
    {
    //TextMeshGUI Component of ScoreText/Gameobject/TextBackground 
    _textBackgound = transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

    //TextMeshGUI Component of ScoreText/Gameobject/Text
    _text = transform.GetChild(0).gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>();

    }

    private void OnValidate()
    {
        //TextMeshGUI Component of ScoreText/Gameobject/TextBackground 
        var textBackgound = transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

        //TextMeshGUI Component of ScoreText/Gameobject/Text
        var text = transform.GetChild(0).gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>();

        textBackgound.text = SCORE_PREFIX + Text;  //RK TODO move score to const
        text.text = SCORE_PREFIX + Text;
    }

    // Update is called once per frame
    void Update()
    {
        _textBackgound.text = SCORE_PREFIX + Text;
        _text.text = SCORE_PREFIX + Text;
    }
}
