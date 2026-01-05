using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class DeathPP : MonoBehaviour
{
	public PostProcessVolume volume;

	private ColorGrading cg;

	private Vignette vignette;

	private bool isEnabled;

	private float deadVignetteIntensity;

	private float deadVignetteSmoothness;

	private float deadContrast;

	private float deadSaturation;

	private bool dead;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnPlayerDied()
	{
	}

	private void Update()
	{
	}
}
