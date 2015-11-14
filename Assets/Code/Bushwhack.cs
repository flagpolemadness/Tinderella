using UnityEngine;
using UnityEngine.UI;
using System.Collections;


// this will remove all blocks from the screen
public class Bushwhack : Special 
{
    public override void DoMove()
    {
        Debug.Log("Doing Special Move: Bushwhack");
        StartCoroutine("PauseBlocks");
    }

    IEnumerator PauseBlocks()
    {
        Debug.Log("Bushwhack: pausing spawning and blocks and waiting ten seconds");
        GameObject.FindGameObjectWithTag("Spawner").GetComponent<InstanceSpawner>().PauseSpawn();
        var blocks = GameObject.FindGameObjectsWithTag("HeroBlock");
        foreach (var block in blocks)
        {
            if(block.GetComponent<Rigidbody2D>() != null)
            {
                Debug.Log("Bushwhack: setting kinematic to true");
                block.GetComponent<Rigidbody2D>().isKinematic = true;
            }
            else
            { Debug.Log("Bushwhack: kinematic was null"); }
        }
        yield return new WaitForSeconds(10);
        Debug.Log("Bushwhack: resuming spawning and blocks");
        GameObject.FindGameObjectWithTag("Spawner").GetComponent<InstanceSpawner>().ResumeSpawn();
        blocks = GameObject.FindGameObjectsWithTag("HeroBlock");
        foreach (var block in blocks)
        {
            if (block.GetComponent<Rigidbody2D>() != null)
            {
                Debug.Log("Bushwhack: setting kinematic to false");
                block.GetComponent<Rigidbody2D>().isKinematic = false;
            }
            else
            { Debug.Log("Bushwhack: kinematic was null"); }
        }
    }
}