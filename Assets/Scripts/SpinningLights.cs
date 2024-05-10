using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpinningLights : MonoBehaviour
{

    [SerializeField] private GameObject Light;
    [SerializeField] private GameObject[] Beams;
    private Heat heat;
    private Pressure pressure;
    // Start is called before the first frame update
    void Start()
    {
        heat = GameObject.FindGameObjectWithTag("MainScreen").GetComponent<Heat>();
        pressure = GameObject.FindGameObjectWithTag("MainScreen").GetComponent<Pressure>();
    }

    // Update is called once per frame
    void Update()
    {
        if (heat.HeatSlider.value > 500 || pressure.rotation <= -145)
        {
           Light.transform.Rotate(0, 0, 3);
           LightsOn();
            
        }
        else
        {
            LightsOff();
        }
    }

    public void LightsOn()
    {
        Beams[1].SetActive(true);
        Beams[0].SetActive(true);
    }
    public void LightsOff()
    {
        Beams[0].SetActive(false);
        Beams[1].SetActive(false);

    }
}
