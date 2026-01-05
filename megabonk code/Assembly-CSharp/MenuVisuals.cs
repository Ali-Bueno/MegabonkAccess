using Assets.Scripts._Data.MapsAndStages;
using Assets.Scripts.Game.Other;
using UnityEngine;

public class MenuVisuals : MonoBehaviour
{
	public Terrain terrain;

	public GrassChunkManager grassRenderer;

	public StageData defaultStageVisuals;

	public MapData defaultMapVisuals;

	public AudioClip dungeonAmbience;

	public GameObject general;

	public GameObject dungeon;

	private StageData currentStageData;

	public Transform camera;

	public GameObject particles;

	public GameObject forestBg;

	public GameObject desertBg;

	public Light sunLight;

	public AudioSource ambience;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnRunConfigChanged(RunConfig runConfig)
	{
	}

	private void Start()
	{
	}

	private void StartDelayed()
	{
	}

	public void Set(MapData mapData, StageData stageData, EMap map)
	{
	}
}
