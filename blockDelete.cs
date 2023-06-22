using UnityEngine;
using System.Collections;

public class blockDelete : MonoBehaviour {

	private float waitTime = 3.0f;
	public GameObject ui;
	public GameObject p;
	public GameObject blockSpawner;

	void Start()
	{

	}

	void OnTriggerExit2D (Collider2D other) 
	{
		StartCoroutine (Delete ());
		//ui = GameObject.FindGameObjectWithTag ("UI");
		ui = GameObject.Find ("UIController");
		UIcontroller.ScorePlus (1);
		blockSpawner = GameObject.Find ("blockspawner");
		blockSpawner.GetComponent<blockspawn> ().AddedRoomNumber (1);
		blockSpawner.GetComponent<blockspawn> ().Block ();

		p = GameObject.Find ("Player");
		p.GetComponent<player> ().ChangeSpeed (0.03f);
	}

	IEnumerator Delete()
	{
		yield return new WaitForSeconds (waitTime);
		Destroy (transform.parent.gameObject);
	}
}
