using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinishCanvas : MonoBehaviour
{


    public Text timeText;
    public Text bestTimeText;

    float time;
    float bestTime;

    public GameObject newBestTimeButton;

    private void Start()
    {
        newBestTimeButton.SetActive(false);
        bestTime = LoadLevelProgres(SceneManager.GetActiveScene().buildIndex.ToString());
        Debug.Log(bestTime);
    }

    void Update()
    {

        

        time = PlayerPrefs.GetFloat("LevelTime");

        timeText.text = "Time: " + time.ToString("0.0");
        bestTimeText.text = "Best Time: " + bestTime.ToString("0.0");


        if (Time.timeScale == 0)
        {
            

            if (time < bestTime || bestTime == 0)
            {
                //новий рекорд
                newBestTimeButton.SetActive(true);
                bestTime = time;
                Debug.Log(bestTime);
                SaveLevelProgres(SceneManager.GetActiveScene().buildIndex.ToString(),bestTime);


            }
            else if (time>bestTime)
            {
                
            }

        }
    }


    static public void SaveLevelProgres(string key, float time)
    {
        PlayerPrefs.SetFloat(SceneManager.GetActiveScene().buildIndex.ToString(),time);
    }

    static public float LoadLevelProgres(string key)
    {
        if (PlayerPrefs.HasKey(key))
        {
            return PlayerPrefs.GetFloat(key);
        }
        return 0;
    }
}
