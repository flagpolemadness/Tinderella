using UnityEngine;
using UnityEngine.UI;

// this will remove all blocks from the screen
public class GravityPulse : Special
{
    public override void DoMove()
    {
        Debug.Log("Doing Special Move: GravityPulse");
        Physics.gravity = Vector3.Scale(new Vector3(1500f, 1500f, 1500f), Physics.gravity);
    }
}

