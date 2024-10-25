using UnityEngine;
using System.Collections;

public class RocketPickup : MonoBehaviour
{
	public int Rockets = GameData.Const.Rockets; //How many rockets in one crate
	public AudioClip collect;				// The sound of the crate being collected.


	private PickupSpawner pickupSpawner;	// Reference to the pickup spawner.
	private Animator anim;					// Reference to the animator component.
	private bool landed;					// Whether or not the crate has landed.


	void Awake ()
	{
		// Setting up the references.
		pickupSpawner = GameObject.Find("pickupManager").GetComponent<PickupSpawner>();
		anim = transform.root.GetComponent<Animator>();
	}
    private void OnTriggerStay2D(Collider2D other)
    {
        UnityEngine.Debug.Log("RocketPickup.OnTriggerStay2D..." + other.gameObject.tag);
        // If the player enters the trigger zone...
        try
        {
            //if (other.gameObject.tag == "Player")
            //{
            //    // Get a reference to the player health script.
            //    // PlayerHelth playerRockets = other.GetComponent<PlayerHelth>();

            //    PlayerRocket playerRockets = other.gameObject.GetComponent<PlayerRocket>();

            //    //// Increasse the player's health by the health bonus but clamp it at 100.
            //    //playerHealth.health += healthBonus;
            //    //playerHealth.health = Mathf.Clamp(playerHealth.health, 0f, 100f);

            //    //// Update the health bar.
            //    //playerHealth.UpdateHealthBar();
            //    playerRockets.UpdateRockets(Rockets); //RK TODO Bug - called  twice duno why

            //    // Trigger a new delivery.
            //    pickupSpawner.StartCoroutine(pickupSpawner.DeliverPickup());

            //    // Play the collection sound.
            //    AudioSource.PlayClipAtPoint(collect, transform.position);

            //    // Destroy the crate.
            //    Destroy(transform.root.gameObject);
            //}
            //// Otherwise if the crate hits the ground...
            //else if (other.gameObject.tag == "ground" && !landed)
            //{
            //    // ... set the Land animator trigger parameter.
            //    anim.SetTrigger("Land");

            //    transform.parent = null;
            //    gameObject.AddComponent<Rigidbody2D>();
            //    landed = true;
            //}
        }
        finally
        {
            UnityEngine.Debug.Log("RocketPickup.OnTriggerStay2D...done");
        }
    }


    void OnCollisionEnter2D(Collision2D other)
	{
        UnityEngine.Debug.Log("RocketPickup.OnCollisionEnter2D..." + other.gameObject.tag);
        // If the player enters the trigger zone...
        try
        {
            //if (other.gameObject.tag == "Player")
            //{
            //    // Get a reference to the player health script.
            //    // PlayerHelth playerRockets = other.GetComponent<PlayerHelth>();

            //    PlayerRocket playerRockets = other.gameObject.GetComponent<PlayerRocket>();

            //    //// Increasse the player's health by the health bonus but clamp it at 100.
            //    //playerHealth.health += healthBonus;
            //    //playerHealth.health = Mathf.Clamp(playerHealth.health, 0f, 100f);

            //    //// Update the health bar.
            //    //playerHealth.UpdateHealthBar();
            //    playerRockets.UpdateRockets(Rockets); //RK TODO Bug - called  twice duno why

            //    // Trigger a new delivery.
            //    pickupSpawner.StartCoroutine(pickupSpawner.DeliverPickup());

            //    // Play the collection sound.
            //    AudioSource.PlayClipAtPoint(collect, transform.position);

            //    // Destroy the crate.
            //    Destroy(transform.root.gameObject);
            //}
            //// Otherwise if the crate hits the ground...
            //else if (other.gameObject.tag == "ground" && !landed)
            //{
            //    // ... set the Land animator trigger parameter.
            //    anim.SetTrigger("Land");

            //    transform.parent = null;
            //    gameObject.AddComponent<Rigidbody2D>();
            //    landed = true;
            //}
        }
        finally
        {
            UnityEngine.Debug.Log("RocketPickup.OnCollisionEnter2D...done");
        }
    }

	void OnTriggerEnter2D (Collider2D other)
	{
		UnityEngine.Debug.Log("RocketPickup.OnTriggerEnter2D..." +  other.tag);
		// If the player enters the trigger zone...
		{
            // Get a reference to the player health script.
            // PlayerHelth playerRockets = other.GetComponent<PlayerHelth>();

            PlayerRocket playerRockets = other.GetComponent<PlayerRocket>();

			//// Increasse the player's health by the health bonus but clamp it at 100.
			//playerHealth.health += healthBonus;
			//playerHealth.health = Mathf.Clamp(playerHealth.health, 0f, 100f);

			//// Update the health bar.
			//playerHealth.UpdateHealthBar();
			playerRockets.UpdateRockets(Rockets); //RK TODO Bug - called  twice duno why

            // Trigger a new delivery.
            pickupSpawner.StartCoroutine(pickupSpawner.DeliverPickup());

			// Play the collection sound.

			// Destroy the crate.
			Destroy(transform.root.gameObject);
		}
		// Otherwise if the crate hits the ground...
		{
			// ... set the Land animator trigger parameter.
			anim.SetTrigger("Land");

			transform.parent = null;
			gameObject.AddComponent<Rigidbody2D>();
			landed = true;	
		}
	}
		finally
		{
            UnityEngine.Debug.Log("RocketPickup.OnTriggerEnter2D...done");
        }
	}
}
