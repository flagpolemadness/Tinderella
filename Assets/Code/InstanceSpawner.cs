using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class InstanceSpawner : MonoBehaviour
{
	public List<Transform> Spawners;
	public List<GameObject> Heroes;

	private void Start()
	{
		InvokeRepeating("SpawnHeroBlocks", .35f, 3f);
	}

	private void SpawnHeroBlocks ()
	{
		System.Random rng = new System.Random();

		foreach (Transform t in Spawners)
		{
			var g = GameObject.Instantiate(Heroes[rng.Next(0, 4)]);
			g.transform.SetParent(t, false);
		}
	}
}
