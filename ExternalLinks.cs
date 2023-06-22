using UnityEngine;
using System.Collections;

public class ExternalLinks : MonoBehaviour {

	// Use this for initialization
	public void SkipSoundCLoud () 
	{
		Application.OpenURL("https://soundcloud.com/skipcloud/");
		Debug.Log ("Skip SoundCloud");
	}
	
	// Update is called once per frame
	public void SquishieWebsite () 
	{
		Application.OpenURL("http://unity3d.com/");
		Debug.Log ("SquishieInc");
	}

	public void SkipBandCamp () 
	{
		Application.OpenURL("https://skipcloud.bandcamp.com");
		Debug.Log ("Skip BandCamp");
	}
}
