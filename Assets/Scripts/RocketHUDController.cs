using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RocketHUDController : MonoBehaviour
{
    // Start is called before the first frame update
    public string Text;
    TextMeshProUGUI _text;
    void Awake()
    {
       _text = gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
       
    }

    // Update is called once per frame
    void Update()
    {
        _text.text = Text;
    }

    private void OnValidate()
    {
        var text = gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        text.text = Text;
    }
}
