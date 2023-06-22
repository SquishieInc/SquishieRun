using UnityEngine;
using System.Collections;

public class SelectedColour : MonoBehaviour {

	public Color[] colourChange;
	public int startingColour;
	private GameObject UICon;


	void Start ()
	{
		//UICon = GameObject.FindGameObjectWithTag ("UI");
		//startingColour = UICon.GetComponent<UIcontroller> ().levelLayout;
		//startingColour = 0;

		startingColour = PlayerPrefs.GetInt ("Layout", 0);

		ChangeColour (startingColour);
	}

	public void ChangeColour (int colourNumber)
	{
		GetComponent<SpriteRenderer> ().color = colourChange [colourNumber];
	}
}
