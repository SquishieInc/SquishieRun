using UnityEngine;
using System.Collections;
using System.IO;

public class GetStreamingAssetsPath : MonoBehaviour {

	public string startingAudio;
	public string path;
	public AudioClip loadedMp3;
	private AudioSource Audio;
	string songName;

	public void LookForMusic(string fileName)
	{
		//Save Currently Playing Track
		PlayerPrefs.SetString ("song", fileName);
//		Debug.Log ("UNITY DEBUG LOG - Saving Audio " + fileName);

		//Check file directory for Music Name
		if (Application.platform == RuntimePlatform.IPhonePlayer) {
			path = Application.dataPath + "/Raw/" + fileName + ".mp3";
		} else {
			path = "file:" + Application.dataPath + "/StreamingAssets/" + fileName + ".mp3";
		}
//		Debug.Log ("UNITY DEBUG LOG - LOAD FROM STREAMING ASSET " + path);

		//Start Getting the music ready
		StartCoroutine (GetMusic (path));
	}

	IEnumerator GetMusic(string path)
	{
	// Start a download of the given URL
		WWW request = new WWW ("file://" + path);
//		Debug.Log ("UNITY DEBUG LOG - Requesting File " + request);
	
		// Wait for download to complete
		yield return request;

		// Play Audio Clip
		AudioClip loadedMp3 = request.GetAudioClip (false, false);
		Audio.clip = loadedMp3;
		songName =  Audio.clip.name;
		Audio.Play ();
//		Debug.Log ("UNITY DEBUG LOG - Song Name " + songName);
//		Debug.Log ("UNITY DEBUG LOG - Result length " + loadedMp3.length);  
	}
		
	void Awake () 
	{
		Audio = this.gameObject.GetComponent<AudioSource> ();
	}

	void Start()
	{
		//Find last playing track
		startingAudio = PlayerPrefs.GetString("song", "BG01");
//		Debug.Log ("UNITY DEBUG LOG - Starting Audio " + startingAudio);

		//Pass Track to Music Library Check
		LookForMusic (startingAudio);
	}
}
