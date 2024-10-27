using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ForceHUDController : MonoBehaviour
{
    // Start is called before the first frame update
    public string Text;
    public bool Visible;

    private TextMeshProUGUI _backgroundText;
    private TextMeshProUGUI _text;
    private Image _Image;

    void Awake()
    {
        _Image = this.transform.GetComponent<Image>();
        _backgroundText = gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        _text = gameObject.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        _backgroundText.text = Text;
        _text.text = Text;

        _Image.enabled = Visible;
        _text.enabled = Visible;
        _backgroundText.enabled = Visible;
    }

    private void OnValidate()
    {
        var backgroundText = gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        var text = gameObject.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();

        backgroundText.text = Text;
        text.text = Text;
    }
}
