using UnityEngine;

public class DesertStorm : MonoBehaviour
{
	public MeshRenderer fogOfWarRenderer;

	private Material fogOfWarMaterial;

	public ParticleSystem[] stormParticles;

	public AudioSource audio;

	private float fadeOverTime;

	private float fadeTime;

	private bool isStorm;

	private float audioVolume;

	private float oldFogValue;

	private Color oldFogColor;

	private Color stormColor;

	private float stormFogIntensity;

	private void TryInit()
	{
	}

	public void FadeIn()
	{
	}

	public void FadeOut()
	{
	}

	private void Update()
	{
	}
}
