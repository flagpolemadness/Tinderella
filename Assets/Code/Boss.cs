using UnityEngine;
using System.Collections;

public class Boss : Hero
{
	private void Update()
	{
<<<<<<< HEAD
		UpdateSpecial(Time.smoothDeltaTime/10f);
=======
		SpecialBar.value += (Time.smoothDeltaTime/10f);
>>>>>>> e913eda54e44815e2d3a4fd2d1d78c974cb05553
	}
}
