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
	private bool venting;
    void Start()
    {
        Fill = GameObject.Find("Fill Heat").GetComponent<Image>();
		StartCoroutine(FillChange());
	}

    // Update is called once per frame
    void Update()
	{

			Fill.color = Color.Lerp(Color.blue, Color.red, heat / 1000);

		if (!venting)
		{
			heat += FillSpeed;
		}
		else if (venting)
		{
			heat -= 0.5f;
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

	public void Vent()
	{
		venting = true;
		StartCoroutine(VentingTime());
		
	}

	public IEnumerator VentingTime()
	{
		yield return new WaitForSeconds(3);
		venting = false;
	}

	public IEnumerator FillChange()
	{
		yield return new WaitForSeconds(30);
		FillSpeed += 0.1f;
		StartCoroutine(FillChange());

	}
}
