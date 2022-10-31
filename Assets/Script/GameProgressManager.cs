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

    private AudioSource audiosrc;
    private Color timeColor = Color.red;
    private Color speedColor = Color.white;
    private Rigidbody rb;
    private Vector3 direction;
    private bool paused = false;

    [SerializeField] private GameObject _mainUI, _loseUI, _finishUI, _pauseUI;

    public UnityEvent<int, Vector3> SolidObstacleEvent;

    private void Awake()
    {
        progress = 0.1f;
    }

   private void Start()
    {
        Time.timeScale = 1;

        rb = player.GetComponent<Rigidbody>();

        audiosrc = player.GetComponent<AudioSource>();

        timeColor.a = 0;

        timeModificator.color = timeColor;

        _mainUI.gameObject.SetActive(true);

        _finishUI.gameObject.SetActive(false);

        _loseUI.gameObject.SetActive(false);

        SolidObstacleEvent.AddListener(OnObstacles);
    }



    public void SetPause()
    {
        if (!paused)
        {
            Time.timeScale = 0;
            paused = true;
            _pauseUI.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            paused = false;
            _pauseUI.SetActive(false);
        }
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

            Time.timeScale = 0f;
            _loseUI.gameObject.SetActive(true);

    }

    public void Finish()
    {

        Time.timeScale = 0f;
        _mainUI.gameObject.SetActive(false);
        _finishUI.gameObject.SetActive(true);
        _finishUI.gameObject.GetComponent<FinishCanvas>().Finish(progress);

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
