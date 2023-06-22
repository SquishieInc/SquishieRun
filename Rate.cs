using UnityEngine;
using System.Collections;

public class Rate : MonoBehaviour 
{
	static string RATE = "rate";
	int mRate;
	public GameObject rateButton;

	void Start()
	{
		if (PlayerPrefs.HasKey (RATE)) {
			mRate = PlayerPrefs.GetInt (RATE);
		} else {
			PlayerPrefs.SetInt (RATE, mRate);
			if (mRate == -1) {
				rateButton.SetActive (false);
				return;
			}

		}
	}

	public void ShowNotification()
	{
		if (mRate == -1) {
			rateButton.SetActive (false);
			return;
		}

		#if UNITY_IOS
		iOSBridge.AddNotification ("Rate us", "Have you enjoyed the Game?",
			"Later", "Yes!", "No!");
		#endif
	}

	public void UserFeedBack(string id)
	{
		int selectedID;
		if (int.TryParse (id, out selectedID)) 
		{
			switch(selectedID)
			{
			case 1:
				Application.OpenURL ("https://itunes.apple.com/app/retrorun/id1099991381");
				//Application.OpenURL ("itms-apps://itunes.apple.com/WebObjects/MZStore.woa/wa/viewContentsUserReviews?id=\\(1099991381)&onlyLatestVersion=true&pageNumber=0&sortOrdering=1&type=Purple+Software)");
				break;
			case 2:
				mRate = -1;
				rateButton.SetActive (false);
				PlayerPrefs.SetInt (RATE, mRate);
				break;

			}
		}
		Debug.Log ("Unity Id: " + id);
	}
}
