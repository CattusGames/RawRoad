using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameProgressManager : MonoBehaviour
{
    [HideInInspector]public float progress;
    [HideInInspector]public float maxVelocitySpeed;
    public Text TimeModificator;

    Color color = Color.red;

    private void Awake()
    {
        progress = 0.1f;
    }

    void Start()
    {
        color.a = 0;
        TimeModificator.color = color;

    }


    void FixedUpdate()
    {
        PlayerPrefs.SetFloat("LevelTime",progress);
        progress = progress+0.01f;
        gameObject.GetComponent<Text>().text ="Time: " + progress.ToString("0.0");
        TimeModificator.color = color;
    }

    public void OnObstacles()
    {
        StartCoroutine(ChangeColor());
        int rnd = Random.Range(1,10);
        TimeModificator.text = "+ " + rnd;
        progress = progress + rnd;
    }

    IEnumerator ChangeColor()
    {
        color.a = Mathf.Abs(Mathf.Sin(Time.time));
        yield return new WaitForSeconds(2f);
        color.a = 0f;
    }
}
