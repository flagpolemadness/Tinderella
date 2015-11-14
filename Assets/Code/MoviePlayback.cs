using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MoviePlayback : MonoBehaviour
{
	void Start ()
	{
		MovieTexture t = this.GetComponent<RawImage>().texture as MovieTexture;
		t.loop = true;
		t.Play();
   }
}
