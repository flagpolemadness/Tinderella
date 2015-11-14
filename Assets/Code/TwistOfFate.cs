using UnityEngine;
using UnityEngine.UI;

// this will remove all blocks from the screen
public class TwistOfFate : Special
{
    public override void DoMove()
    {
        Debug.Log("Doing Special Move: TwistOfFate");
        var blocks = GameObject.FindGameObjectsWithTag("HeroBlock");
        foreach (var block in blocks)
        {
            Debug.Log("TwistOfFate: Instantiating a new block of this hero");
            int id = transform.GetComponent<Hero>().HeroId;
            var spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<InstanceSpawner>();
            var go = GameObject.Instantiate(spawner.Heroes[id-1]);

            // because the gameobject they are normally instantiated under has this scale
            go.transform.localScale = Vector3.Scale(go.transform.localScale, new Vector3(1.41625f, 1.41625f, 1.41625f));

            // to get them to behave properly for edge cases such as ending the game
            go.transform.SetParent(block.transform.parent);

            // to get them in the exact position of the bock they are replacing
            go.transform.position = block.transform.position;

            // because they start at a standstill
            if(block.GetComponent<Rigidbody2D>() != null)
            {
                go.GetComponent<Rigidbody2D>().velocity = block.GetComponent<Rigidbody2D>().velocity;
            }

            // get rid of that other block
            Destroy(block);
        }
    }
}

