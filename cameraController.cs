using UnityEngine;
using System.Collections;

public class cameraController : MonoBehaviour {

	public GameObject player;

	public float shakeTime;
	public float shakeAmount;

//	Animator anim;
//	Animation cameraAnimation;

	void Start () 
	{
		transform.position = new Vector3 (player.transform.position.x + 2, 1, -20);


		//anim = GetComponent<Animator> ();
		//cameraAnimation = GetComponent<Animation> ();
		//StartGameAnimation ();
	}
	

	void FixedUpdate () 
	{
		transform.position = new Vector3 (player.transform.position.x + 2, 1, -20);
	}

	void Update ()
	{
		if (shakeTime >= 0) 
		{
			Vector2 shakePos = Random.insideUnitCircle * shakeAmount;
			transform.position = new Vector3(transform.position.x + shakePos.x, transform.position.y + shakePos.y, transform.position.z);
			shakeTime -= Time.deltaTime;
		}
	}

	public void shakeCamera(float shakePwr, float shakeDur)
	{
		shakeAmount = shakePwr;
		shakeTime = shakeDur;
	}


//	void StartGameAnimation ()
//	{
//		cameraAnimation.Play(
//	}
}
