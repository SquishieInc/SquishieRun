using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour {

	public bool loadScene = false;

	[SerializeField]
	private int scene;

	[SerializeField]
	private Text loadingText;
	public string whatIsLoading;
	// Updates once per frame

	public float waitTime;

	/*	public void BeginLoad(bool load)
	{
		loadScene = load;
	}*/

	void Start()
	{
		Time.timeScale = 1f;
	}

	void Update() 
	{
		if (waitTime > 0) 
		{
			loadingText.color = new Color(loadingText.color.r, loadingText.color.g, loadingText.color.b, Mathf.PingPong(Time.time, 1));
			loadingText.text = "Loading " + whatIsLoading;

			waitTime -= Time.deltaTime;
			if (waitTime <= 0) 
			{
				Application.LoadLevel (1);
				//Destroy (gameObject);

			}
		}
	}
/*		// If the new scene has started loading...
		if (loadScene == true) 
		{
			// ...change the instruction text to read "Loading..."
			loadingText.text = "Loading...";
			// ...and start a coroutine that will load the desired scene.
			StartCoroutine(LoadNewScene());
			// ...then pulse the transparency of the loading text to let the player know that the computer is still working.
			loadingText.color = new Color(loadingText.color.r, loadingText.color.g, loadingText.color.b, Mathf.PingPong(Time.time, 1));
			loadingText.text = "Loading " + whatIsLoading;
		}
	}

	// The coroutine runs on its own at the same time as Update() and takes an integer indicating which scene to load.
	IEnumerator LoadNewScene() {
		Debug.Log ("loading level");
		// This line waits for 3 seconds before executing the next line in the coroutine.
		// This line is only necessary for this demo. The scenes are so simple that they load too fast to read the "Loading..." text.
		yield return new WaitForSeconds(3);
		// Start an asynchronous operation to load the scene that was passed to the LoadNewScene coroutine.
		AsyncOperation async = Application.LoadLevelAsync(scene);
		yield return async;
		Debug.Log ("Level Loaded");
		// While the asynchronous operation to load the new scene is not yet complete, continue waiting until it's done.
		while (!async.isDone) {
			yield return null;
		}
	}*/
}