using UnityEngine.UI;
using UnityEngine;

public class Special : MonoBehaviour
{

    public Slider SpecialBar;

    public virtual void DoMove()
    {

    }

    public void AddToSpecial(float value)
    {
        SpecialBar.value += value;
        if (SpecialBar.value >= 1)
        {
            Debug.Log("Doing Special Move Now ");
            SpecialBar.value = 0;
            DoMove();
        }
    }


}

