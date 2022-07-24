using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinishCanvas : MonoBehaviour
{

    public Text timeText;
    public Text bestTimeText;
	
    private float bestTime,oneStarTime,twoStarTime,threeStarTime;

    public GameObject newBestTimeButton;

    private void Start()
    {
        newBestTimeButton.SetActive(false);
		bestTime = LevelsController.dataSet.Levels[SceneManager.GetActiveScene().buildIndex - 1].BestTime;

	}

    public void Finish(float time)
    {
		bestTime = LevelsController.dataSet.Levels[SceneManager.GetActiveScene().buildIndex - 1].BestTime;
		if (time < bestTime || bestTime == 0f)
        {
            
            newBestTimeButton.SetActive(true);
            bestTime = time;
            
			LevelsController.OnLevelFinished(SceneManager.GetActiveScene().buildIndex - 1, bestTime);
			LevelsController.Save();
        }

        timeText.text = "Time: " + time.ToString("0.0");
        bestTimeText.text = "Best Time: " + bestTime.ToString("0.0");
    }


    static public void SaveLevelProgres(string key, float time)
    {
        PlayerPrefs.SetFloat(SceneManager.GetActiveScene().buildIndex.ToString(),time);
    }
}
