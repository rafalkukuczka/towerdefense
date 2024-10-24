using UnityEngine;
using System.Collections;
using Unity.PlasticSCM.Editor.WebApi;

public class Gun : MonoBehaviour
{
	public Rigidbody2D rocket;				// Prefab of the rocket.
	public float speed = 20f;				// The speed the rocket will fire at.


	private PlayerControl playerCtrl;		// Reference to the PlayerControl script.
	private Animator anim;                  // Reference to the Animator component.

	PlayerActionsExample playerInput;

	private bool lockShooting = false;      //loxk/unloxk ahooting
	public int ammoAmount = 12;             //Amount of amomnition //RK TODO Move to constants
    public int lockingTime = 5;             //Amount of amomnition //RK TODO Move to constants
	private int currentAmmo;          //Current ammo 
	void Awake()
	{
		// Setting up the references.
		anim = transform.root.gameObject.GetComponent<Animator>();
		playerCtrl = transform.root.GetComponent<PlayerControl>();
		playerInput = new PlayerActionsExample();

		currentAmmo = ammoAmount;
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

			currentAmmo--;
			if (currentAmmo == 0)
				StartCoroutine(LockShooting());
		}
	}

	IEnumerator LockShooting()
	{
		lockShooting = true;

		//Debug.Log("Lock shooting for 5 sec ....");

		yield return new WaitForSeconds(lockingTime); 

        lockShooting = false;

		currentAmmo = ammoAmount;

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
