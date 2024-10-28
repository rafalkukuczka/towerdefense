using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsLeftTextController : MonoBehaviour
{

    public string Text;
    // Start is called before the first frame update

    TextMeshProUGUI _textBackgound;
    TextMeshProUGUI _text;

    const string TEXT_PREFIX = "";
    void Awake()
    {
    //TextMeshGUI Component of /Gameobject/TextBackground 
    _textBackgound = transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

    //TextMeshGUI Component of /Gameobject/Text
    _text = transform.GetChild(0).gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>();

    }

    private void OnValidate()
    {
        //TextMeshGUI Component of /Gameobject/TextBackground 
        var textBackgound = transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

        //TextMeshGUI Component of /Gameobject/Text
        var text = transform.GetChild(0).gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>();

        textBackgound.text = TEXT_PREFIX + Text;  //RK TODO move score to const
        text.text = TEXT_PREFIX + Text;
    }

    // Update is called once per frame
    void Update()
    {
        _textBackgound.text = TEXT_PREFIX + Text;
        _text.text = TEXT_PREFIX + Text;
    }
}
