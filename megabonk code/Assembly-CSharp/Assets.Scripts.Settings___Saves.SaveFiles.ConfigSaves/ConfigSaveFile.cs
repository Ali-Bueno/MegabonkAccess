using System;
using Assets.Scripts.Saves___Serialization.SaveFiles.Configs;
using Assets.Scripts.Saves___Serialization.SaveFiles.Configs.ConfigSettingsTypes;
using Assets.Scripts.Settings___Saves.SaveFiles.ConfigSettingsTypes;

namespace Assets.Scripts.Settings___Saves.SaveFiles.ConfigSaves;

[Serializable]
public class ConfigSaveFile
{
	public int settingsVersion;

	public bool hasSelectedLanguage;

	public CFGameSettings cfGameSettings;

	public CFVideoSettings cfVideoSettings;

	public CFAudioSettings cfAudioSettings;

	public CFControlSettings cfControlSettings;

	public CFVisualsSettings cfVisualsSettings;

	public ConfigSettingsExtra otherSettings;

	public Preferences preferences;

	public void Init()
	{
	}
}
