using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PPController : MonoBehaviour
{
	private UnityEngine.Rendering.PostProcessing.Bloom bloom;

	private MotionBlur motionBlur;

	private AmbientOcclusion ao;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void Start()
	{
	}

	private void OnSettingUpdated(string name, object oldValue, object newValue)
	{
	}

	public void SetBloom(int value)
	{
	}

	public void SetMotionBlur(int on)
	{
	}

	public void SetAO(int on)
	{
	}
}
