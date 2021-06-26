using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
	public Sprite unlockedIcon;

    public Sprite lockedIcon;

    // Use this for initialization
    void Start () {
		
		LevelsController.Load(transform.childCount);

		int countUnlockedLevel = LevelsController.dataSet.countUnlockedLevel; 

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
