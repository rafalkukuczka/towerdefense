using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RocketHUDController : MonoBehaviour
{
    // Start is called before the first frame update
    public string Text;
    private TextMeshProUGUI _backgroundText;
    private TextMeshProUGUI _text;
    void Awake()
    {
        _backgroundText = gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        _text = gameObject.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
       
    }

    // Update is called once per frame
    void Update()
    {
        _backgroundText.text = Text;
        _text.text = Text;
    }

    private void OnValidate()
    {
        var backgroundText = gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        var text = gameObject.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();

        backgroundText.text = Text;
        text.text = Text;
    }
}
