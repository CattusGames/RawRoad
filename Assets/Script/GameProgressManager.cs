using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using TMPro;

public class GameProgressManager : MonoBehaviour
{
    [HideInInspector] public float progress;
    [HideInInspector] public float maxVelocitySpeed;
    [SerializeField] private TextMeshProUGUI timeModificator,progressTime,speedText;
    [SerializeField] private GameObject player;
    [SerializeField] private ParticleSystem destroyParticle;
    [SerializeField] private AudioClip destroySound;

    AudioSource audiosrc;
    Color timeColor = Color.red;
    Color speedColor = Color.white;
    Rigidbody rb;
    Vector3 direction;


    public Canvas mainCanvas;
    public Canvas finishCanvas;
    public Canvas loseCanvas;

    public UnityEvent<int, Vector3> SolidObstacleEvent;

    SkateControl control;

    private void Awake()
    {
        progress = 0.1f;
    }

   private void Start()
    {
        rb = player.GetComponent<Rigidbody>();

        audiosrc = player.GetComponent<AudioSource>();

        timeColor.a = 0;

        timeModificator.color = timeColor;

        control = player.GetComponent<SkateControl>();

        mainCanvas.gameObject.SetActive(true);

        finishCanvas.gameObject.SetActive(false);

        loseCanvas.gameObject.SetActive(false);

        SolidObstacleEvent.AddListener(OnObstacles);
    }


    private void FixedUpdate()
    {

        progress = progress + 0.02f;
        progressTime.text = progress.ToString("0.0");
        timeModificator.color = timeColor;
        var speed = rb.velocity.magnitude * 5;
        if (speed < 15)
        {
            speedText.color = Color.Lerp(Color.white, Color.red, 0.5f);
        }
        else
        {
            speedText.color = Color.white;
        }
        speedText.text = speed.ToString("0.0");

    }

    private void OnObstacles(int timeBonus, Vector3 position)
    {
        StartCoroutine(ChangeColor());
        timeModificator.text = "+ " + timeBonus;
        progress = progress + timeBonus;
        rb.AddRelativeForce(0, -6f, 0, ForceMode.Impulse);
        audiosrc.PlayOneShot(destroySound, PlayerPrefs.GetInt("OtherVolume"));
        Instantiate(destroyParticle, position, Quaternion.identity);
        
    }

   private IEnumerator ChangeColor()
    {

        timeColor.a = 1;

        float hideTime = 2f;
        float timer = hideTime;

        while (timer > 0)
        {
            timer -= Time.deltaTime;

            timeColor.a = (1f / hideTime) * timer;

            yield return null;
        }

    }

    public void Lose()
    {

            Time.timeScale = 0.5f;
            loseCanvas.gameObject.SetActive(true);

    }

    public void Finish()
    {

        Time.timeScale = 0f;
        mainCanvas.gameObject.SetActive(false);
        finishCanvas.gameObject.SetActive(true);
        finishCanvas.gameObject.GetComponent<FinishCanvas>().Finish(progress);

    }

    public void Skip()
    {
        Finish();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Terrain")
        {
            Lose();
        }
    }
}
