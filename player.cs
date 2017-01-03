using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System.Collections;

public class player : MonoBehaviour {

	public float startingLives;

	//Jump Version 1
	public float power = 3.5f;
	//public int jumpHeight = 1800;
	public bool isFalling = false;

	//public bool canDoubleJump;
	//public bool jumpOne;
	//public bool jumpTwo;

	//Jump Version 2
	public float jumpSpeed = 2400f;
	public float jumpDelay = .1f;
	public int jumpCount = 2;
	public bool playing;

	protected float lastJumpTime = 0;
	protected int jumpsRemaining = 0;

	public AudioClip hitSound;
	private AudioSource Audio;

	public GameObject ui;
	public GameObject bloodParticles;
	public GameObject Explosion;

	public GameObject fish;
	private float fishxpos = 1;
	//private float fishtimer;

	//Camera Shake System
	Vector2 originalCameraPosition;
	float shakeAmt = 0;
	GameObject mainCamera;

	//damage Timer
	public float damageTime = 2;
	public float damageTimer;

	//Animations
	Animator anim;
	private Rigidbody2D m_Rigidbody2D;
	private SpriteRenderer spriterender;

	void Start()
	{
		startingLives = ui.GetComponent<UIcontroller> ().health;
		playing = false;

		Audio = GetComponent<AudioSource> ();
/*
		startingAudio = PlayerPrefs.GetInt ("Audio", 0);
		ChangeAudio (startingAudio);
*/

		//canDoubleJump = false;
		//jumpOne = false;
		//jumpTwo = false;
	}

	void Awake()
	{
//		anim = GetComponent<Animator> ();
//		m_Rigidbody2D = GetComponent<Rigidbody2D> ();
//		Debug.Log ("Got Animator");
	}

	void Update()
	{
		if(damageTimer > 0)
		{
			spriterender = GetComponent<SpriteRenderer> ();
			spriterender.color = new Color(spriterender.color.r, spriterender.color.g, spriterender.color.b, Mathf.PingPong(Time.time, 1));
			damageTimer -= Time.deltaTime;
			if (damageTimer <= 0) 
			{
				damageTimer = 0;
				spriterender.color = new Color(255f, 255f, 255f, 255f);
			}
		}

//		anim.SetFloat("vSpeed", m_Rigidbody2D.velocity.y);
		//Jump Version 1
		/*		if(canDoubleJump)
		{
			Debug.Log ("ready for second jump!!");
		}
		//transform.Translate(Vector2.right * power * Time.deltaTime);
		if (Input.GetKey (KeyCode.Space) && isFalling == false || Input.GetTouch(0).phase == TouchPhase.Began && isFalling == false) 
		{
			jumpOne = true;
			canDoubleJump = true;
			isFalling = true;
		}
		if (Input.GetKey (KeyCode.Space) && isFalling == true && canDoubleJump == true || Input.GetTouch(0).phase == TouchPhase.Began && isFalling == true && canDoubleJump == true) 
		{
			jumpTwo = true;
			canDoubleJump = false;
		}*/

		//Jump Version 2
		//var canJump = Input.GetTouch (0).phase == TouchPhase.Began;
		//var holdTime = Input.GetTouch (0).deltaTime;
		if (Input.GetKey (KeyCode.Space) && playing == true)//|| Input.GetTouch(0).phase == TouchPhase.Began && playing == true) 
		//if (Input.GetKey (KeyCode.Space)|| Input.GetTouch(0).phase == TouchPhase.Began)
		{
			Debug.Log ("Have Pressed Jump Button");
			jumpsRemaining = jumpCount - 1;

			OnJump ();
		}
		else
		{
			if (Input.GetKey (KeyCode.Space) && playing == true)//|| Input.GetTouch(0).phase == TouchPhase.Began && playing == true)
			{
				if (jumpsRemaining > 0)
				{
					OnJump ();

					jumpsRemaining--;
				}
			}
		}

		if (/*Input.GetKey (KeyCode.Space) && playing == true|| */Input.GetTouch(0).phase == TouchPhase.Began && playing == true) 
			//if (Input.GetKey (KeyCode.Space)|| Input.GetTouch(0).phase == TouchPhase.Began)
		{
			Debug.Log ("Have Pressed Jump Button");
			jumpsRemaining = jumpCount - 1;

			OnJump ();
		}
		else
		{
			if (/*Input.GetKey (KeyCode.Space) && playing == true|| */Input.GetTouch(0).phase == TouchPhase.Began && playing == true)
			{
				if (jumpsRemaining > 0)
				{
					OnJump ();

					jumpsRemaining--;
				}
			}
		}
	}

