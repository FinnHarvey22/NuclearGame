using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelControl : MonoBehaviour
{

	public Slider[] FuelRods;
	private ScoreSystem controller;
    // Start is called before the first frame update
    void Start()
    {
		controller = GetComponent<ScoreSystem>();
    }

    // Update is called once per frame
    void Update()
    {
	

		
	
    }
	private void FixedUpdate()
	{
		FuelRods[Random.Range(0, FuelRods.Length)].value -= 0.5f;

		foreach (var fuel in FuelRods)
		{
			if (fuel.value <= fuel.minValue)
			{
				controller.Loss();
				fuel.interactable = false;
			}

			if (controller.GameOver == true)
			{
				fuel.interactable = false;
			}
		}
	}
}
