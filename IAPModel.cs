using UnityEngine;
using System.Collections;

public class IAPModel : MonoBehaviour 
{

	public void Buy100()
	{
		IAPManager.Instance.Buy100Gold ();
	}

	public void Buy500()
	{
		IAPManager.Instance.Buy500Gold ();
	}

	public void BuyNoAds()
	{
		IAPManager.Instance.BuyNoAds();
	}
}