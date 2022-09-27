using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ParticleSystemJobs;

public class SkateAnim : MonoBehaviour
{

	[SerializeField]private float AnimationLerpSpeed;
	private SkateControl control;
	private InputProcessing inputs;
	private Animator anim;
	[SerializeField]private ParticleSystem pushParticle,pushParticle3D, slowdownParticle;

	[HideInInspector] public Quaternion FromInputs;
	private float Tilt;
	private bool LastAerial = false;
	private bool Move = false;

	private AudioSource playerAudioSrc;
	[SerializeField] private AudioClip playerRide, playerMove, playerAerial, playerSlowdown;

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

	private void ManageAir()
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

	private void ManageMove()
    {

		if (control.rb.velocity.magnitude<3 && inputs.slowdown == false)
        {
			playerAudioSrc.PlayOneShot(playerMove,otherSound);
			Vector3 Direction = transform.forward * 20f;
			control.rb.AddForce(Direction, ForceMode.Impulse);
			pushParticle.Play();
			pushParticle3D.Play();
			anim.SetTrigger("Move");
		}
		else if (inputs.slowdown)
        {
			anim.SetBool("Slowdown",true);
			ManageSlowdown();
			slowdownParticle.Play();
		}
		else if (inputs.slowdown == false)
        {
			ManageSlowdown();
			anim.SetBool("Slowdown", false);
		}

	}

	private void ManageTilt()
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

	private void AdjustTilt()
	{
		float tilt = anim.GetFloat("Tilt");
		tilt = Mathf.Lerp(tilt, Tilt, AnimationLerpSpeed * Time.deltaTime);
		anim.SetFloat("Tilt", tilt);
	}

	private void ManageSlowdown()
    {
		playerAudioSrc.PlayOneShot(playerSlowdown, otherSound / 10);
		float slowdown = anim.GetFloat("SlowdownFloat");
		if (inputs.slowdown == true)
        {
			slowdown = Mathf.Lerp(slowdown, 1, AnimationLerpSpeed * Time.deltaTime);
        }
        else
        {
			
            if (slowdown<0.01)
            {
				slowdown = 0f;
			}
            else
            {
				slowdown = Mathf.Lerp(slowdown, 0, AnimationLerpSpeed * Time.deltaTime);
			}
		}
		anim.SetFloat("SlowdownFloat", slowdown);
	}

	private void Initialization()
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