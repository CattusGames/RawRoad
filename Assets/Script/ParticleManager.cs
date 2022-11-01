using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ParticleManager : MonoBehaviour
{
	private float speedParticleColorAlpha;
	private ParticleSystem.ColorOverLifetimeModule speedParticleColorModule;
	private GradientAlphaKey[] gradientAlphaKey;
	private GradientColorKey[] gradientColorKey;
	private Gradient firstGradient;
	public ParticleSystem speedUp, push, slowdown, onWater,onDirt;
	private SkateControl control;
	private void Awake()
	{
		control = GetComponent<SkateControl>();
		firstGradient = new Gradient();
		speedParticleColorModule = speedUp.colorOverLifetime;
		speedParticleColorAlpha = 0f;
		gradientAlphaKey = new GradientAlphaKey[2];
		gradientColorKey = new GradientColorKey[2];
		gradientAlphaKey[0].alpha = 0f;
		gradientAlphaKey[0].time = 0f;
		gradientColorKey[0].color = Color.white;
		gradientAlphaKey[1].alpha = 0f;
		gradientAlphaKey[1].time = 1f;
		gradientColorKey[1].color = Color.black;
		firstGradient.SetKeys(gradientColorKey, gradientAlphaKey);
	}
	public void SpeedUp()
    {
		float speed;
		speed = control.rb.velocity.magnitude;
		if (speed >= 7)
		{
			speedParticleColorAlpha = (speed - 7) / 27;
			gradientAlphaKey[0].alpha = speedParticleColorAlpha;
			firstGradient.SetKeys(gradientColorKey, gradientAlphaKey);
			speedParticleColorModule.color = new ParticleSystem.MinMaxGradient(firstGradient);
		}
		else
		{
			gradientAlphaKey[0].alpha = 0f;
			firstGradient.SetKeys(gradientColorKey, gradientAlphaKey);
			speedParticleColorModule.color = new ParticleSystem.MinMaxGradient(firstGradient);
		}
	}
}
