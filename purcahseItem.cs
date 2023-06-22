using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class purcahseItem : MonoBehaviour {

	public string buttonName;
	private int pricePaid;
	private bool bought;

	public int amountNeeded = 100;

	public Button itemBought;
	private GameObject ui;

	public int uiBank;

	// Use this for initialization
	void Start () 
	{
		ui = GameObject.FindGameObjectWithTag ("UI");

		buttonName = gameObject.name;
		pricePaid = PlayerPrefs.GetInt (buttonName, 0);

		if (pricePaid > 0) {
			bought = true;
			itemBought.interactable = true;
			//gameObject.GetComponent<Button> ().interactable = false;
			gameObject.SetActive(false);

		} else {
			itemBought.GetComponent<Button> ().interactable = false;
			gameObject.GetComponent<Button> ().interactable = true;
		}
		if (amountNeeded < uiBank) 
		{
			gameObject.GetComponent<Button> ().interactable = true;
		}

		if (bought) {
			gameObject.SetActive(false);
		}
	
	}

	void Update()
	{
		if (bought) {
			gameObject.SetActive(false);
		}
		uiBank = UIcontroller.bank;
		if (amountNeeded > uiBank || pricePaid == amountNeeded) 
		{
			gameObject.GetComponent<Button> ().interactable = false;
			//gameObject.SetActive(false);
		}
		else if (amountNeeded < uiBank && pricePaid < amountNeeded || amountNeeded == uiBank && pricePaid < amountNeeded) 
		{
			gameObject.GetComponent<Button> ().interactable = true;
		}
/*		else if (amountNeeded == uiBank) 
		{
			gameObject.GetComponent<Button> ().interactable = true;
		}*/
	}
	
	public void PayForItem(int itemCost)
	{
		if(itemCost <= uiBank)
		{
			ui = GameObject.FindGameObjectWithTag ("UI");
			ui.GetComponent<UIcontroller> ().UpdateBankAfterPurchase (itemCost);
			bought = true;
			pricePaid = itemCost;
			PlayerPrefs.SetInt (buttonName, pricePaid);
			itemBought.interactable = true;
			//gameObject.GetComponent<Button> ().interactable = false;
			gameObject.SetActive(false);
		}
/*		
 		ui = GameObject.FindGameObjectWithTag ("UI");
		ui.GetComponent<UIcontroller> ().UpdateBankAfterPurchase (itemCost);
		pricePaid = itemCost;
		PlayerPrefs.SetInt (buttonName, pricePaid);
		itemBought.interactable = true;
		gameObject.GetComponent<Button> ().interactable = false;
*/
	}
}
