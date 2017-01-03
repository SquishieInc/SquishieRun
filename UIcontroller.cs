using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;

public class UIcontroller : MonoBehaviour {

	public int levelLayout = 0;
	public GameObject[] levelBG;
	public GameObject[] Enemies;
	public GameObject[] Coins;
	public GameObject Player;
	private GameObject Camera;

	public GameObject mainMenu;
	public Text HIGHSCORE;
	public Text HIGHSCORE2;
	public GameObject YOUDIED;


	static public int highscoreScore;
	static public int score;
	public Text SCORE;
	public Text GOSCORE;

	public int coins;
	public Text COINS;
	public Text GOCOINS;

	static public int bank;
	public Text BANK;
	public Text DEADBANK;

	public GameObject INGAMEUI;


	//Players health
	public int health = 3;
	public GameObject health1;
	public GameObject health2;
	public GameObject health3;
	public float timeToRecover = 10;
	public bool playing;

	public bool adReady;
	public static int IAP_ADS_ON;

	public GameObject gameCenterButton;
	private GameCenter gameCenter;
	public string leaderboardID;


	void Start () 
	{
		
		bank = PlayerPrefs.GetInt ("Bank", 0);
		levelLayout = PlayerPrefs.GetInt ("Layout", 0);

		IAP_ADS_ON = PlayerPrefs.GetInt ("ADS", 0);
		score = 0;
		Debug.Log ("IAP ads State = " + IAP_ADS_ON);


		levelBG = GameObject.FindGameObjectsWithTag ("BG");
		Enemies = GameObject.FindGameObjectsWithTag ("Death");
		Coins = GameObject.FindGameObjectsWithTag ("Coin");
		Player = GameObject.FindGameObjectWithTag ("Player");

		playing = false;

		adReady = true;

		YOUDIED.SetActive (false);

		health1.SetActive (false);
		health2.SetActive (false);
		health3.SetActive (false);

		INGAMEUI.SetActive (false);

		mainMenu.SetActive (true);
//		Time.timeScale = 0f;
		highscoreScore = PlayerPrefs.GetInt ("Highscore", 0);

		gameCenter = GetComponent<GameCenter> ();

		#if UNITY_IOS
		gameCenterButton.SetActive(true);
		#endif
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
	
	// Update is called once per frame
	void Update () 
	{
		if (playing == true && health > 0) 
		{
			//SCORE.text = "Score: " + score;
			INGAMEUI.SetActive (true);
			SCORE.text = score + "m";
			BANK.text = "";
			COINS.text = "Coins: " + coins;
			HIGHSCORE2.text = "Best: " + highscoreScore + "m";

		} else 
		{
			SCORE.text = "";
			BANK.text = "" + bank;
			DEADBANK.text = "" + bank;
			COINS.text = "";
			HIGHSCORE2.text = "";
		}

		if (health < 3) 
		{
			timeToRecover -= Time.deltaTime;
			if(timeToRecover < 0)
			{
				Player.GetComponent<player> ().RecoverHealth ();
				timeToRecover = 10;
				health += 1;
			}
		}

		if (playing == true) 
		{
			if (health == 3) {
				health1.SetActive (true);
				health2.SetActive (true);
				health3.SetActive (true);
			}
			if (health == 2) {
				health1.SetActive (false);
				health2.SetActive (true);
				health3.SetActive (true);
			}
			if (health == 1) {
				health1.SetActive (false);
				health2.SetActive (false);
				health3.SetActive (true);
			}
			if (health == 0) {
				health1.SetActive (false);
				health2.SetActive (false);
				health3.SetActive (false);
				player.CaptureScreen ();
			}

			if (health <= 0 && adReady == true) 
			{
				gameCenter.ReportScore (highscoreScore, leaderboardID);
				//ShowAd ();
				Debug.Log ("game has passed showads");
				playing = false;
				YOUDIED.SetActive (true);
				INGAMEUI.SetActive (false);
				SCORE.text = "";
				GOSCORE.text = score + "m";
				BANK.text = "";
				COINS.text = "";
				GOCOINS.text = "Coins: " + coins;
				HIGHSCORE2.text = "Best: " + highscoreScore + "m";
				Time.timeScale = 0.0f;
				Player.GetComponent<player> ().PlayingGame (false);
				Player.GetComponent<player> ().ResetPlayerModifiers ();
			}
		}
		HIGHSCORE.text = "High Score: " + highscoreScore;
	}

	public void CoinPlus(int newCoins)
	{
		coins += newCoins;
		bank += newCoins;
		PlayerPrefs.SetInt ("Bank", bank);
	}

	public void ClickedStart () 
	{
		playing = true;
		mainMenu.SetActive (false);
		Time.timeScale = 1f;

		Camera = GameObject.FindGameObjectWithTag ("MainCamera");
	}

	static public void ScorePlus(int NewScore)
	{
		score += NewScore;
		if(score >= highscoreScore)
		{
			highscoreScore = score;
			PlayerPrefs.SetInt ("Highscore", score);
		}
	}

	public void ClickedQuit () 
	{
		//Application.Quit ();
		SceneManager.LoadScene (0);
		PlayerPrefs.DeleteAll ();
	}

	public void ClickedRestart () 
	{
		Time.timeScale = 1f;
		health = 3;
		//Application.LoadLevel (1);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void TakeDamage()
	{
		health--;
	}

	public static void IAPChangeAds(int adChange)
	{
		IAP_ADS_ON = adChange;
		Debug.Log ("IAP ads State = " + IAP_ADS_ON);
		PlayerPrefs.SetInt ("ADS", IAP_ADS_ON);
	}

	public void ShowAd()
	{
		Debug.Log ("ad attempting to playing");
		Debug.Log (IAP_ADS_ON + " = if ads will play");
		if(IAP_ADS_ON != 1)
		{
			adReady = false;
			Debug.Log ("ad will play");
			if (Advertisement.IsReady())
			{
				var options = new ShowOptions {resultCallback = HandleShowResultSkip};
				Advertisement.Show (null, options);
				Debug.Log ("ad playing");
			}
		}
	}

	private void HandleShowResultSkip (ShowResult result)
	{
		switch (result) 
		{
		case ShowResult.Finished:
			Debug.Log("Ad Played Through");
			break;

		case ShowResult.Skipped:
			Debug.Log("Ad Skipped");
			break;

		case ShowResult.Failed:
			Debug.Log("Ad Failed");
			break;
		}
	}

	public void ShowRewardAd()
	{
		if (Advertisement.IsReady("rewardedVideo"))
		{
			Debug.Log ("Ad is ready to be played");
			var options = new ShowOptions {resultCallback = HandleShowResult};
			Advertisement.Show ("rewardedVideo", options);
		}
	}

	private void HandleShowResult (ShowResult result)
	{
		switch (result) 
		{
		case ShowResult.Finished:
			Debug.Log("Award Player 25 coins");
			bank += 200;
			PlayerPrefs.SetInt ("Bank", bank);
			break;

		case ShowResult.Skipped:
			Debug.Log("Ad Skipped");
			break;

		case ShowResult.Failed:
			Debug.Log("Ad Failed");
			break;
		}
	}
	public void UpdateBankAfterPurchase(int updateAmount)
	{
		bank -= updateAmount;
		PlayerPrefs.SetInt ("Bank", bank);
	}

	static public void FacebookReward(int reward)
	{
		bank += reward;
		PlayerPrefs.SetInt ("Bank", bank);
	}

	/*
	public void ShowNotification()
	{
		#if UNITY_IOS
		iOSBridge.AddNotification ("Rate us", "Have you enjoyed the Game?",
			"Later", "Yes!", "No!");
		#endif
	}
	*/
}