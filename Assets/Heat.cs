using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heat : MonoBehaviour
{
	// Start is called before the first frame update

	public Slider HeatSlider;
	public Sprite[] HeatSprites;
	[SerializeField] private int heat = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		HeatSlider.value = heat;

		heat += 1;


		if (heat > 0) { }
    }
}
