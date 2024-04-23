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
	[SerializeField] private float pressure;
	private float pressureIncrease = 0.01f;
	private bool Venting;
	[SerializeField] private float rotation;
    // Start is called before the first frame update
    void Start()
    {
		StartCoroutine(PressureChange());

	}

    // Update is called once per frame
    void Update()
    {
		Needle.transform.eulerAngles = new Vector3(0, 0, rotation);
		if (!Venting)
		{
			rotation -= pressureIncrease;
		}
		else
		{
			rotation += pressureIncrease;
		}

		if (rotation >= 0)
		{
			rotation = 0;
		}
		
	}
	public void Vent()
	{
		Venting = true;
		StartCoroutine(CoolingTime());
	}
	public IEnumerator CoolingTime()
	{
		yield return new WaitForSeconds(3);
		Venting = false;
	}
	public IEnumerator PressureChange()
	{
		yield return new WaitForSeconds(25);
		pressureIncrease += 0.01f;
		StartCoroutine(PressureChange());

	}
}
