using UnityEngine;
using System.Collections;

public class Pauser : MonoBehaviour {
	private bool paused = false;


	//RK New Input
	PlayerActionsExample playerInput;

    private void Awake()
    {
		playerInput = new PlayerActionsExample();
    }


    // Update is called once per frame
    void Update () {
		//RK New input
		//if(Input.GetKeyUp(KeyCode.P))
		if (playerInput.Player.Pause.triggered)
		{
			paused = !paused;
		}

		if (paused)
		{
			
			Time.timeScale = 0;

            if (GameData.IsSlowMotion())
            {
                Time.timeScale = 0.1f;
                Time.fixedDeltaTime = 0.02F * Time.timeScale;
            }
        }
		else
			Time.timeScale = 1;
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
