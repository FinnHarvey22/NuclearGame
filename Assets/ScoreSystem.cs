using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{

	[SerializeField] private float PowerGenerated;
	public Text ScoreText;
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

		PowerGenerated += 0.1f;
		ScoreText.text = "Power Generated: " + PowerGenerated.ToString("#.#") + "kW";
	}

	private void FixedUpdate()
	{
		


	}
}
