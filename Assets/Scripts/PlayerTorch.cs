using UnityEngine;
using System.Collections;
using System;

public class PlayerTorch : MonoBehaviour
{	
	//public AudioClip[] ouchClips;				// Array of clips to play when the player is damaged.
	//public float hurtForce = 10f;				// The force with which the player is pushed when hurt.
	//public float damageAmount = 10f;            // The amount of damage to take when enemies touch the player

    
    //private float lastHitTime;		        // The time at which the player was last hit.
	//private PlayerControl playerControl;        // Reference to the PlayerControl script.
    private Transform torchSquereTransform;
    //private Animator anim;                      // Reference to the Animator on the player
	//private Gun gun;                            //RK Gun component of the Player (Hero)
    void Awake ()
	{
		// Setting up references.
		//playerControl = GetComponent<PlayerControl>();
        //healthBar = GameObject.Find("HealthBar").GetComponent<SpriteRenderer>();
        //gun = GameObject.Find("Gun").GetComponent<Gun>(); //RK TODO Rename, not better transform get ???
        //anim = GetComponent<Animator>();

        // Getting the intial scale of the healthbar (whilst the player has full health).
        //healthScale = healthBar.transform.localScale;

        torchSquereTransform = transform.Find("TorchSquare");

        StartCoroutine(TorchTimer());
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //// If the colliding gameobject is an Enemy...
        //// if (col.gameObject.tag == "Enemy")
        //{
        //    // ... and if the time exceeds the time of the last hit plus the time between hits...
        //    // Find all of the colliders on the gameobject and set them all to be triggers.
        //    Collider2D[] cols = GetComponents<Collider2D>();
        //    foreach (Collider2D c in cols)
        //    {
        //        c.isTrigger = true;
        //    }

        //    // Move all sprite parts of the player to the front
        //    SpriteRenderer[] spr = GetComponentsInChildren<SpriteRenderer>();
        //    foreach (SpriteRenderer s in spr)
        //    {
        //        s.sortingLayerName = "UI";
        //    }

        //    // ... disable user Player Control script
        //    GetComponent<PlayerControl>().enabled = false;

        //    // ... disable the Gun script to stop a dead guy shooting a nonexistant bazooka
        //    GetComponentInChildren<Gun>().enabled = false;
        //}
    }

    IEnumerator TorchTimer()
    {
        //UnityEngine.Debug.Log("GameController.ExtraForceTimer started...");
        while (true)
        {
            //UnityEngine.Debug.Log("Tick " + GameData.ExtraForceTimeout + " sec");

            torchSquereTransform.gameObject.SetActive(GameData.TorchTime > 0);

            if (GameData.TorchTime > 0)
            {
                GameData.TorchTime -= 1;
            }

            yield return new WaitForSeconds(1);

          
        }

        //UnityEngine.Debug.Log("...GameController.ExtraForceTimer ended");
    }

    private void OnDestroy()
    {
        StopCoroutine(TorchTimer());
    }


    internal void AddTorchTime()
    {
        GameData.TorchTime += GameData.Const.TimeInTorchCrate;
    }
}
