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
		InvokeRepeating("SpawnHeroBlocks", .35f, 1.75f);
	}

    public void PauseSpawn()
    {
        CancelInvoke("SpawnHeroBlocks");
    }

    public void ResumeSpawn()
    {
        InvokeRepeating("SpawnHeroBlocks", 0.0f, 1.75f);
    }

	private void SpawnHeroBlocks ()
	{
		System.Random rng = new System.Random();

		foreach (Transform t in Spawners)
		{
            StartCoroutine(DelaySpawn(rng.Next(0,4), (float)rng.NextDouble(), t));
		}
	}

    IEnumerator DelaySpawn(int hero, float delay, Transform t)
    {
        yield return new WaitForSeconds(delay);
        var g = GameObject.Instantiate(Heroes[hero]);
		g.transform.SetParent(t, false);
    }
}
