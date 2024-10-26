using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

public class Gun : MonoBehaviour
{
	public Rigidbody2D rocket;				// Prefab of the rocket.
	public float speed = 20f;				// The speed the rocket will fire at.


	private PlayerControl playerCtrl;		// Reference to the PlayerControl script.
	private Animator anim;                  // Reference to the Animator component.

	PlayerActionsExample playerInput;

	private bool lockShooting = false;      //loxk/unloxk ahooting
	public int initialRocketsAmount;        //Amount of amomnition 
    public int lockingTime = 1;             //Amount of amomnition //RK TODO Move to constants
	private int currentRocketAmount;        //Current ammo 


	
	public int CurrentRocketsAmount
	{
		get { return currentRocketAmount; }
		set { currentRocketAmount = value; }
	}

	void Awake()
	{
		// Setting up the references.
		anim = transform.root.gameObject.GetComponent<Animator>();
		playerCtrl = transform.root.GetComponent<PlayerControl>();
		playerInput = new PlayerActionsExample();

		initialRocketsAmount = GameData.CurrentNumberOfRockets;

        currentRocketAmount = initialRocketsAmount;
    }
    void Update ()
	{
        
        // If the fire button is pressed...
        //RK New Input
        //if(Input.GetButtonDown("Fire1"))
        if (playerInput.Player.Fire1.triggered && !lockShooting)
			{
			// ... set the animator Shoot trigger parameter and play the audioclip.
			anim.SetTrigger("Shoot");
			//RK TODO audio.Play();

			// If the player is facing right...
			if(playerCtrl.facingRight)
			{
				// ... instantiate the rocket facing right and set it's velocity to the right. 
				Rigidbody2D bulletInstance = Instantiate(rocket, transform.position, Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
				bulletInstance.velocity = new Vector2(speed, 0);
			}
			else
			{
				// Otherwise instantiate the rocket facing left and set it's velocity to the left.
				Rigidbody2D bulletInstance = Instantiate(rocket, transform.position, Quaternion.Euler(new Vector3(0,0,180f))) as Rigidbody2D;
				bulletInstance.velocity = new Vector2(-speed, 0);
			}

			currentRocketAmount--;
			if (currentRocketAmount == 0)
				StartCoroutine(LockShooting());

			
		}

	
		GameData.CurrentNumberOfRockets = currentRocketAmount;
    }

	IEnumerator LockShooting()
	{
		lockShooting = true;

		//Debug.Log("Lock shooting for, e.g. 5 sec ....");

		yield return new WaitForSeconds(lockingTime); 

        lockShooting = false;

		currentRocketAmount = initialRocketsAmount;

        //Debug.Log("..unlocking!");

        yield return null;
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
