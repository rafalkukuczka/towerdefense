﻿using UnityEngine;
using System.Collections;
using Assets.Scripts.Interfaces;

public class PlayerHealth : MonoBehaviour
{	
	public float health = 100f;					// The player's health.
	public float repeatDamagePeriod = 2f;		// How frequently the player can be damaged.
	public AudioClip[] ouchClips;				// Array of clips to play when the player is damaged.
	public float hurtForce = 10f;				// The force with which the player is pushed when hurt.
	public float damageAmount = 10f;			// The amount of damage to take when enemies touch the player

	private SpriteRenderer healthBar;			// Reference to the sprite renderer of the health bar.
	private float lastHitTime;					// The time at which the player was last hit.
	private Vector3 healthScale;                // The local scale of the health bar initially (with full health).
    private Material bodyMaterial;
    private PlayerControl playerControl;		// Reference to the PlayerControl script.
	private Animator anim;						// Reference to the Animator on the player


	void Awake ()
	{
		// Setting up references.
		playerControl = GetComponent<PlayerControl>();
		healthBar = GameObject.Find("HealthBar").GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator>();

		// Getting the intial scale of the healthbar (whilst the player has full health).
		healthScale = healthBar.transform.localScale;

		bodyMaterial = transform.Find("body").transform.GetComponent<SpriteRenderer>().material;

    }


	void OnCollisionEnter2D(Collision2D col)
	{
		// RK
		// If the colliding gameobject is an Enemy...
		//if (col.gameObject.tag == "Enemy" || col.gameObject.tag == "Alien" || col.gameObject.tag == "AlienGreen")
		IEnemy enemy = col.gameObject.GetComponent<IEnemy>();
		if (enemy != null)
		{
			{
				// ... and if the time exceeds the time of the last hit plus the time between hits...
				if (Time.time > lastHitTime + repeatDamagePeriod)
				{
					// ... and if the player still has health...
					if (health > 0f)
					{
						// ... take damage and reset the lastHitTime.
						TakeDamage(col.transform);
						lastHitTime = Time.time;
					}
					// If the player doesn't have health, do some stuff, let him fall into the river to reload the level.
					else
					{
						// Find all of the colliders on the gameobject and set them all to be triggers.
						Collider2D[] cols = GetComponents<Collider2D>();
						foreach (Collider2D c in cols)
						{
							c.isTrigger = true;
						}

						// Move all sprite parts of the player to the front
						SpriteRenderer[] spr = GetComponentsInChildren<SpriteRenderer>();
						foreach (SpriteRenderer s in spr)
						{
							s.sortingLayerName = "UI";
						}

						// ... disable user Player Control script
						GetComponent<PlayerControl>().enabled = false;

						// ... disable the Gun script to stop a dead guy shooting a nonexistant bazooka
						GetComponentInChildren<Gun>().enabled = false;

						// ... Trigger the 'Die' animation state
						anim.SetTrigger("Die");
					}
				}
			}
		}
	}

	void TakeDamage (Transform enemyTransform)
	{
        //RK Load Material example (Assets\Resources\Folder1\rk2_material_rk2shader)
        //Material newMat = Resources.Load<Material>("Folder1\rk2_material_rk2shader");
        //transform.Find("body").transform.GetComponent<SpriteRenderer>().material = newMat;
		
		//RK Change body material depending on Enemy;
		var enemy = enemyTransform.GetComponent<IEnemy>();
		Color damageColor = enemy.GetDamegeColor();
        bodyMaterial.SetColor("_Color", damageColor);
        bodyMaterial.SetFloat("_Transparency", 0.95f);

        // Make sure the player can't jump.
        playerControl.jump50Percents = false;
        playerControl.jump100Percents = false;

        // Create a vector that's from the enemy to the player with an upwards boost.
        Vector3 hurtVector = transform.position - enemyTransform.position + Vector3.up * 5f;

		// Add a force to the player in the direction of the vector and multiply by the hurtForce.
		//RK rigidbody2D.AddForce(hurtVector * hurtForce);

		// Reduce the player's health by 10.
		health -= damageAmount;

		// Update what the health bar looks like.
		UpdateHealthIndicators();

		// Play a random clip of the player getting hurt.
		int i = Random.Range (0, ouchClips.Length);
		AudioSource.PlayClipAtPoint(ouchClips[i], transform.position);
	}


	public void UpdateHealthIndicators ()
	{
		//RK Body
		//...if completely healthy
		if (health == 1)
		{
			//...set body to default color
			bodyMaterial.SetColor("_Color", Color.clear);
			bodyMaterial.SetFloat("_Transparency", 0);
		}


        //HealthBar
        // Set the health bar's colour to proportion of the way between green and red based on the player's health.
        healthBar.material.color = Color.Lerp(Color.green, Color.red, 1 - health * 0.01f);

		// Set the scale of the health bar to be proportional to the player's health.
		healthBar.transform.localScale = new Vector3(healthScale.x * health * 0.01f, 1, 1);


	}
}
