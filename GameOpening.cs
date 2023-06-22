using UnityEngine;
using System.Collections;

public class GameOpening : MonoBehaviour {

	public float waitTime;
	public GameObject loadingPanel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (waitTime > 0) 
		{
			waitTime -= Time.deltaTime;
			if (waitTime <= 0) 
			{
				loadingPanel.SetActive (true);
				Destroy (gameObject);

			}
		}
	}
}
