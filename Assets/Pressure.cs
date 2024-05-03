using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEditor.Rendering.Universal;
using UnityEngine;
using UnityEngine.UIElements;

public class Pressure : MonoBehaviour
{
	public GameObject Needle;
	private float pressureIncrease = 0.2f;
	private bool Venting;
	[SerializeField] private float rotation;
	private ScoreSystem controller;

	// Start is called before the first frame update
	void Start()
    {
		StartCoroutine(PressureChange());
		controller = GetComponent<ScoreSystem>();

	}

	// Update is called once per frame
	void Update()
    {
		Needle.transform.eulerAngles = new Vector3(0, 0, rotation);


		if (rotation >= 0)
		{
			rotation = 0;
		}
		if (rotation <= -290)
		{
			controller.Loss();
		}
		
	}
	private void FixedUpdate()
	{
		if (!Venting && controller.GameOver == false)
		{
			rotation -= pressureIncrease;
		}
		else
		{
			rotation += 0.5f;
		}
	}
	public void Vent()
	{
		Venting = true;
		StartCoroutine(CoolingTime());
	}
	public IEnumerator CoolingTime()
	{
		yield return new WaitForSecondsRealtime(4);
		Venting = false;
	}
	public IEnumerator PressureChange()
	{
		yield return new WaitForSecondsRealtime(25);
		pressureIncrease += 0.1f;
		StartCoroutine(PressureChange());

	}
}
