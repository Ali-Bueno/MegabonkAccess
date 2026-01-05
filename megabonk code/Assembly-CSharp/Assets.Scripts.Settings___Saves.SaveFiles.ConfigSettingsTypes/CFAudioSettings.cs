using System.Collections.Generic;

namespace Assets.Scripts.Settings___Saves.SaveFiles.ConfigSettingsTypes;

public class CFAudioSettings : CFSettings
{
	public float master_volume;

	public float music;

	public float game_sfx;

	public float ambience;

	public float ui;

	public float xp_and_gold;

	public List<SettingHeader> GetHeaders()
	{
		return null;
	}
}
