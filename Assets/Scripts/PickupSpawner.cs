using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class PickupSpawner : MonoBehaviour
{
	public GameObject[] pickups;				// Array of pickup prefabs with the bomb pickup first and health second.
	public float pickupDeliveryTime = 5f;		// Delay on delivery.
	public float dropRangeLeft;					// Smallest value of x in world coordinates the delivery can happen at.
	public float dropRangeRight;				// Largest value of x in world coordinates the delivery can happen at.
	public float highHealthThreshold = 75f;		// The health of the player, above which only bomb crates will be delivered.
	public float lowHealthThreshold = 25f;		// The health of the player, below which only health crates will be delivered.


	private PlayerHealth playerHealth;			// Reference to the PlayerHealth script.


	void Awake ()
	{
		// Setting up the reference.
		playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
	}


	void Start ()
	{
		// Start the first delivery.
		StartCoroutine(DeliverPickup());
	}


	public IEnumerator DeliverPickup()
	{
		try
		{
			//UnityEngine.Debug.Log("PickupSpawner.DeliverPickup called...waiting " + pickupDeliveryTime + " sec.");
			// Wait for the delivery delay.
			yield return new WaitForSeconds(pickupDeliveryTime);

			// Create a random x coordinate for the delivery in the drop range.
			float dropPosX = Random.Range(dropRangeLeft, dropRangeRight);

			// Create a position with the random x coordinate.
			Vector3 dropPos = new Vector3(dropPosX, 15f, 1f);

			//RK debug
			//UnityEngine.Debug.Log("Spawning Random...RocketCrate for debug :)");
            GameObject obj = Instantiate(pickups[2], dropPos, Quaternion.identity) as GameObject;
			ColliderTwiddler.Twiddle(obj);
            //obj.transform.GetChild(0).GetComponent<CircleCollider2D>().enabled = false;
            //obj.transform.GetChild(0).GetComponent<CircleCollider2D>().isTrigger = false;
            //obj.transform.GetChild(0).GetComponent<CircleCollider2D>().enabled = true;
            //obj.transform.GetChild(0).GetComponent<CircleCollider2D>().isTrigger = true;
            yield break;

			UnityEngine.Debug.Log("PickupSpawner.DeliverPickup trying to spawn...");

			// If the player's health is above the high threshold...
			if (playerHealth.health >= highHealthThreshold)
			{
				//Debug.Log("Spawning Bomb...");
				// ... instantiate a bomb pickup at the drop position.
				Instantiate(pickups[0], dropPos, Quaternion.identity);
			}
			// Otherwise if the player's health is below the low threshold...
			else if (playerHealth.health <= lowHealthThreshold)
			{
				//Debug.Log("Spawning Health...");
				// ... instantiate a health pickup at the drop position.
				Instantiate(pickups[1], dropPos, Quaternion.identity);
			}
			// Otherwise...
			else
			{

				// ... instantiate a random pickup at the drop position.
				int pickupIndex = Random.Range(0, pickups.Length);
				//Debug.Log("Spawning Random..." + pickupIndex);
				Instantiate(pickups[pickupIndex], dropPos, Quaternion.identity);
			}
		}
		finally
		{
            //UnityEngine.Debug.Log("PickupSpawner.DeliverPickup done.");
        }

        

    }
}
