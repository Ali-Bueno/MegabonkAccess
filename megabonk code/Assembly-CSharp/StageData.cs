using Assets.Scripts.Game.MapGeneration;
using Assets.Scripts.Game.Spawning.New.Timelines;
using Assets.Scripts.MapGeneration.ProceduralTiles;
using UnityEngine;
using UnityEngine.Localization;

public class StageData : ScriptableObject
{
	public LocalizedString localizedName;

	public LocalizedString localizedDescription;

	public MapEdgeFillType mapEdgeFillType;

	public Material waterMaterial;

	public GameObject waterSplashFx;

	public Material grassMaterial;

	public int grassPerChunk;

	public Material[] flatMaterials;

	public Material m_fillMiddle;

	public Material m_fillTop;

	public Material m_fillMiddleEdge;

	public Material m_fillTopEdge;

	public Material m_stairs;

	public Material triplanarMaterial;

	public GameObject particles;

	public Material skybox;

	public float fogIntensity;

	public Color fogColor;

	public Color ambienceColor;

	public Color lightColor;

	public float lightIntensity;

	public StageTimeline stageTimeline;

	public bool isWaterDamage;

	public MapParameters mapParameters;

	public RandomMapObject[] randomMapObjects;

	public StageTilePrefabs stageTilePrefabs;

	public TerrainData proceduralTerrainData;

	public NoiseData proceduralNoiseData;

	public float proceduralMapScale;

	public float farClipPlane;

	public ChallengeData[] challenges;

	public string GetName()
	{
		return null;
	}

	public string GetDescription()
	{
		return null;
	}

	public Material GetSideMaterial(EFillType eFillType, bool useEdgeTextures = false)
	{
		return null;
	}

	public Material GetTopMaterial()
	{
		return null;
	}

	public void ApplyFogAndSky(Light sunLight)
	{
	}

	public GameObject SpawnParticles()
	{
		return null;
	}
}
