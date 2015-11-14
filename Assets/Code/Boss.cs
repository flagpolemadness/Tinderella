using UnityEngine;
using System.Collections;

public class Boss : Hero
{
	private void Update()
	{
		UpdateSpecial(Time.smoothDeltaTime/10f);
	}
}
