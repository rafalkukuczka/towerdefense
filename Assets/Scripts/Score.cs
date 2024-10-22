using UnityEngine;
using System.Collections;
using TMPro;

public class Score : MonoBehaviour
{
	public int score = 0;					// The player's score.


	private PlayerControl playerControl;	// Reference to the player control script.
	private int previousScore = 0;			// The score in the previous frame.

	TextMeshProUGUI _scoreText;
	void Awake ()
	{
		// Setting up the reference.
		playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
        _scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
	}


	void Update ()
	{
		// Set the score text.
		//RK TODO
		_scoreText.text = "Score: " + score;
		GameData.SetScore(score);

		// If the score has changed...
		if(previousScore != score && playerControl != null)
			// ... play a taunt.
			playerControl.StartCoroutine(playerControl.Taunt());

		// Set the previous score to this frame's score.
		previousScore = score;
	}

}
