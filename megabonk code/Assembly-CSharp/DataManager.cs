using System;
using System.Collections.Generic;
using Actors.Enemies;
using Assets.Scripts._Data.Hats;
using Assets.Scripts._Data.MapsAndStages;
using Assets.Scripts._Data.ShopItems;
using Assets.Scripts._Data.Tomes;
using Assets.Scripts.Audio.Music;
using Assets.Scripts.Inventory__Items__Pickups.Items;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using Assets.Scripts.UI.InGame.Rewards;
using UnityEngine;

public class DataManager : MonoBehaviour
{
	public List<ShopItemData> unsortedShopItems;

	public List<WeaponData> unsortedWeapons;

	public List<CharacterData> unsortedCharacterData;

	public List<TomeData> unsortedTomes;

	public List<MapData> maps;

	public List<EnemyData> unsortedEnemies;

	public List<EncounterData> unsortedEncounters;

	public List<MyAchievement> unsortedAchievements;

	public List<ItemData> unsortedItems;

	public List<UnlockableBase> unsortedUnlockables;

	public List<SkinData> unsortedSkins;

	public List<MusicTrack> unsortedMusic;

	public List<HatData> unsortedHats;

	private readonly Dictionary<EShopItem, ShopItemData> _003CshopItems_003Ek__BackingField;

	private Dictionary<EWeapon, WeaponData> weapons;

	private Dictionary<ECharacter, CharacterData> characterData;

	private Dictionary<ETome, TomeData> tomeData;

	private Dictionary<EEnemy, EnemyData> enemyData;

	private Dictionary<EEncounter, EncounterData> encounterData;

	private Dictionary<EItem, ItemData> itemData;

	private Dictionary<string, MyAchievement> achievementsData;

	private Dictionary<ECharacter, List<SkinData>> skinData;

	private Dictionary<EHat, HatData> hatData;

	public static Action A_DataLoaded;

	public static DataManager Instance;

	public Dictionary<EShopItem, ShopItemData> shopItems => _003CshopItems_003Ek__BackingField;

	public void Load()
	{
	}

	public ShopItemData GetShopItemData(EShopItem item)
	{
		return null;
	}

	public WeaponData GetWeapon(EWeapon weapon)
	{
		return null;
	}

	public CharacterData GetCharacterData(ECharacter character)
	{
		return null;
	}

	public TomeData GetTome(ETome eTome)
	{
		return null;
	}

	public MapData GetMap(EMap map)
	{
		return null;
	}

	public List<TomeData> GetAllTomes()
	{
		return null;
	}

	public List<WeaponData> GetAllWeapons()
	{
		return null;
	}

	public EnemyData GetEnemyData(EEnemy eEnemy)
	{
		return null;
	}

	public EncounterData GetEncounter(EEncounter encounter)
	{
		return null;
	}

	public MyAchievement GetAchievement(string internalName)
	{
		return null;
	}

	public ItemData GetItem(EItem item)
	{
		return null;
	}

	public List<UnlockableBase> GetAllPurchasable()
	{
		return null;
	}

	private string GetCharactersPath()
	{
		return null;
	}

	private string GetTomePath()
	{
		return null;
	}

	private string GetDataPath()
	{
		return null;
	}

	public List<SkinData> GetSkins(ECharacter character)
	{
		return null;
	}

	public SkinData GetSkin(ECharacter character, int savedIndex)
	{
		return null;
	}

	public HatData GetHat(EHat eHat)
	{
		return null;
	}
}
