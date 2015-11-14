using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HeroBlock : MonoBehaviour
{
	public int HeroId;
	private Boss Boss;
	private List<Hero> Heroes;
<<<<<<< HEAD
    private bool hasBeenClicked = false;

    // So you can grab any point on the block and drag it
    private Vector3 offset;
=======
>>>>>>> e913eda54e44815e2d3a4fd2d1d78c974cb05553

	private void Start()
	{
		Heroes = new List<Hero>();
		Boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<Boss>();
<<<<<<< HEAD
        var g = GameObject.FindGameObjectsWithTag("Hero");
=======
		var g = GameObject.FindGameObjectsWithTag("Hero");
>>>>>>> e913eda54e44815e2d3a4fd2d1d78c974cb05553
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
<<<<<<< HEAD

        if (overSprite && Input.GetButtonDown("Fire1"))
        {
            hasBeenClicked = true;
            offset = this.GetComponent<SpriteRenderer>().bounds.center - new Vector3(mousePosition.x, mousePosition.y, 0.0f);
        }
		if (hasBeenClicked)
		{
            this.transform.position = new Vector3(mousePosition.x+offset.x, mousePosition.y+offset.y, 0.0f);
		}

        if (Input.GetButtonUp("Fire1"))
        {
            hasBeenClicked = false;
        }
		
=======
		if (overSprite)
		{
			if (Input.GetButton("Fire1"))
			{
				this.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0.0f);
			}
		}
>>>>>>> e913eda54e44815e2d3a4fd2d1d78c974cb05553
	}

	public void OnCollisionEnter2D(Collision2D coll)
	{
<<<<<<< HEAD
        Hero hero = coll.gameObject.GetComponent<Hero>();
        if (hero != null)
        {
            if (hero.HeroId == HeroId)
            {
                hero.UpdateSpecial(0.1f);
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
        else if (coll.gameObject.GetComponent<HeroBlock>() != null)
        {
            // Do something awesome in the future
            // YOU HAVE THE POWER
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
=======
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
>>>>>>> e913eda54e44815e2d3a4fd2d1d78c974cb05553
	}
}