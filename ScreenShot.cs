using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;

public class ScreenShot : MonoBehaviour {

	public Image GOScreenShot;
	private string imagePath = (Application.persistentDataPath + "ScreenShot.png");
	/*
	void Start()
	{
		imagePath = Application.persistentDataPath + "ScreenShot.png";
		Debug.Log (imagePath);
	}
*/
	IEnumerator Start() {

		//imagePath = (Application.persistentDataPath + "ScreenShot.png");
		//imagePath = Application.dataPath + "ScreenShot.png";

		WWW www = new WWW(imagePath);
		yield return www;
		GOScreenShot.sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0));
	}
}
