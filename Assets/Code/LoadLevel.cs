using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour
{
	public string LevelLoad;

	public void NextScene()
	{
		Application.LoadLevel(LevelLoad);

		GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
		foreach (GameObject go in allObjects)
			if (go.activeSelf)
				Destroy(go);
	}
}
