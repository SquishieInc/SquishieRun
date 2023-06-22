using UnityEngine;
using System.Collections;

public class SelectedSprite : MonoBehaviour {

	public Sprite[] spriteChange;
	public int startingSprite;
	private GameObject UICon;

	void Start ()
	{
		//UICon = GameObject.FindGameObjectWithTag ("UI");
		//startingSprite = UICon.GetComponent<UIcontroller> ().levelLayout;

		startingSprite = PlayerPrefs.GetInt ("Layout", 0);

		ChangeSprite (startingSprite);
	}

	public void ChangeSprite (int spriteNumber)
	{
		GetComponent<SpriteRenderer> ().sprite = spriteChange [spriteNumber];
	}
}