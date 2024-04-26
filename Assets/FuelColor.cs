using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelColor : MonoBehaviour
{
	// Start is called before the first frame update
	private Image Fill;
	public Slider Rod;
	private Color LimeGreen;
    void Start()
    {
        Fill = GetComponent<Image>();
		LimeGreen = new Color(0, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
		Fill.color = Color.Lerp(Color.black,LimeGreen, Rod.value / 100);

	}
}
