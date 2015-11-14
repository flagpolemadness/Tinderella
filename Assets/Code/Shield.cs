using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// this will remove all blocks from the screen
public class Shield : Special
{
    private int[] attackDamage;
    public float _shieldLastsForSeconds = 8f;

    public override void DoMove()
    {
        Debug.Log("Doing Special Move: Shield");
        StartCoroutine(HaltDamage(_shieldLastsForSeconds));
    }

    IEnumerator HaltDamage(float delay)
    {
        Debug.Log("Shield: Setting AttackDamage to 0");
        var spawner = GameObject.FindGameObjectsWithTag("Hero");
        attackDamage = new int[spawner.Length + 1];
        foreach (var hero in spawner)
        {
            attackDamage[hero.GetComponent<Hero>().HeroId] = hero.GetComponent<Hero>().Attack;
            hero.GetComponent<Hero>().Attack = 0;
        }
        var boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<Boss>();
        attackDamage[boss.HeroId] = boss.Attack;
        boss.Attack = 0;
        yield return new WaitForSeconds(delay);

        Debug.Log("Shield: Resetting AttackDamage");
        spawner = GameObject.FindGameObjectsWithTag("Hero");
        foreach (var hero in spawner)
        {
            hero.GetComponent<Hero>().Attack = attackDamage[hero.GetComponent<Hero>().HeroId];
        }
        boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<Boss>();
        boss.Attack = attackDamage[boss.HeroId];
    }
}

