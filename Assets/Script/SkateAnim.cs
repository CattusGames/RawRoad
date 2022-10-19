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
	[HideInInspector] public Quaternion FromInputs;
	private float Tilt;
	private bool LastAerial = false;
	private bool isPlaying = false;
	private PlayerEventManager playerEvents;


	public bool start = false;
	public bool end = false;
   
    void Start()
	{

		Initialization();
		
	}

	void Update()
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
				playerEvents.OnAir.Invoke();
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

		if (control.rb.velocity.magnitude > 3)
		{
			playerEvents.OnRide.Invoke();
		}

		if (control.rb.velocity.magnitude < 3 && inputs.slowdown == false)
		{
			playerEvents.OnPush.Invoke();
			Vector3 Direction = transform.forward * 20f;
			control.rb.AddForce(Direction, ForceMode.Impulse);
			anim.SetTrigger("Move");
		}
		else if (inputs.slowdown)
        {
			anim.SetBool("Slowdown",true);
			ManageSlowdown();
			playerEvents.OnSlowdown.Invoke();
		}
		else if (inputs.slowdown == false)
        {
			anim.SetBool("Slowdown", false);
			ManageSlowdown();
		}


		playerEvents.OnSpeedUp.Invoke();
		
	}

	private void ManageTilt()
	{
			
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
		playerEvents = GetComponent<PlayerEventManager>();
		control = GetComponent<SkateControl>();
		inputs = GetComponent<InputProcessing>();
		anim = GetComponent<Animator>();
		Tilt = 0.5f;
		anim.SetFloat("Tilt", Tilt);
		PlayerPrefs.SetInt("OtherVolume", 1);

	}


}