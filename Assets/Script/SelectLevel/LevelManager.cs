using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {


    [SerializeField]
    Sprite unlockedIcon;

    [SerializeField]
    Sprite lockedIcon;

    // Use this for initialization
    void Start () {

    	int countUnlockedLevel = PlayerPrefs.GetInt("Levels", 1); //Первый параметр ключ под которым хранится сейв, второй значение по умолчанию если такого сейва нет

        for (int i = 0; i < transform.childCount; i++)
        {
            //переименовую кнопки и текст
            int numLvl = i + 1;
            transform.GetChild(i).gameObject.name = numLvl.ToString();
            transform.GetChild(i).transform.GetChild(0).GetComponent<Text>().text = numLvl.ToString();

            if (i < countUnlockedLevel)
            {
                //активная кнопка
                transform.GetChild(i).GetComponent<Image>().sprite = unlockedIcon;
                transform.GetChild(i).GetComponent<Button>().interactable = true;
                
            }
            else
            {
                //неактивная кнопка
                transform.GetChild(i).GetComponent<Image>().sprite = lockedIcon;
                transform.GetChild(i).GetComponent<Button>().interactable = false;

            }
        }	
	}
}
