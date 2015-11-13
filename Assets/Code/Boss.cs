using UnityEngine;
using System.Collections;

public class Boss : Hero
{
	private void Update()
	{
		SpecialBar.value += (Time.smoothDeltaTime/10f);
	}
}
