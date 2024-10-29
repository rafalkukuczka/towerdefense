using UnityEngine;
using System.Collections;

public class AlienGreen : MonoBehaviour
{
	public float moveSpeed = 2f;		// The speed the enemy moves at.
	public int HP = 1;					// How many times the enemy can be hit before it dies.
	public Sprite deadEnemy;			// A sprite of the enemy when it's dead.
	public Sprite damagedEnemy;			// An optional sprite of the enemy when it's damaged.
	public AudioClip[] deathClips;		// An array of audioclips that can play when the enemy dies.
	public GameObject hundredPointsUI;	// A prefab of 100 that appears when the enemy dies.
	public float deathSpinMin = -100f;			// A value to give the minimum amount of Torque when dying
	public float deathSpinMax = 100f;			// A value to give the maximum amount of Torque when dying


	private SpriteRenderer ren;			// Reference to the sprite renderer.
	private Transform frontCheck;		// Reference to the position of the gameobject used for checking if something is in front.
	private bool dead = false;          // Whether or not the enemy is dead.

	private Animator animator;

    //RK Porting private Rigidbody2D rigidbody2D;    // RK Reference to the RigidBody
    private new Rigidbody2D rigidbody2D;    // RK Reference to the RigidBody
    private int originalHealthPoints;

    void Awake()
	{
		// Setting up the references.
		ren = transform.Find("body").GetComponent<SpriteRenderer>();
		frontCheck = transform.Find("frontCheck").transform;
		rigidbody2D = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();

		originalHealthPoints = HP;

		StartCoroutine(AITimer());
    }

	void FixedUpdate ()
	{
		// Create an array of all the colliders in front of the enemy.
		Collider2D[] frontHits = Physics2D.OverlapPointAll(frontCheck.position, 1);

		// Check each of the colliders.
		foreach(Collider2D c in frontHits)
		{
			// If any of the colliders is an Obstacle...
			if(c.tag == "Obstacle")
			{
				// ... Flip the enemy and stop checking the other colliders.
				Flip ();
				break;
			}
		}

		// Set the enemy's velocity to moveSpeed in the x direction.
		GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x * moveSpeed, GetComponent<Rigidbody2D>().velocity.y);	

		// If the enemy has one hit point left and has a damagedEnemy sprite...
		if(HP == 1 && damagedEnemy != null)
			// ... set the sprite renderer's sprite to be the damagedEnemy sprite.
			ren.sprite = damagedEnemy;
			
		// If the enemy has zero or fewer hit points and isn't dead yet...
		if(HP <= 0 && !dead)
			// ... call the death function.
			Death ();
	}
	
	public void Hurt()
	{
		// Reduce the number of hit points by one.
		HP--;
	}
	
	void Death()
	{
		animator.SetTrigger("Die");
		//RK dunno why: (there is no die controllers sprite rendered when sprite is not enabled)		
		// Find all of the sprite renderers on this object and it's children.
		//SpriteRenderer[] otherRenderers = GetComponentsInChildren<SpriteRenderer>();
		//// Disable all of them sprite renderers.
		//foreach(SpriteRenderer s in otherRenderers)
		//{
		//	s.enabled = false;
		//}

		// Re-enable the main sprite renderer and set it's sprite to the deadEnemy sprite.
		ren.enabled = true;
		ren.sprite = deadEnemy;

		// Increase the score by 100 points
        GameData.Score += 100 * originalHealthPoints;

        // Set dead to true.
        dead = true;

		// Allow the enemy to rotate and spin it by adding a torque.
		GetComponent<Rigidbody2D>().constraints = new RigidbodyConstraints2D() { };
        GetComponent<Rigidbody2D>().AddTorque(Random.Range(deathSpinMin,deathSpinMax));

		// Find all of the colliders on the gameobject and set them all to be triggers.
		Collider2D[] cols = GetComponents<Collider2D>();
		foreach(Collider2D c in cols)
		{
			c.isTrigger = true;
		}

		// Play a random audioclip from the deathClips array.
		int i = Random.Range(0, deathClips.Length);  //RK TODO Exception when no audio clips
		AudioSource.PlayClipAtPoint(deathClips[i], transform.position);

		// Create a vector that is just above the enemy.
		Vector3 scorePos;
		scorePos = transform.position;
		scorePos.y += 1.5f;

        // Instantiate the 100 points prefab at this point.
        StartCoroutine(ShowPointsUI());
    }

    IEnumerator ShowPointsUI()
    {

        // Create a vector that is just above the enemy.
        Vector3 scorePos;
        scorePos = transform.position;
        scorePos.y += 1.5f;


        // Instantiate the 3x100 points prefab at this point.
        int healthPoints = originalHealthPoints;
        while (healthPoints-- > 0)
        {
            Instantiate(hundredPointsUI, scorePos, Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
        }

    }

    IEnumerator AITimer()
    {
        UnityEngine.Debug.Log("AlienGreen.AITimer started..." + GetHashCode());

        while (true)
        {
            UnityEngine.Debug.Log(GetHashCode()+":Tick ");
            yield return new WaitForSeconds(1);
			animator.SetFloat("Speed", 0.2f);
            yield return new WaitForSeconds(1);
            animator.SetFloat("Speed", 0.7f);
            yield return new WaitForSeconds(1);
            animator.SetFloat("Speed", 0);
            animator.SetTrigger("Attack");
            yield return new WaitForSeconds(1);
			animator.SetTrigger("Fire");
            yield return new WaitForSeconds(1);
            Flip();
        }

        //UnityEngine.Debug.Log("...GameController.ExtraForceTimer ended");
    }


    public void Flip()
	{
		// Multiply the x component of localScale by -1.
		Vector3 enemyScale = transform.localScale;
		enemyScale.x *= -1;
		transform.localScale = enemyScale;
	}
}
