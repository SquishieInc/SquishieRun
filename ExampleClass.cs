using UnityEngine;
using System.Collections;

public class ExampleClass : MonoBehaviour {
	IEnumerator Start() {
		AsyncOperation async = Application.LoadLevelAsync("Scene 1");
		yield return async;
		Debug.Log("Loading complete");
	}
}