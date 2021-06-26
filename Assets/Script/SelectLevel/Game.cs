using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public Canvas mainCanvas;
    public Canvas finishCanvas;
    public Canvas loseCanvas;

    SkateControl control;

    private void Start()
    {
        control = GetComponent<SkateControl>();

        mainCanvas.gameObject.SetActive(true);

        finishCanvas.gameObject.SetActive(false);

        loseCanvas.gameObject.SetActive(false);


    }

    private void FixedUpdate()
    {
        Lose();
    }


    public void Lose()
    {
        bool current_aerial = control.aerial;
        if (current_aerial == true)
        {
            Time.timeScale = 0.5f;
            loseCanvas.gameObject.SetActive(true);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Finish")
        {
            int currentLevel = SceneManager.GetActiveScene().buildIndex - 2;

            if (currentLevel >= PlayerPrefs.GetInt("levels"))
            {
                PlayerPrefs.SetInt("Levels", currentLevel + 1);
            }
            Finish();
            Debug.Log("YOU WIN!!!");
            Debug.Log(PlayerPrefs.GetInt("Levels"));
            
        }
    }

    void Finish()
    {

        Time.timeScale = 0f;
        mainCanvas.gameObject.SetActive(false);
        finishCanvas.gameObject.SetActive(true);

    }
}
