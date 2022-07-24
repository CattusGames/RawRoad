using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkateAnim : MonoBehaviour
{

	public float AnimationLerpSpeed;
	SkateControl control;
	InputProcessing inputs;
	Animator anim;
	public GameObject PushParticle;
	public Transform PushParticleSpawn;

	[HideInInspector] public Quaternion FromInputs;
	float Tilt;
	bool LastAerial = false;
	bool Move = false;

	private AudioSource playerAudioSrc;
	public AudioClip playerRide;
	public AudioClip playerMove;
	public AudioClip playerAerial;
	public bool start = false;
	public bool end = false;

	float otherSound;

	void Start()
	{
		Initialization();
	}

	void FixedUpdate()
    {
        if (start == true && end == false)
        {
			ManageMove();
			ManageTilt();
			ManageAir();
        }
        else if(end == true)
        {
			anim.SetBool("Start",false);
			anim.SetBool("End",true);
		}

	}

	void ManageAir()
	{
		bool current_aerial = control.aerial;
		if (current_aerial)
		{
			if (!LastAerial)
			{
				LastAerial = true;
				playerAudioSrc.Stop();
				playerAudioSrc.PlayOneShot(playerAerial, otherSound);
				anim.SetTrigger("Aerial");
			}
		}
		else
		{
			if (LastAerial)
			{
				LastAerial = false;
				anim.SetTrigger("Land");
			}
		}
	}

	void ManageMove()
    {

		if (control.rb.velocity.magnitude<3 && inputs.slowdown == false)
        {
			playerAudioSrc.PlayOneShot(playerMove,otherSound);
			Vector3 Direction = transform.forward * 20f;
			control.rb.AddForce(Direction, ForceMode.Impulse);
			Instantiate(PushParticle, new Vector3(PushParticleSpawn.position.x, PushParticleSpawn.position.y, PushParticleSpawn.position.z), Quaternion.identity);
			anim.SetTrigger("Move");
		}
		else if (inputs.slowdown)
        {
			anim.SetTrigger("Slowdown");
			Instantiate(PushParticle, new Vector3(PushParticleSpawn.position.x, PushParticleSpawn.position.y, PushParticleSpawn.position.z), Quaternion.identity);
		}

	}

	void ManageTilt()
	{
			playerAudioSrc.PlayOneShot(playerRide, otherSound / 10);
			Vector3 expected_direction = control.VelocityRotation * transform.forward;
			float angle = Vector3.SignedAngle(transform.forward, expected_direction, transform.up);
			// FromInputs = control.VelocityRotation; 
			// // float angle = FromInputs.eulerAngles.y - 360; 
			//Debug.Log(angle);
			// angle = Mathf.Clamp(Vector3.SignedAngle(forward, adapted_direction, Vector3.up), -90,90); 
			angle = Mathf.Clamp(angle * 3f, -5f, 5f);
			Tilt = (angle + 5f) / 10f;


			AdjustTilt();
	}

	void AdjustTilt()
	{
		float tilt = anim.GetFloat("Tilt");
		tilt = Mathf.Lerp(tilt, Tilt, AnimationLerpSpeed * Time.deltaTime);
		anim.SetFloat("Tilt", tilt);
	}

	void Initialization()
	{
		control = GetComponent<SkateControl>();
		inputs = GetComponent<InputProcessing>();
		anim = GetComponent<Animator>();
		playerAudioSrc = gameObject.GetComponent<AudioSource>();
		Tilt = 0.5f;
		anim.SetFloat("Tilt", Tilt);
		otherSound = PlayerPrefs.GetInt("OtherVolume");
	}


}