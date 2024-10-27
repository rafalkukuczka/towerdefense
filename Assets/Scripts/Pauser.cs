using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Pauser : MonoBehaviour
{
    private int paused = 0;


    //RK New Input
    PlayerActionsExample playerInput;

    private void Awake()
    {
        playerInput = new PlayerActionsExample();
    }


    // Update is called once per frame
    void Update()
    {
        //RK New input
        //if(Input.GetKeyUp(KeyCode.P))
        if (playerInput.Player.Pause.triggered)
        {
            paused++;

        }

        if (paused % 3 == 0)
        {
            Time.timeScale = 1;
        }
        else if (paused % 3 == 1)
        {
            Time.timeScale = 0;

            if (GameData.IsSlowMotion())
            {
                Time.timeScale = 0.1f;
                Time.fixedDeltaTime = 0.02F * Time.timeScale;
            }
        }
        else if (paused % 3 == 2)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("MainMenu");
        }
    }

        private void OnEnable()
        {
            playerInput.Enable();
        }

        private void OnDisable()
        {
            playerInput.Disable();
        }
    }
