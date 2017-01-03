using UnityEngine;
using System.Collections;
using System.Linq;

public class PowerUpSpawn : MonoBehaviour {

	public GameObject[] CurrentPowerUps;
	public GameObject[] CurrentMagnet;
	public GameObject[] CurrentCoinX2;
//	public GameObject[] Sup;
//	public GameObject[] Sdown;
	public GameObject[] PUSP;

	// Use this for initialization
	void Start () 
	{
		CurrentCoinX2 = GameObject.FindGameObjectsWithTag ("CoinX2");
		CurrentMagnet = GameObject.FindGameObjectsWithTag ("Magnet");
//		Sup = GameObject.FindGameObjectsWithTag ("SpeedUp");
//		Sdown = GameObject.FindGameObjectsWithTag ("SpeedDown");

		GameObject[] PUSP = GameObject.FindGameObjectsWithTag ("PUSP");

		CurrentPowerUps = CurrentCoinX2.Concat (CurrentMagnet).ToArray();
//		CurrentPowerUps = Sup.Concat (CurrentMagnet).ToArray();
//		CurrentPowerUps = Sdown.Concat (CurrentMagnet).ToArray();

		foreach(GameObject powerUpSP in PUSP)
		{
			Instantiate(CurrentPowerUps[Random.Range(0, CurrentPowerUps.Length)], powerUpSP.transform.position, powerUpSP.transform.rotation);
		}
	}
	
	// Update is called once per frame
	public void PUSPCheck () 
	{
		GameObject[] PUSP = GameObject.FindGameObjectsWithTag ("PUSP");

		foreach(GameObject powerUpSP in PUSP)
		{
			powerUpSP.gameObject.tag = ("Untagged");
			Instantiate(CurrentPowerUps[Random.Range(0, CurrentPowerUps.Length)], powerUpSP.transform.position, powerUpSP.transform.rotation);
		}
	}
}
