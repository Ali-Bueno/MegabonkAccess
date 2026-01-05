using System.Collections.Generic;

namespace Assets.Scripts.Settings___Saves.SaveFiles;

public class CFVideoSettings : CFSettings
{
	public int resolution;

	public int target_monitor;

	public int fullscreen_mode;

	public int vsync;

	public float fps_limit;

	public float fov;

	public float camera_distance;

	public int grass_quality;

	public int shadow_quality;

	public int shadow_resolution;

	public int anti_aliasing;

	public int soft_particles;

	public int bloom;

	public int motion_blur;

	public int ambient_occlusion;

	public List<SettingHeader> GetHeaders()
	{
		return null;
	}
}
