using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HeroBlock : MonoBehaviour
{
	public int HeroId;
	private Boss Boss;
	private List<Hero> Heroes;

	private void Start()
	{
		Heroes = new List<Hero>();
		Boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<Boss>();
		var g = GameObject.FindGameObjectsWithTag("Hero");
		foreach (GameObject h in g)
		{
			var hero = h.GetComponent<Hero>();
			Heroes.Add(hero);
		}
	}

	void Update()
	{    
		Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		bool overSprite = this.GetComponent<SpriteRenderer>().bounds.Contains(mousePosition);
		if (overSprite)
		{
			if (Input.GetButton("Fire1"))
			{
				this.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0.0f);
			}
		}
	}

	public void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.GetComponent<Hero>())
		{
			if (coll.gameObject.GetComponent<Hero>().HeroId == HeroId)
			{
				coll.gameObject.GetComponent<Hero>().SpecialBar.value += 0.1f;
				Boss.Health -= coll.gameObject.GetComponent<Hero>().Attack;
				if (Boss.Health <= 0f)
				{
					GameObject g = GameObject.FindGameObjectWithTag("GameManager");
					g.GetComponent<GameManager>().DeadBoss = Boss;
				}
				Boss.UpdateHealth(Boss.Health);
				Destroy(gameObject);
			}
			else
			{
				foreach (Hero h in Heroes)
				{
					if (h.HeroId == HeroId)
					{
						h.Health -= h.Attack;
						if (h.Health <= 0f)
						{
							GameObject g = GameObject.FindGameObjectWithTag("GameManager");
							g.GetComponent<GameManager>().DeadHeroes.Add(h);
						}
						h.UpdateHealth(h.Health);
						Destroy(gameObject);
					}
				}
			}
		}
		else
		{
			foreach (Hero h in Heroes)
			{
				if (h.HeroId == HeroId)
				{
					h.Health -= h.Attack;
					if (h.Health <= 0f)
					{
						GameObject g = GameObject.FindGameObjectWithTag("GameManager");
						g.GetComponent<GameManager>().DeadHeroes.Add(h);
					}
					h.UpdateHealth(h.Health);
					Destroy(gameObject);
				}
			}
		}
	}
}