	void FixedUpdate () 
	{
		if(playing)
		{
		transform.Translate(Vector2.right * power * Time.deltaTime);
		}
		/*
		if (jumpOne == true) 
		{
			Debug.Log ("first jump");
			GetComponent<Rigidbody2D> ().AddForce (Vector2.up * jumpHeight);
			jumpOne = false;
		}
		if (jumpTwo == true) 
		{
			Debug.Log ("second jump");
			GetComponent<Rigidbody2D> ().AddForce (Vector2.up * jumpHeight);
			jumpTwo = false;
		}*/
	}

	void OnJump ()
	{
		//Jump Version 2
		lastJumpTime = Time.time;
		GetComponent<Rigidbody2D> ().AddForce (Vector2.up * jumpSpeed);
		//anim.Play ("Jumping", -1, 0f);
	}

	void OnCollisionStay2D(Collision2D col)
	{
		if (col.gameObject.tag == "Ground") {
			Debug.Log ("hit the ground");
			isFalling = false;
			//canDoubleJump = false;
			jumpsRemaining = 2;
			//			anim.SetBool ("Grounded", true);
//			anim.Play ("Running");
		}
		if (col.gameObject.tag == "Roof") {
			Debug.Log ("hit the Roof");
			isFalling = true;
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Death" && damageTimer <= 0) 
		{
			startingLives -= 1;
			damageTimer = damageTime;
			ui = GameObject.FindGameObjectWithTag ("UI");
			ui.GetComponent<UIcontroller> ().TakeDamage ();
			col.GetComponent<BoxCollider2D> ().enabled = false;
			mainCamera = GameObject.FindGameObjectWithTag ("MainCamera");
			//mainCamera.GetComponent<cameraController> ().shakeCamera (0.1f, 1);

			if (startingLives != 0)//(ui.GetComponent<UIcontroller> ().health > 1) 
			{
				Debug.Log("ui health ");
				mainCamera.GetComponent<cameraController> ().shakeCamera (0.1f, 0.5f);
			}
			Bleed ();

			//Audio Effect When Hit
			Audio.PlayOneShot (hitSound, 0.7f);

			//Enemy Particle Effect
			fishxpos += 1;
			//fish.transform.localPosition = new Vector3(fishxpos, 2, 5);
			fish.GetComponent<ParticleSystem>().startSpeed = fishxpos;
		}
	}

	public void RecoverHealth()
	{
		//Enemy Particle Effect
		fishxpos -= 1;
		//fish.transform.localPosition = new Vector3(fishxpos, 2, 5);
		fish.GetComponent<ParticleSystem>().startSpeed = fishxpos;
	}

	void Bleed ()
	{
		GameObject childObject = Instantiate (bloodParticles) as GameObject;
		GameObject childObject2 = Instantiate (Explosion) as GameObject;
		childObject.transform.SetParent (this.transform, false);
		childObject2.transform.SetParent (this.transform, false);
		Destroy (childObject, 2);
		Destroy (childObject2, 2);
		//fishtimer = 10;
	}

	public void PlayingGame (bool gamestarted)
	{
		playing = gamestarted;
	}

	public void ChangeSpeed(float speedChange)
	{
		power += speedChange;
	}

	public void AddPlayerModifier(float powerMod, float jumpMod, float massMod)
	{
		Debug.Log ("Player Modifiers Added!");
		power += powerMod;  Debug.Log ("PowerMod = " + powerMod);
		//power = power + powerMod;  Debug.Log ("PowerMod = " + powerMod);
		jumpSpeed += jumpMod;  Debug.Log ("JumpMod = " + jumpMod);
		m_Rigidbody2D.mass += massMod;  Debug.Log ("massMod = " + massMod);

//		Debug.Log ("new player jump settings = " + jumpSpeed += jumpMod);
	}

	public void ResetPlayerModifiers()
	{
		power = 3.5f;
		jumpSpeed = 2400f;
		m_Rigidbody2D.mass = 5f;
	}

	static public void CaptureScreen()
	{
		Application.CaptureScreenshot ("Screenshot.png", 0);

		string path = System.IO.Path.Combine (Application.persistentDataPath, "Screenshot.png");
		//string path = System.IO.Path.Combine (Application.dataPath, "Screenshot.png");
		Debug.Log (path);
		//print(Application.persistentDataPath);
		print(Application.dataPath);
	}
}