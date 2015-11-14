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
<<<<<<< HEAD
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

=======
		InvokeRepeating("SpawnHeroBlocks", .35f, 3f);
	}

>>>>>>> e913eda54e44815e2d3a4fd2d1d78c974cb05553
	private void SpawnHeroBlocks ()
	{
		System.Random rng = new System.Random();

		foreach (Transform t in Spawners)
		{
<<<<<<< HEAD
            StartCoroutine(DelaySpawn(rng.Next(0,4), (float)rng.NextDouble(), t));
		}
	}

    IEnumerator DelaySpawn(int hero, float delay, Transform t)
    {
        yield return new WaitForSeconds(delay);
        var g = GameObject.Instantiate(Heroes[hero]);
		g.transform.SetParent(t, false);
    }
=======
			var g = GameObject.Instantiate(Heroes[rng.Next(0, 4)]);
			g.transform.SetParent(t, false);
		}
	}
>>>>>>> e913eda54e44815e2d3a4fd2d1d78c974cb05553
}
