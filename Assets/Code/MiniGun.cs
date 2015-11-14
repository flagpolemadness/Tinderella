using UnityEngine;
using UnityEngine.UI;

// this will remove all blocks from the screen
public class MiniGun : Special
{
    public override void DoMove()
    {
        Debug.Log("Doing Special Move: MiniGun");
        var blocks = GameObject.FindGameObjectsWithTag("HeroBlock");
        foreach(var block in blocks)
        {
            block.SetActive(false);
        }
    }
}

