using System.Collections.Generic;

namespace Assets.Scripts.Settings___Saves.SaveFiles;

public class CFControlSettings : CFSettings
{
	public float sensitivity;

	public float look_smoothing;

	public float controller_sensitivity;

	public int inverted_horizontal_axis;

	public int inverted_vertical_axis;

	public int hold_crouch;

	public int hold_aim;

	public int rotate_camera_with_arrow_keys;

	public int select_upgrades_with_number_keys;

	public string keyboard_move_forward;

	public string keyboard_move_backward;

	public string keyboard_move_left;

	public string keyboard_move_right;

	public string keyboard_jump;

	public string keyboard_interact;

	public string keyboard_slide;

	public string keyboard_aim;

	public string keyboard_quick_reset;

	public string map_overlay;

	public int controller;

	public float controller_vibration;

	public string controller_jump;

	public string controller_interact;

	public string controller_slide;

	public string controller_aim;

	public string controller_quick_reset;

	public string controller_map_overlay;

	public int pause_on_controller_disconnect;

	public int space_navigation;

	public int horizontal_navigation;

	public string keyboard_jump_ignore_extra_jumps;

	public string keyboard_hold_to_wallrun;

	public List<SettingHeader> GetHeaders()
	{
		return null;
	}
}
