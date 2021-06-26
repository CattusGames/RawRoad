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
    public GameObject player;
    public ParticleSystem destroyParticle;
    public AudioClip destroySound;

    AudioSource audiosrc;
    Color color = Color.red;
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
        color.a = 0;
        timeModificator.color = color;

    }


    void FixedUpdate()
    {
        PlayerPrefs.SetFloat("LevelTime",progress);
        progress = progress+0.01f;
        progressTime.text ="Time: " + progress.ToString("0.0");
        timeModificator.color = color;
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
        color.a = Mathf.Abs(Mathf.Sin(Time.time));
        yield return new WaitForSeconds(2f);
        color.a = 0f;
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
