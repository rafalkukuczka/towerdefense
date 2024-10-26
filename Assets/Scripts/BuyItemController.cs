using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

[ExecuteAlways]
public class BuyItemController : MonoBehaviour
{
    public Sprite ButtonSprite;

    public string ItemName;
    public int ItemPrice;
    public Color disabledColor = Color.gray; 

    Button _button;
    UnityEngine.UI.Image _image;
    TextMeshProUGUI _textBox;
    // Start is called before the first frame update
    void Awake()
    {

        _textBox = this.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

        _image = this.gameObject.transform.GetChild(1).GetComponent<UnityEngine.UI.Image>();

        _button = this.gameObject.transform.GetComponent<Button>();

        _textBox.text = ItemPrice.ToString();

        _image.sprite = ButtonSprite;
    }

    private void OnValidate()
    {
        TextMeshProUGUI textBox = this.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

        textBox.text = ItemPrice.ToString();

        UnityEngine.UI.Image image = this.gameObject.transform.GetChild(1).GetComponent<UnityEngine.UI.Image>();

        image.sprite = ButtonSprite;


    }

    // Update is called once per frame

    public void OnSelect()
    {
        StartCoroutine(OnClick());
    }

    IEnumerator OnClick()
    {

        _image.color = disabledColor;

        yield return new WaitForSeconds(1);

        _image.color = Color.white;

        yield return new WaitForSeconds(1);

        //SceneManager.LoadScene(ItemName);

        yield return null;
    }

    public void SetActive(bool state)
    {


        if (state)
        {
            _textBox.color = Color.white;
            _image.color = Color.white;
            _button.interactable = true;
        }
        else
        {
            _textBox.color = Color.gray;
            _image.color = Color.grey;
            _button.interactable = false;
        }


    }
}
