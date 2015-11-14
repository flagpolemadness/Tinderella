using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Hero : MonoBehaviour
{
	public int Health;
	public Text Name;
	public int Attack;
	public Slider HealthBar;
	public int HeroId;
    public Special special;
    

	//some dumb shit where the collision boxes will randomly be assigned a weird floating point error
	//i don't fucking know unity is trash
	public void Awake()
	{
		gameObject.SetActive(false);
		gameObject.SetActive(true);
	}
	public void UpdateHealth(int health)
	{
		HealthBar.value = health;
	}

    public void UpdateSpecial(float value)
    {
        special.AddToSpecial(value);
    }

    public void ResetSpecial()
    {
        special.SpecialBar.value = 0;
    }
}
