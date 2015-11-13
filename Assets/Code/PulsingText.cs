using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PulsingText : MonoBehaviour
{
	Text FlashingText;
	private string Empty = "";
	public string NotEmpty;

	void Start()
	{
		FlashingText = GetComponent<Text>();
		StartCoroutine(BlinkText());
	}

	public IEnumerator BlinkText()
	{
		while (true)
		{
			FlashingText.text = Empty;
			yield return new WaitForSeconds(.5f);
			FlashingText.text = NotEmpty;
			yield return new WaitForSeconds(.5f);
		}
	}
}