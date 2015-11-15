using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HeroBlock : MonoBehaviour
{
	public int HeroId;
	private Boss Boss;
	private List<Hero> Heroes;
  private bool hasBeenClicked = false;
  private bool following = false;
  private HeroBlock followBlock;

  // So you can grab any point on the block and drag it
  private Vector3 offset;

  // So you can grab multiple blocks
  private List<HeroBlock> GroupedBlocks;

	private void Start()
	{
        this.Heroes = new List<Hero>();
        this.Boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<Boss>();
        var g = GameObject.FindGameObjectsWithTag("Hero");
        foreach (GameObject h in g)
        {
            var hero = h.GetComponent<Hero>();
            this.Heroes.Add(hero);
        }
	}

	void Update()
	{    
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        bool overSprite = this.GetComponent<SpriteRenderer>().bounds.Contains(mousePosition);

        if (overSprite && Input.GetButtonDown("Fire1"))
        {
            hasBeenClicked = true;
            offset = this.GetComponent<SpriteRenderer>().bounds.center - new Vector3(mousePosition.x, mousePosition.y, 0.0f);
        }
        if (hasBeenClicked)
        {
            //this.GetComponent<Rigidbody2D>().isKinematic = true;
            Vector3 target = new Vector3(mousePosition.x + offset.x, mousePosition.y + offset.y, 0.0f);
            this.transform.position = Vector3.MoveTowards(this.transform.position, target, 25*Time.deltaTime);
        }
        else if(following)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, this.followBlock.transform.position, 20 * Time.deltaTime);
        }

        if (Input.GetButtonUp("Fire1"))
        {
            this.hasBeenClicked = false;
            if(this.following)
            {
              this.following = false;
            }
            if(this.GroupedBlocks != null)
            {
              foreach(HeroBlock block in this.GroupedBlocks)
              {
                if(block != null)
                  block.GetComponent<Rigidbody2D>().isKinematic = false;
              }
            }
        }
	}

  public void StickToMe(HeroBlock block)
  {
      //this.hasBeenClicked = true;
      this.following = true;
      this.followBlock = block;
  }

	public void OnCollisionEnter2D(Collision2D coll)
	{
        Hero hero = coll.gameObject.GetComponent<Hero>();
        if (hero != null)
        {
            if (hero.HeroId == HeroId)
            {
                hero.UpdateSpecial(0.1f);
                this.Boss.Health -= coll.gameObject.GetComponent<Hero>().Attack;
                if (this.Boss.Health <= 0f)
                {
                    GameObject g = GameObject.FindGameObjectWithTag("GameManager");
                    g.GetComponent<GameManager>().DeadBoss = this.Boss;
                }
                this.Boss.UpdateHealth(this.Boss.Health);
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
            // gonna make blocks of the same hero stick to this when they overlap
            //HeroBlock block = coll.gameObject.GetComponent<HeroBlock>();
            //if(block.HeroId == this.HeroId && this.hasBeenClicked)
            //{
            //    if(this.GroupedBlocks == null)
            //    {
            //      this.GroupedBlocks = new List<HeroBlock>();
            //      this.GroupedBlocks.Add(this);
            //    }
            //    // make this fucking block stick to me
            //    block.StickToMe(GroupedBlocks[GroupedBlocks.Count - 1]);
            //    //block.GetComponent<Rigidbody2D>().isKinematic = true;
            //    this.GroupedBlocks.Add(block);
            //}
        }
        else
        {
            foreach (Hero h in this.Heroes)
            {
                if (h.HeroId == this.HeroId)
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