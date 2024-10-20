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

        if (GameOverScreen.Score > 1000)
        {
            SetActive("Level2Selector", "Image2", true);
        }
        else
        {
            SetActive("Level2Selector", "Image2", false);
        }

        if (GameOverScreen.Score > 2000)
        {
            SetActive("Level3Selector", "Image3", true);
        }
        else
        {
            SetActive("Level3Selector", "Image3", false);
        }

    }

    // Update is called once per frame

    public void OnSelect()
    {
        if (LevelNumber == 0)
            return;

        SceneManager.LoadScene("Level" + LevelNumber.ToString());
    }

    void SetActive(string levelSelectorName, string imageName, bool state)
    {
        var _image = GameObject.Find(imageName).GetComponent<Image>();
        var _button = GameObject.Find(levelSelectorName).GetComponent<Button>();

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
