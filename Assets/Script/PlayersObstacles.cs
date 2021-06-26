using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersObstacles : MonoBehaviour
{

    Rigidbody rb;
    Vector3 direction;
    public ParticleSystem DestroyParticle;

    public AudioClip destroySound;
    AudioSource audiosrc;

    public GameProgressManager GPMngr;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audiosrc = GetComponent<AudioSource>();


    }

    private void OnTriggerEnter(Collider collider)
    {

        if (collider.gameObject.tag == "MainObstacles")
        {

            GPMngr.OnObstacles();
            rb.AddRelativeForce(0, -6f, 0, ForceMode.Impulse);
            audiosrc.PlayOneShot(destroySound, PlayerPrefs.GetFloat("OtherVolume"));
            Instantiate(DestroyParticle, new Vector3(collider.transform.position.x, collider.transform.position.y, collider.transform.position.z), Quaternion.identity);
            Destroy(collider.gameObject);

        }
    }
}
