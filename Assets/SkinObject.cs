using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
public class SkinObject : MonoBehaviour
{
    public Skin[] info;
    public TextMeshProUGUI priceText;
    public TextMeshProUGUI coinsText;
    public int index;
    public int coins;

    private bool[] StockCheck;
    [SerializeField] private GameObject body, head, lArm, rArm, lLeg, rLeg;
    [SerializeField] private bool _isHuman;
    [SerializeField] private Button _buyBttn;
    [SerializeField] private Material _mainMaterial;
    [SerializeField] private bool _interactable = false;
    [SerializeField] private string _preName; 
    public UnityEvent SelectEvent;

    private void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {

            PlayerPrefs.SetInt("Coin", 50);

            coins = PlayerPrefs.GetInt("Coin");

            coinsText.text = coins.ToString();
            if (!_interactable)
            {
                _mainMaterial.color = Color.gray;
            }
            priceText.text = "CHOSEN";
            _buyBttn.interactable = false;
        }
        else
        {
            _mainMaterial.color = Color.white;
        }

        index = PlayerPrefs.GetInt(_preName + "chosenSkin");

        StockCheck = new bool[53];
        if (PlayerPrefs.HasKey(_preName + "StockArray"))
            StockCheck = PlayerPrefsX.GetBoolArray(_preName + "StockArray");
        else
            StockCheck[0] = true;

        info[index].isChosen = true;

