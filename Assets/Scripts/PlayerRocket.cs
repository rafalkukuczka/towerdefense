using UnityEngine;
using System.Collections;

public class PlayerRocket: MonoBehaviour
{	
	//public AudioClip[] ouchClips;				// Array of clips to play when the player is damaged.
	//public float hurtForce = 10f;				// The force with which the player is pushed when hurt.
	//public float damageAmount = 10f;            // The amount of damage to take when enemies touch the player

    
    //private float lastHitTime;		        // The time at which the player was last hit.
	private PlayerControl playerControl;		// Reference to the PlayerControl script.
	private Animator anim;                      // Reference to the Animator on the player
	private Gun gun;                            //RK Gun component of the Player (Hero)
    void Awake ()
	{
		// Setting up references.
		playerControl = GetComponent<PlayerControl>();
		//healthBar = GameObject.Find("HealthBar").GetComponent<SpriteRenderer>();
		gun = GameObject.Find("Gun").GetComponent<Gun>(); //RK TODO Rename, not better transform get ???
        anim = GetComponent<Animator>();

		// Getting the intial scale of the healthbar (whilst the player has full health).
		//healthScale = healthBar.transform.localScale;
	}


	public void UpdateRockets(int rockets)
	{
		gun.CurrentAmmo += rockets; 
	}
}
