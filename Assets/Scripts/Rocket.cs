using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour 
{
	public GameObject explosion;        // Prefab of explosion effect.
	private int forceMultiplikator = 1;

    void Start () 
	{
		// Destroy the rocket after 2 seconds if it doesn't get destroyed before then.
		Destroy(gameObject, 2);
	}


	void OnExplode()
	{
        if (GameData.ExtraForceTimeout > 0)
        {
            forceMultiplikator = 3;
            Debug.Log("-->--> adding extra force...");
        }
        else
        {
            forceMultiplikator = 1;
        }

        // Create a quaternion with a random rotation in the z-axis.
        Quaternion randomRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));

        // Instantiate the explosion where the rocket is with the random rotation.
        GameObject explosionGameObject = Instantiate(explosion, transform.position, randomRotation);

		//Scale up if super power...
        Vector3 explosionLocalScale = explosionGameObject.transform.localScale;
        explosionLocalScale *= forceMultiplikator;
        explosionGameObject.transform.localScale = explosionLocalScale;
    }
	
	void OnTriggerEnter2D (Collider2D col) 
	{
		// If it hits an enemy...
		if(col.tag == "Enemy")
		{
            //RK // ... find the Enemy script and call the Hurt function.
            //col.gameObject.GetComponent<Enemy>().Hurt();

            // kill enemy more if superpower;
            int fm = forceMultiplikator;
			while (fm-->0) {
                // ... find the Enemy script and call the Hurt function.
                col.gameObject.GetComponent<Enemy>().Hurt();
            }

			// Call the explosion instantiation.
			OnExplode();

			// Destroy the rocket.
			Destroy (gameObject);
		}
        else // If it hits an enemy...
        if (col.tag == "Alien")
        {
            //RK ... find the Enemy script and call the Hurt function.
            //col.gameObject.GetComponent<Alien>().Hurt(); int fm = forceMultiplikator;

            // kill enemy more if superpower;
            int fm = forceMultiplikator;
            while (fm-- > 0)
            {
                // ... find the Enemy script and call the Hurt function.
                col.gameObject.GetComponent<Alien>().Hurt();
            }

            // Call the explosion instantiation.
            OnExplode();

            // Destroy the rocket.
            Destroy(gameObject);
        }

        // Otherwise if it hits a bomb crate...
        else if(col.tag == "BombPickup")
		{
			// ... find the Bomb script and call the Explode function.
			col.gameObject.GetComponent<Bomb>().Explode();

			// Destroy the bomb crate.
			Destroy (col.transform.root.gameObject);

			// Destroy the rocket.
			Destroy (gameObject);
		}
		// Otherwise if the player manages to shoot himself...
		else if(col.gameObject.tag != "Player")
		{
			// Instantiate the explosion and destroy the rocket.
			OnExplode();
			Destroy (gameObject);
		}
	}
}
