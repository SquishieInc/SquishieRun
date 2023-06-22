using UnityEngine;
using System.Collections;

public class SpriteSelection : MonoBehaviour {
	
	public GameObject [] characterList;
	private int index;


	void Start()
	{
		index = PlayerPrefs.GetInt ("CharacterSelected");

		characterList = new GameObject[transform.childCount];

		//Fill array with character models
		for (int i = 0; i < transform.childCount; i++) 
			characterList [i] = transform.GetChild (i).gameObject;

		//toggle off their renderer
		foreach (GameObject go in characterList)
			go.SetActive (false);

		//we toggle the selected character
		if (characterList [index])
			characterList [index].SetActive (true);

		Debug.Log ("Amount of characters to select = " + characterList.Length);
	}

	public void TurnOffSprites(int newIndex)
	{
		index = newIndex;

		foreach (GameObject go in characterList)
			go.SetActive (false);

		Confirm ();
	}

	void Confirm()
	{
		PlayerPrefs.SetInt ("CharacterSelected", index);
		Debug.Log ("Player SpriteSelection Index = " + index);
		//Toggle on the new model
		characterList[index].SetActive(true);
		//SceneManager.LoadScene ("TestingArea");
	}
}
