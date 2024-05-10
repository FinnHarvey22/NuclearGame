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
	private float FillSpeed = 1.5f;
	[SerializeField] private float heat = 200;
	private bool cooling;
	private ScoreSystem controller;
    void Start()
    {
        Fill = GameObject.Find("Fill Heat").GetComponent<Image>();
		StartCoroutine(FillChange());
		controller = GetComponent<ScoreSystem>();

	}

    // Update is called once per frame
    void Update()
	{
		HeatSlider.value = heat;
		Fill.color = Color.Lerp(Color.blue, Color.red, heat / 1000);
		if (heat <= 0)
		{
			heat = 0;
		}
		if (heat >= HeatSlider.maxValue)
		{
			controller.Loss();
		}

	}

	private void FixedUpdate()
	{
		if (!cooling && controller.GameOver == false)
		{
			heat += FillSpeed;
		}
		else if (cooling)
		{
			heat -= 3.0f;
		}
		
	}

	public void Cool()
	{
		cooling = true;
		StartCoroutine(CoolingTime());
		
	}

	public IEnumerator CoolingTime()
	{
		yield return new WaitForSecondsRealtime(3);
		cooling = false;
	}

	public IEnumerator FillChange()
	{
		yield return new WaitForSecondsRealtime(30);
		FillSpeed += 0.5f;
		StartCoroutine(FillChange());

	}
}
