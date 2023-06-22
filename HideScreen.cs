using UnityEngine;
using System.Collections;

public class HideScreen : MonoBehaviour {

	public float waitTime;
	public GameObject UiController;
	public GameObject canvas;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (waitTime > 0) {
			waitTime -= Time.deltaTime;
			if(waitTime <= 0)
			{
				Debug.Log ("Set music, level loaded");
//				UiController.GetComponent<UIcontroller>().SetMusic();
				canvas.SetActive (true);
				Time.timeScale = 0f;
				Destroy (gameObject);

			}
		}
	}
}
