using UnityEngine;
using UnityEngine.UI;

namespace RetroArsenal;

public class RetroFireBeam : MonoBehaviour
{
	public GameObject[] beamLineRendererPrefab;

	public GameObject[] beamStartPrefab;

	public GameObject[] beamEndPrefab;

	private BeamType currentBeam;

	private GameObject beamStart;

	private GameObject beamEnd;

	private GameObject beam;

	private LineRenderer line;

	private Transform beamTransform;

	private float textureScrollOffset;

	public float beamEndOffset;

	public float textureScrollSpeed;

	public float textureLengthScale;

	public Slider endOffsetSlider;

	public Slider scrollSpeedSlider;

	public Text textBeamName;

	private bool isFiringBeam;

	private void Start()
	{
	}

	private void CreateBeamObjects()
	{
	}

	private void Update()
	{
	}

	private void UpdateBeam()
	{
	}

	private void ShootBeamInDir(Vector3 start, Vector3 dir)
	{
	}
}
