﻿//RK Test first change /RK
//RK Test sec. change /RK
//RK Test third change /RK

using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using System;

public class PlayerControl : MonoBehaviour
{
	[HideInInspector]
	public bool facingRight = true;			// For determining which way the player is currently facing
    [HideInInspector]
    public bool jump100Percents = false;    // Condition for whether the player should jump for first time.
	public bool jump50Percents = false;    // Condition for whether the player should jump for sec time.
    private int  jumped50PercentTimes = 0;  // How many times jumped, 0 indexed 0==1, 1==2 etc.

    public float moveForce = 365f;			// Amount of force added to move the player left and right.
	public float maxSpeed = 5f;				// The fastest the player can travel in the x axis.
    public float speedMultiplikator = 1;
	public AudioClip[] jumpClips;			// Array of clips for when the player jumps.
	public float jumpForce = 1000f;			// Amount of force added when the player jumps.
	public AudioClip[] taunts;				// Array of clips for when the player taunts.
	public float tauntProbability = 50f;	// Chance of a taunt happening.
	public float tauntDelay = 1f;			// Delay for when the taunt should happen.


	private int tauntIndex;					// The index of the taunts array indicating the most recent taunt.
	private Transform groundCheck;			// A position marking where to check if the player is grounded.
	private bool grounded = false;			// Whether or not the player is grounded.
	private Animator anim;					// Reference to the player's animator component.

    //swipe
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;

    //RK New input
    PlayerActionsExample playerInput;
	Rigidbody2D rigidBody2D;
    void Awake()
	{
		// Setting up references.
		groundCheck = transform.Find("groundCheck");
		anim = GetComponent<Animator>();
        playerInput = new PlayerActionsExample();
		rigidBody2D = GetComponent<Rigidbody2D>();
    }


	void Update()
	{
		// The player is grounded if a linecast to the groundcheck position hits anything on the ground layer.
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        // If the jump button is pressed and the player is grounded then the player should jump.
        //RK New input
        //if(Input.GetButtonDown("Jump") && grounded)
        //RK +two times jumping
        if (playerInput.Player.Jump.triggered)
        {
             if (grounded)
            {
                //Debug.Log("Triggered 100...");
                jump100Percents = true;
            }
            else 
            {
                if (jumped50PercentTimes == 0)
                {
                    //Debug.Log("Triggered 50...");
                    jump50Percents = true;
                    jumped50PercentTimes++;
                }
            }
        }

        if (grounded)
            jumped50PercentTimes = 0;

        Swipe();
	}


	void FixedUpdate ()
	{
        //RK TODO Investigate below
        // Cache the horizontal input.
        //float h = Input.GetAxis("Horizontal");
        //var mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //var transformWorldPos = Camera.main.ScreenToWorldPoint(transform.position);
        //if (transformWorldPos.x - mouseWorldPos.x > 0)
        //    h = -1;
        //else
        //    h = 1;

        //RK If extra power is switched on then double maximum speed
        if (GameData.ExtraSpeedTimeout > 0)
        {
            speedMultiplikator = GameData.Const.SpeedMultiplikator;
            //Debug.Log("-->--> adding extra speed...");
        }
        else
        {
            speedMultiplikator = 1;
        }

        //RK New Input
        Vector2 movement = playerInput.Player.Move.ReadValue<Vector2>();
        float h = movement.x;
		//Debug.Log("Movement..." + Convert.ToString(h));
			
        // The Speed animator parameter is set to the absolute value of the horizontal input.
        anim.SetFloat("Speed", Mathf.Abs(h));

		// If the player is changing direction (h has a different sign to velocity.x) or hasn't reached maxSpeed yet...
		if(h * rigidBody2D.velocity.x < maxSpeed)
			// ... add a force to the player.
			rigidBody2D.AddForce(Vector2.right * h * moveForce);

		// If the player's horizontal velocity is greater than the maxSpeed...
		if(Mathf.Abs(rigidBody2D.velocity.x) > maxSpeed)
			// ... set the player's velocity to the maxSpeed in the x axis.
			rigidBody2D.velocity = new Vector2(Mathf.Sign(rigidBody2D.velocity.x) * maxSpeed*speedMultiplikator, rigidBody2D.velocity.y);

		// If the input is moving the player right and the player is facing left...
		if(h > 0 && !facingRight)
			// ... flip the player.
			Flip();
		// Otherwise if the input is moving the player left and the player is facing right...
		else if(h < 0 && facingRight)
			// ... flip the player.
			Flip();

		// If the player should jump for first time...100% of power
		if(jump100Percents)
		{
            // Set the Jump animator trigger parameter.
            anim.SetTrigger("Jump");

			// Play a random jump audio clip.
			int i = UnityEngine.Random.Range(0, jumpClips.Length);
			AudioSource.PlayClipAtPoint(jumpClips[i], transform.position);

			// Add a vertical force to the player.
			rigidBody2D.AddForce(new Vector2(0f, jumpForce));
			
			// Make sure the player can't jump again until the jump conditions from Update are satisfied.
			jump100Percents = false;
		}

        // If the player should jump for sec time...50% of power
        if (jump50Percents)
        {
            // Set the Jump animator trigger parameter.
            anim.SetTrigger("Jump");

            // Play a random jump audio clip.
            int i = UnityEngine.Random.Range(0, jumpClips.Length);
            AudioSource.PlayClipAtPoint(jumpClips[i], transform.position);

            // Add a vertical force to the player.
            rigidBody2D.AddForce(new Vector2(0f, (50f / 100f) * jumpForce));

            // Make sure the player can't jump again until the jump conditions from Update are satisfied.
            jump50Percents = false;
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


    void Flip ()
	{
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}


	public IEnumerator Taunt()
	{
		// Check the random chance of taunting.
		float tauntChance = UnityEngine.Random.Range(0f, 100f);
		if(tauntChance > tauntProbability)
		{
			// Wait for tauntDelay number of seconds.
			yield return new WaitForSeconds(tauntDelay);

			// If there is no clip currently playing.
			if(!GetComponent<AudioSource>().isPlaying)
			{
				// Choose a random, but different taunt.
				tauntIndex = TauntRandom();

				// Play the new taunt.
				GetComponent<AudioSource>().clip = taunts[tauntIndex];
				GetComponent<AudioSource>().Play();
			}
		}
	}


	int TauntRandom()
	{
		// Choose a random index of the taunts array.
		int i = UnityEngine.Random.Range(0, taunts.Length);

		// If it's the same as the previous taunt...
		if(i == tauntIndex)
			// ... try another random taunt.
			return TauntRandom();
		else
			// Otherwise return this index.
			return i;
	}

    public void Swipe()
    {
        if (Input.touches.Length > 0)
        {
            Touch t = Input.GetTouch(0);
            if (t.phase == UnityEngine.TouchPhase.Began)
            {
                //save began touch 2d point
                firstPressPos = new Vector2(t.position.x, t.position.y);
            }
            if (t.phase == UnityEngine.TouchPhase.Ended)
            {
                //save ended touch 2d point
                secondPressPos = new Vector2(t.position.x, t.position.y);

                //create vector from the two points
                currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

                //normalize the 2d vector
                currentSwipe.Normalize();

                //swipe upwards
                if (currentSwipe.y > 0  && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
             {
                    Debug.Log("up swipe");
                }
                //swipe down
                if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
             {
                    Debug.Log("down swipe");
                }
                //swipe left
                if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
             {
                    Debug.Log("left swipe");
                }
                //swipe right
                if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
             {
                    Debug.Log("right swipe");
                }
            }
        }
    }
}
