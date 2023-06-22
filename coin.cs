using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class coin : MonoBehaviour {

	public AudioClip coinSound;
	public AudioClip magPowerUpSound;
	public AudioClip coinX2Sound;
	private AudioSource Audio;

	public bool coinMag = false;
	public float timer = 0;

	private int coinValue = 1;
	public bool coinX2 = false;
	public float coinX2timer = 0;
	public GameObject[] currentCoins;
	public GameObject[] M;
	public GameObject[] X2;
//	public GameObject[] Sup;
//	public GameObject[] Sdown;

	public Text powerUpText;
	public float waitTime;

	// Use this for initialization
	void Start () 
	{
		Audio = GetComponent<AudioSource> ();
		powerUpText.text = " ";
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (waitTime > 0) 
		{
			powerUpText.color = new Color(powerUpText.color.r, powerUpText.color.g, powerUpText.color.b, Mathf.PingPong(Time.time, 1));
			waitTime -= Time.deltaTime;
			if (waitTime <= 0) 
			{
				waitTime = 0;
				powerUpText.text = " ";
			}
		}

		if(coinMag)
		{
			timer += 1 * Time.deltaTime;
			if(timer >= 10)
			{
				coinMag = false;
				timer = 0;
			}
		}

		if(coinX2)
		{
			coinX2timer += 1 * Time.deltaTime;
			if(coinX2timer >= 10)
			{
				coinX2 = false;
				coinX2timer = 0;
			}
		}

		GameObject P = GameObject.FindGameObjectWithTag ("Player");
		LevelCheck ();
		//GameObject[] currentCoins = GameObject.FindGameObjectsWithTag("Coin");
		//GameObject[] M = GameObject.FindGameObjectsWithTag ("Magnet");
		//GameObject[] X2 = GameObject.FindGameObjectsWithTag ("CoinX2");

		foreach (GameObject Coin in currentCoins) 
		{
			if (!coinX2) 
			{
				coinValue = 1;
			}
			else
			if (coinX2) 
			{
				coinValue = 2;
			}
			if(Coin != false)
			{
				if (Vector3.Distance (Coin.transform.position, P.transform.position) < 0.5) 
				{
					Destroy (Coin.gameObject);
					Audio.PlayOneShot (coinSound, 0.7f);
					GameObject UI = GameObject.FindGameObjectWithTag ("UI");
					UI.GetComponent<UIcontroller> ().CoinPlus (coinValue);
				}
			}
			if (coinMag) 
			{
				if (Coin != false) 
				{
					if (Vector3.Distance (Coin.transform.position, P.transform.position) < 5) 
					{
						Coin.transform.Translate ((P.transform.position - Coin.transform.position).normalized * 4 * Time.deltaTime, Space.World);
					}
				}
			}
		}

		if(M != null)
		{
			foreach (GameObject Magnet in M) 
			{
				if(Magnet != false)
				{
					if (Vector3.Distance (Magnet.transform.position, P.transform.position) < 0.5) 
					{
						Destroy (Magnet.gameObject);
						waitTime = 10;
						powerUpText.text = "Magnet!";
						if (!coinMag) 
						{
							coinMag = true;
							Audio.PlayOneShot (magPowerUpSound, 0.7f);
						}
					}
				}
			}
		}

		if(X2 != null)
		{
			foreach (GameObject CoinX2 in X2) 
			{
				if(CoinX2 != false)
				{
					if (Vector3.Distance (CoinX2.transform.position, P.transform.position) < 0.5)
					{
						Destroy (CoinX2.gameObject);
						waitTime = 10;
						powerUpText.text = "Multiplier!";
						if (!coinX2) 
						{
							coinX2 = true;
							Audio.PlayOneShot (coinX2Sound, 0.7f);
						}
					}
				}
			}
		}
/*
		if(Sup != null)
		{
			foreach (GameObject SpeedUp in Sup) 
			{
				if(SpeedUp != false)
				{
					if (Vector3.Distance (SpeedUp.transform.position, P.transform.position) < 0.5)
					{
						Destroy (SpeedUp.gameObject);
						waitTime = 10;
						powerUpText.text = "Speed Up!";
					}
				}
			}
		}

		if(Sdown != null)
		{
			foreach (GameObject SpeedDown in Sup) 
			{
				if(SpeedDown != false)
				{
					if (Vector3.Distance (SpeedDown.transform.position, P.transform.position) < 0.5)
					{
						Destroy (SpeedDown.gameObject);
						waitTime = 10;
						powerUpText.text = "Speed Down!";
					}
				}
			}
		}*/
	}

	public void LevelCheck()
	{
		currentCoins = GameObject.FindGameObjectsWithTag("Coin");
		M = GameObject.FindGameObjectsWithTag ("Magnet");
		X2 = GameObject.FindGameObjectsWithTag ("CoinX2");
//		Sup = GameObject.FindGameObjectsWithTag ("SpeedUp");
//		Sdown = GameObject.FindGameObjectsWithTag ("SpeedDown");
	}
}
