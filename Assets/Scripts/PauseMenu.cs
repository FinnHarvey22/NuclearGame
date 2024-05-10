using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
	private Canvas pauseMenu;
	[SerializeField] private Sprite[] OnOff;
	private Image Switch;
	private bool PauseToggle = false;
	private float Timer = 3.0f;
	private Text TimerText;
	// Start is called before the first frame update
    void Start()
    {
		pauseMenu = GameObject.FindGameObjectWithTag("PauseMenu").GetComponent<Canvas>();
		Switch = GameObject.FindGameObjectWithTag("Switch").GetComponent<Image>();
		TimerText = GameObject.FindGameObjectWithTag("TimerText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
		if (PauseToggle == true)
		{
			Switch.sprite = OnOff[1];
			pauseMenu.enabled = true;
			Time.timeScale = 0.0f;
		}
		else if (PauseToggle == false)
		{
			if (Timer <= 0.0f)
			{
				
				Time.timeScale = 1.0f;
				TimerText.enabled = false;
			}
		}
		TimerText.text = Timer.ToString("#");

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (PauseToggle == false)
			{
				PauseToggle = !PauseToggle;
			}
			else if (PauseToggle == true)
			{
				StartCoroutine(ContinueTime());
				Timer = 3.0f;
				PauseToggle = !PauseToggle;
				TimerText.enabled = true;
				Switch.sprite = OnOff[0];
				pauseMenu.enabled = false;
			}
		}
    }

	public void PauseGame()
	{
		if (PauseToggle == false) 
		{
			PauseToggle = !PauseToggle;
		}
		else if (PauseToggle == true)
		{
			StartCoroutine(ContinueTime());
			Timer = 3.0f;
			PauseToggle = !PauseToggle;
			TimerText.enabled = true;
			Switch.sprite = OnOff[0];
			pauseMenu.enabled = false;
		}


	}

	public void Quit()
	{
		Application.Quit();
	}

	public void MainMenu()
	{
		SceneManager.LoadScene(0);
	}

	IEnumerator ContinueTime()
	{
		yield return new WaitForSecondsRealtime(1);
		if (Timer > 0.0f)
		{
			Timer--;
			StartCoroutine(ContinueTime());
		}
	}

}
