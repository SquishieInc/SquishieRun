using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Advertisements;

public class Advertisements : MonoBehaviour {

	public bool adReady;

	void Start()
	{
		adReady = true;
	}

	void Awake ()
	{
		if (Advertisement.isSupported) 
		{
			if(Application.platform == RuntimePlatform.Android)
			{
				Advertisement.Initialize("1048358", false);
			}
			else if(Application.platform == RuntimePlatform.IPhonePlayer)
			{
				Advertisement.Initialize("1048358", false);
			}
		}
	}

	public void ShowAd()
	{
		adReady = false;
		if (Advertisement.IsReady())
		{
			//var options = new ShowOptions {resultCallback = HandleShowResult};
			Advertisement.Show ();
		}
	}
}
