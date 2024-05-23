using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DontDestroy : MonoBehaviour
{
	public Text Powertext;
	public Text timetext;
	public float Power;
	public float Time;
    // Start is called before the first frame update
    void Start()
    {
		Power = PlayerPrefs.GetFloat("Power");
		Time = PlayerPrefs.GetFloat("Time");
		timetext.text = "Time Played : " + Time.ToString("#.##") + "s";
		Powertext.text = "Power Generated: " + Power.ToString("#.#") + "kW";
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
