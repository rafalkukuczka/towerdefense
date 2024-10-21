using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public int LevelNumber;

    // Start is called before the first frame update
    void Start()
    {

        //SetActive("Level1Selector", "Image1", true);

        if (GameOverScreenData.Score > 1000)
        {
            SetActive(2, true);
        }
        else
        {
            SetActive(2, false);
        }

        if (GameOverScreenData.Score > 2000)
        {
            SetActive(3, true);
        }
        else
        {
            SetActive(3, false);
        }

        //RK DEBUG SetActive(4, true);
        if (GameOverScreenData.Score > 3000)
        {
            SetActive(4, true);
        }
        else
        {
            SetActive(4, false);
        }

    }

    // Update is called once per frame

    public void OnSelect()
    {
        if (LevelNumber == 0)
            return;

        SceneManager.LoadScene("Level" + LevelNumber.ToString());
    }

    void SetActive(int levelIdx, bool state)
    {
        var _image = GameObject.Find("Image"+levelIdx).GetComponent<Image>();
        var _button = GameObject.Find("Level"+levelIdx+"Selector").GetComponent<Button>();

        if (state)
        {
            _image.color = Color.white;
            _button.interactable = true;
        }
        else
        {
            _image.color = Color.grey;
            _button.interactable = false;
        }

        
    }
}
