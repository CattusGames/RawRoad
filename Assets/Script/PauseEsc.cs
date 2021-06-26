using UnityEngine;
using System.Collections;

public class PauseEsc : MonoBehaviour {

	private bool paused = false;
	public GameObject panel;
    private void Start()
    {
		Time.timeScale = 1;
		panel.SetActive(false);
	}
    public void SetPause()
    {
		if (!paused)
		{
			Time.timeScale = 0;
			paused = true;
			panel.SetActive(true);
		}
		else
		{
			Time.timeScale = 1;
			paused = false;
			panel.SetActive(false);
		}
	}
}
