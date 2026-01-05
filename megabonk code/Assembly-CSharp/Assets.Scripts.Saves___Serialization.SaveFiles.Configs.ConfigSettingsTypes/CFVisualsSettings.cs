using System.Collections.Generic;
using Assets.Scripts.Settings___Saves.SaveFiles;

namespace Assets.Scripts.Saves___Serialization.SaveFiles.Configs.ConfigSettingsTypes;

public class CFVisualsSettings : CFSettings
{
	public int damage_numbers;

	public int damage_flash;

	public int low_hp_effects;

	public float particle_opacity;

	public int particle_auto_opacity;

	public List<SettingHeader> GetHeaders()
	{
		return null;
	}
}
