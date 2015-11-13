using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Hero : MonoBehaviour
{
	public int Health;
	public Text Name;
	public int Attack;
	public Slider HealthBar;
	public Slider SpecialBar;
	public int HeroId;

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
}
