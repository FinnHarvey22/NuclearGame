using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Heat : MonoBehaviour
{
	// Start is called before the first frame update

	public Slider HeatSlider;
	private Image Fill;
	[SerializeField] private float FillSpeed = 0.1f;
	[SerializeField] private float heat = 200;
	private bool cooling;
    void Start()
    {
        Fill = GameObject.Find("Fill Heat").GetComponent<Image>();
		StartCoroutine(FillChange());
	}

    // Update is called once per frame
    void Update()
	{

			Fill.color = Color.Lerp(Color.blue, Color.red, heat / 1000);

		if (!cooling)
		{
			heat += FillSpeed;
		}
		else if (cooling)
		{
			heat -= 0.3f;
		}
		HeatSlider.value = heat;

		if (heat <= 0)
		{
			heat = 0;
		}
		if (heat >= HeatSlider.maxValue)
		{
			//Game Over! (TBD)
		}

	}

	public void Cool()
	{
		cooling = true;
		StartCoroutine(CoolingTime());
		
	}

	public IEnumerator CoolingTime()
	{
		yield return new WaitForSeconds(3);
		cooling = false;
	}

	public IEnumerator FillChange()
	{
		yield return new WaitForSeconds(30);
		FillSpeed += 0.1f;
		StartCoroutine(FillChange());

	}
}
