using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _locationsMark;
    [SerializeField] private List<Location> _locations;
    [SerializeField] private Image _levelCanvasImage;
    [SerializeField] private Button _levelCanvasButton;
    [SerializeField] private TextMeshProUGUI _locationNameText;

    private int index = 0;
    private Location currentLocation;

    // Use this for initialization
    private void Awake()
    {

    }
    void Start()
    {
        LevelsController.Load(_locations);


        int countUnlockedLevel = LevelsController.dataSet.countUnlockedLevel;
        int countUnlockedLocation = LevelsController.dataSet.countUnlockedLocation;

        for (int i = 0; i < _locationsMark.Count; i++)
        {
            if (i < countUnlockedLocation)
            {
                if (_locations[i].IsFinished==true || _locations[i].levels[0].IsFinished==false)
                {
                    for (int j = 0; j < _locations[i].levels.Count; j++)
                    {
                        if (_locations[i].levels[j].IsFinished == false)
                        {
                            _locationsMark[i].transform.GetChild(0).gameObject.SetActive(true);
                        }
                    }
                }
                _locationsMark[i].SetActive(true);
            }
            else
            {
                _locationsMark[i].SetActive(false);
            }


        }

    }
    public void OnLocationClick(Location location)
    {
        currentLocation = location;
        index = 0;
        _levelCanvasImage.sprite = location.levels[0].levelImage.sprite;
        _locationNameText.text = location.locationName + " : " + location.levels[0].levelName;

    }
    public void RightClick()
    {
        if (index < currentLocation.levels.Count)
        {
            index++;
        }
        else if (index > currentLocation.levels.Count)
        {
            index--;
        }
        _levelCanvasImage.sprite = currentLocation.levels[index].levelImage.sprite;
        _locationNameText.text = currentLocation.locationName + " : " + currentLocation.levels[index].levelName;

    }
    public void LeftClick()
    {
        if (index!=0)
        {
            index--;

        }
        else if (index<0)
        {
            index++;
        }
        _levelCanvasImage.sprite = currentLocation.levels[index].levelImage.sprite;
        _locationNameText.text = currentLocation.locationName + " : " + currentLocation.levels[index].levelName;
    }
    public void OnLevelClick()
    {
        SceneManager.LoadScene(currentLocation.levels[index].sceneID);

    }
}
