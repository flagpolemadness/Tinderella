using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public List<Hero> DeadHeroes;
	public Boss DeadBoss;
	public GameObject Dialog;
	public Text DialogText;
	public GameObject GameBoard;

	//im tired and we can hack this for now
	private void Update ()
	{
		if (DeadHeroes.Count == 4)
		{
			Dialog.SetActive(true);
			DialogText.text = "You Lose";
			GameBoard.SetActive(false);
      }
		else if (DeadBoss != null)
		{
			Dialog.SetActive(true);
			DialogText.text = "You Win";
			GameBoard.SetActive(false);
		}
	}
}
