using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextArray : MonoBehaviour {

	public Text titleCon;
	public Text bodyCon;
	public Text heartText;
	public Text gutsText;
	public Text ballsText;


	//Character Modifiers
	public string[] title;
	public string[] body;
	public float[] heart;
	public float[] guts;
	public float[] balls;

	private int index;

	public GameObject player;

	void Start()
	{
		index = PlayerPrefs.GetInt ("CharacterSelected");
		Debug.Log ("Text Array Index = " + index);

		titleCon.text = title [index];
		bodyCon.text = body [index];
		heartText.text = "Heart: " + heart [index].ToString();
		gutsText.text = "Guts: " + guts [index].ToString();;
		ballsText.text = "Balls: " + balls [index].ToString();;
	}

	void DisplayText()
	{
		titleCon.text = title [index];
		bodyCon.text = body [index];
		heartText.text = "Heart: " + heart [index].ToString();;
		gutsText.text = "Guts: " + guts [index].ToString();;
		ballsText.text = "Balls: " + balls [index].ToString();;
	}

	public void ToggleLeft()
	{
		index--;//index -= 1; index = index -1;
		if(index < 0)
			index = title.Length - 1;
			DisplayText ();
		
	}

	public void ToggleRight()
	{
		index++;//index -= 1; index = index -1;
		if (index == title.Length)
			index = 0;
			DisplayText ();

		Debug.Log ("Text selected = " + index);
		
	}

	public void Confirm()
	{
	//	PlayerPrefs.SetInt ("SelectedCharText", index);
		Debug.Log ("TextArray Script Savings; " + index);
	//	player.GetComponent<player>().AddPlayerModifier (heart [index], guts [index], balls [index]);
	}

	public void ModifyPlayer()
	{
		player.GetComponent<player>().AddPlayerModifier (heart [index], guts [index], balls [index]);
	}
}
