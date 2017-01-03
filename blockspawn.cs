using UnityEngine;
using System.Collections;

public class blockspawn : MonoBehaviour {

	public GameObject[] easyBlocks;
	public GameObject[] mediumBlocks;
	public GameObject[] HardBlocks;
	public Transform blockSpawnerPos;
	public int blockCount = 0;
	public float newPos = 5.0f;
	public int numberRoomSpawned;

	//private int randomNum;
	private float waitTime = 1.2f;
	private GameObject block;


	void Start () 
	{
		Block ();
		numberRoomSpawned = 0;
	}
	public void AddedRoomNumber(int room)
	{
		numberRoomSpawned += room;
	}

	public void Block()
	{
		if (numberRoomSpawned < 10) 
		{
			block = Instantiate (easyBlocks [Random.Range (0, easyBlocks.Length)], blockSpawnerPos.position, Quaternion.identity) as GameObject;
		}

		else if (numberRoomSpawned > 9 && numberRoomSpawned < 30) 
		{
			block = Instantiate (mediumBlocks [Random.Range (0, mediumBlocks.Length)], blockSpawnerPos.position, Quaternion.identity) as GameObject;
		}

		else if (numberRoomSpawned > 29) 
		{
			block = Instantiate (HardBlocks [Random.Range (0, HardBlocks.Length)], blockSpawnerPos.position, Quaternion.identity) as GameObject;
		}
			
		//block = Instantiate (blocks [Random.Range (0, blocks.Length)], blockSpawnerPos.position, Quaternion.identity) as GameObject;
		Vector3 temp = blockSpawnerPos.position;
		temp.y = 0;
		temp.x += newPos;
		temp.z = 0;
		blockSpawnerPos.position = temp;
//		StartCoroutine (Wait());
		GameObject UI = GameObject.FindGameObjectWithTag ("UI");
		UI.GetComponent<PowerUpSpawn> ().PUSPCheck ();
		UI.GetComponent<coin> ().LevelCheck ();
	}

	/*IEnumerator Wait ()
	{
	//	GameObject UI = GameObject.FindGameObjectWithTag ("UI");
	//	UI.GetComponent<PowerUpSpawn> ().PUSPCheck ();

		yield return new WaitForSeconds (waitTime);
		blockCount += 1;
		Block ();
	}*/
}