        for (int i = 0; i < info.Length; i++)
        {
            info[i].inStock = StockCheck[i];
            if (i == index)
            {
                if (_isHuman)
                {
                    head.GetComponent<MeshFilter>().sharedMesh = info[i].head.GetComponent<MeshFilter>().sharedMesh;
                    body.GetComponent<MeshFilter>().sharedMesh = info[i].body.GetComponent<MeshFilter>().sharedMesh;
                    lArm.GetComponent<MeshFilter>().sharedMesh = info[i].lArm.GetComponent<MeshFilter>().sharedMesh;
                    rArm.GetComponent<MeshFilter>().sharedMesh = info[i].rArm.GetComponent<MeshFilter>().sharedMesh;
                    lLeg.GetComponent<MeshFilter>().sharedMesh = info[i].lLeg.GetComponent<MeshFilter>().sharedMesh;
                    rLeg.GetComponent<MeshFilter>().sharedMesh = info[i].rLeg.GetComponent<MeshFilter>().sharedMesh;
                }
                else
                {
                    body.GetComponent<MeshFilter>().sharedMesh = info[i].body.GetComponent<MeshFilter>().sharedMesh;
                }
            }
        }


    }

    private void OnMouseUp()
    {
        SelectEvent.Invoke();
    }
    public void Interactable()
    {
        _mainMaterial.color = Color.white;
        _interactable = true;
    }
    public void UnInteractable()
    {
        _mainMaterial.color = Color.gray;
        _interactable = false;
    }
    public void Save()
    {
        PlayerPrefsX.SetBoolArray(_preName + "StockArray", StockCheck);
    }

    public void ScrollRight()
    {
        if(_interactable)
        {
            if (index < info.Length)
            {
                index++;

                if (info[index].inStock && info[index].isChosen)
                {
                    priceText.text = "CHOSEN";
                    _buyBttn.interactable = false;
                }
                else if (!info[index].inStock)
                {
                    priceText.text = info[index].cost.ToString();
                    _buyBttn.interactable = true;
                }
                else if (info[index].inStock && !info[index].isChosen)
                {
                    priceText.text = "CHOOSE";
                    _buyBttn.interactable = true;
                }

                if (_isHuman)
                {
                    head.GetComponent<MeshFilter>().sharedMesh = info[index].head.GetComponent<MeshFilter>().sharedMesh;
                    body.GetComponent<MeshFilter>().sharedMesh = info[index].body.GetComponent<MeshFilter>().sharedMesh;
                    lArm.GetComponent<MeshFilter>().sharedMesh = info[index].lArm.GetComponent<MeshFilter>().sharedMesh;
                    rArm.GetComponent<MeshFilter>().sharedMesh = info[index].rArm.GetComponent<MeshFilter>().sharedMesh;
                    lLeg.GetComponent<MeshFilter>().sharedMesh = info[index].lLeg.GetComponent<MeshFilter>().sharedMesh;
                    rLeg.GetComponent<MeshFilter>().sharedMesh = info[index].rLeg.GetComponent<MeshFilter>().sharedMesh;
                }
                else
                {
                    body.GetComponent<MeshFilter>().sharedMesh = info[index].body.GetComponent<MeshFilter>().sharedMesh;
                }
                // Можно записать так: player.GetChild(index-1).gameObject.SetActive(false);

                //player.GetChild(index).gameObject.SetActive(true);
            }
        }
        
    }

    public void ScrollLeft()
    {
        if (_interactable)
        {
            if (index > 0)
            {
                index--;

                if (info[index].inStock && info[index].isChosen)
                {
                    priceText.text = "CHOSEN";
                    _buyBttn.interactable = false;
                }
                else if (!info[index].inStock)
                {
                    priceText.text = info[index].cost.ToString();
                    _buyBttn.interactable = true;
                }
                else if (info[index].inStock && !info[index].isChosen)
                {
                    priceText.text = "CHOOSE";
                    _buyBttn.interactable = true;
                }

                if (_isHuman)
                {
                    head.GetComponent<MeshFilter>().sharedMesh = info[index].head.GetComponent<MeshFilter>().sharedMesh;
                    body.GetComponent<MeshFilter>().sharedMesh = info[index].body.GetComponent<MeshFilter>().sharedMesh;
                    lArm.GetComponent<MeshFilter>().sharedMesh = info[index].lArm.GetComponent<MeshFilter>().sharedMesh;
                    rArm.GetComponent<MeshFilter>().sharedMesh = info[index].rArm.GetComponent<MeshFilter>().sharedMesh;
                    lLeg.GetComponent<MeshFilter>().sharedMesh = info[index].lLeg.GetComponent<MeshFilter>().sharedMesh;
                    rLeg.GetComponent<MeshFilter>().sharedMesh = info[index].rLeg.GetComponent<MeshFilter>().sharedMesh;
                }
                else
                {
                    body.GetComponent<MeshFilter>().sharedMesh = info[index].body.GetComponent<MeshFilter>().sharedMesh;
                }
                //player.GetChild(index).gameObject.SetActive(true);
            }
        }
    }
    public void SetChoosenSkin()
    {
        index = PlayerPrefs.GetInt(_preName + "chosenSkin");
        if (_interactable)
        {
            if (_isHuman)
            {
                head.GetComponent<MeshFilter>().sharedMesh = info[index].head.GetComponent<MeshFilter>().sharedMesh;
                body.GetComponent<MeshFilter>().sharedMesh = info[index].body.GetComponent<MeshFilter>().sharedMesh;
                lArm.GetComponent<MeshFilter>().sharedMesh = info[index].lArm.GetComponent<MeshFilter>().sharedMesh;
                rArm.GetComponent<MeshFilter>().sharedMesh = info[index].rArm.GetComponent<MeshFilter>().sharedMesh;
                lLeg.GetComponent<MeshFilter>().sharedMesh = info[index].lLeg.GetComponent<MeshFilter>().sharedMesh;
                rLeg.GetComponent<MeshFilter>().sharedMesh = info[index].rLeg.GetComponent<MeshFilter>().sharedMesh;
            }
            else
            {
                body.GetComponent<MeshFilter>().sharedMesh = info[index].body.GetComponent<MeshFilter>().sharedMesh;
            }
        }
        
    }
    public void BuyButtonAction()
    {

        if (_interactable)
        {
            if (_buyBttn.interactable && !info[index].inStock)
            {
                if (coins >= int.Parse(priceText.text))
                {
                    coins -= int.Parse(priceText.text);
                    coinsText.text = coins.ToString();
                    PlayerPrefs.SetInt("Coin", coins);
                    StockCheck[index] = true;
                    info[index].inStock = true;
                    priceText.text = "CHOOSE";
                    Save();
                }
            }

            if (_buyBttn.interactable && !info[index].isChosen && info[index].inStock)
            {
                PlayerPrefs.SetInt(_preName + "chosenSkin", index);
                _buyBttn.interactable = false;
                priceText.text = "CHOSEN";
            }
        }
       
    }
}
[System.Serializable]
public class Skin
{
    public int cost;
    public GameObject body, head, lArm, rArm, lLeg, rLeg;
    public bool inStock;
    public bool isChosen;
}