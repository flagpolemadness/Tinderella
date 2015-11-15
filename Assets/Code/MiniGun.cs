using UnityEngine;
using UnityEngine.UI;

// this will remove all blocks from the screen
public class MiniGun : Special
{
    public override void DoMove()
    {
        Debug.Log("Doing Special Move: MiniGun");
        var blocks = GameObject.FindGameObjectsWithTag("HeroBlock");
				var line = GameObject.FindGameObjectWithTag("Midline");
				bool above = this.transform.position.y > line.transform.position.y;
        foreach(var block in blocks)
        {
						if(above && block.transform.position.y > line.transform.position.y)
						{
							block.SetActive(false);
						}
						else if( !above && block.transform.position.y < line.transform.position.y)
						{
							block.SetActive(false);
						}	
            
        }
    }
}

