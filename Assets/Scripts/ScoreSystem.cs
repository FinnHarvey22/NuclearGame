using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{

	[SerializeField] private float PowerGenerated;
	public Text ScoreText;
	public Text TimeText;
	private float time;
	public bool GameOver = false;
	private Animator Explosion;
	private Image NoSignal;
	// Start is called before the first frame update
	void Start()
    {
		Explosion = GameObject.FindGameObjectWithTag("Explosion").GetComponent<Animator>();
		NoSignal = GameObject.FindGameObjectWithTag("NoSignal").GetComponent<Image>();
		
    }

    // Update is called once per frame
    void Update()
	{
		if (GameOver == false)
		{
			time = Time.timeSinceLevelLoad;
			TimeText.text = "Time Played : " + time.ToString("#.##") + "s";
		}
		ScoreText.text = "Power Generated: " + PowerGenerated.ToString("#.#") + "kW";
	
	}

	private void FixedUpdate()
	{
		if (GameOver == false)
		{
			PowerGenerated += 0.1f;
		}
	}

	public void Loss()
	{
		GameOver = true;
		Explosion.enabled = true;
		StartCoroutine(ExplosionTime());
		saveValues();

	}
	IEnumerator ExplosionTime()
	{
		yield return new WaitForSecondsRealtime(5);
		NoSignal.enabled = true;
		StartCoroutine(QuitTime());
	}
	IEnumerator QuitTime()
	{
		yield return new WaitForSecondsRealtime(3);
		SceneManager.LoadScene(2);
	}

	public void saveValues()
	{
		PlayerPrefs.SetFloat("Time", time);
		PlayerPrefs.SetFloat("Power", PowerGenerated);
	}
	
}
