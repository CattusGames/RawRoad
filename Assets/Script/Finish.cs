using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private GameProgressManager GPMngr;
    void Start()
    {
        GPMngr = GameObject.FindGameObjectWithTag("ProgressManager").GetComponent<GameProgressManager>();

    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            int currentLevel = SceneManager.GetActiveScene().buildIndex - 2;

            if (currentLevel >= PlayerPrefs.GetInt("levels"))
            {
                PlayerPrefs.SetInt("Levels", currentLevel + 1);
            }
            GPMngr.Finish();
            Debug.Log("YOU WIN!!!");
            Debug.Log(PlayerPrefs.GetInt("Levels"));

        }
    }
}
