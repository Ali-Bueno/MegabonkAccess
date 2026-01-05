using System;
using System.Collections.Generic;

namespace Assets.Scripts.Settings___Saves.SaveFiles;

[Serializable]
public class CFGameSettings : CFSettings
{
	public int camera_shake;

	public float input_delay;

	public int enemy_targeting_mode;

	public float random_enemy_targeting;

	public int language;

	public int show_tips;

	public float minimap_size;

	public int minimap_rotation;

	public int hp_bar_color;

	public float crosshair_height;

	public float crosshair_size;

	public float crosshair_alpha;

	public int hide_leaderboards;

	public int upload_score_to_leaderboard;

	public int quick_reset;

	public int debug_shrines;

	public int debug_fps;

	public int debug_speed;

	public int debug_ram;

	public int debug_enemy_scaling;

	public int pege_mode;

	public int unlock_all;

	public int auto_select_upgrades;

	public float auto_select_after_level;

	public int show_advanced_settings;

	public int show_hud;

	public int skip_chest_animation;

	public int show_item_feed;

	public int skip_portal_animation;

	public int enable_silver_pots;

	public float quick_reset_time;

	public int super_quick_resets;

	public List<SettingHeader> GetHeaders()
	{
		return null;
	}
}
