using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameProgressManager : MonoBehaviour
{
    [HideInInspector]public float progress;
    [HideInInspector]public float maxVelocitySpeed;
    public Text timeModificator;
    public Text progressTime;
    public Text speedText;
    public GameObject player;
    public ParticleSystem destroyParticle;
    public AudioClip destroySound;

    AudioSource audiosrc;
    Color timeColor = Color.red;
    Color speedColor = Color.white;
    Rigidbody rb;
    Vector3 direction;

    private void Awake()
    {
        progress = 0.1f;
    }

    void Start()
    {
        rb = player.GetComponent<Rigidbody>();
        audiosrc = player.GetComponent<AudioSource>();
        timeColor.a = 0;
        timeModificator.color = timeColor;

    }


    void FixedUpdate()
    {
        progress = progress+0.01f;
        progressTime.text ="Time: " + progress.ToString("0.0");
        timeModificator.color = timeColor;
        var speed = rb.velocity.magnitude*5;
        if (speed<15)
        {
            speedText.color = Color.Lerp(Color.white,Color.red,0.5f);
        }
        else
        {
            speedText.color = Color.white;  
        }
        speedText.text = "Speed: " + speed.ToString("0.0")+" m/h";
        
    }

    public void OnObstacles(int timeBonus, Vector3 position)
    {
        StartCoroutine(ChangeColor());
        timeModificator.text = "+ " + timeBonus;
        progress = progress + timeBonus;
        rb.AddRelativeForce(0, -6f, 0, ForceMode.Impulse);
        audiosrc.PlayOneShot(destroySound, PlayerPrefs.GetFloat("OtherVolume"));
        Instantiate(destroyParticle, position, Quaternion.identity);
        
    }


    IEnumerator ChangeColor()
    {

        timeColor.a = 1;

        float hideTime = 2f; // время исчезновения в секундах
        float timer = hideTime;

        while (timer > 0)
        {
            timer -= Time.deltaTime;

            timeColor.a = (1f / hideTime) * timer;

            yield return null;
        }

    }

    /*private void OnTriggerEnter(Collider collider)
    {

        if (collider.gameObject.tag == "MainObstacles")
        {

            OnObstacles();
            rb.AddRelativeForce(0, -6f, 0, ForceMode.Impulse);
            audiosrc.PlayOneShot(destroySound, PlayerPrefs.GetFloat("OtherVolume"));
            Instantiate(destroyParticle, new Vector3(collider.transform.position.x, collider.transform.position.y, collider.transform.position.z), Quaternion.identity);
            Destroy(collider.gameObject);

        }
    }*/
}
