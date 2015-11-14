using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Hero : MonoBehaviour
{
	public int Health;
	public Text Name;
	public int Attack;
	public Slider HealthBar;
<<<<<<< HEAD
	public int HeroId;
    public Special special;
    
=======
	public Slider SpecialBar;
	public int HeroId;
>>>>>>> e913eda54e44815e2d3a4fd2d1d78c974cb05553

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
<<<<<<< HEAD

    public void UpdateSpecial(float value)
    {
        special.AddToSpecial(value);
    }

    public void ResetSpecial()
    {
        special.SpecialBar.value = 0;
    }
=======
>>>>>>> e913eda54e44815e2d3a4fd2d1d78c974cb05553
}
