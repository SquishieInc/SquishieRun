using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour {

	private GameObject [] characterList;
	private int index;

	void Start()
	{
		index = PlayerPrefs.GetInt ("CharacterSelected");
		Debug.Log ("character button on show = " + index);

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

	public void ToggleLeft()
	{
		//Toggle off the current model
		characterList[index].SetActive(false);

		index--;//index -= 1; index = index -1;
		if(index < 0)
			index = characterList.Length - 1;

		Debug.Log ("character selected = " + index);

		//Toggle on the new model
		characterList[index].SetActive(true);
	}

	public void ToggleRight()
	{
		//Toggle off the current model
		characterList[index].SetActive(false);

		index++;//index -= 1; index = index -1;
		if(index == characterList.Length)
			index = 0;
		

		Debug.Log ("character selected = " + index);

		//Toggle on the new model
		characterList[index].SetActive(true);
	}

	public void Confirm()
	{
		PlayerPrefs.SetInt ("CharacterSelected", index);
		Debug.Log ("CharacterSelect Script Savings; " + index);
		//SceneManager.LoadScene ("TestingArea");
	}
}
