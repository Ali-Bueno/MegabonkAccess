using UnityEngine;

namespace Assets.Scripts.UI.DynamicWindows;

public class DWindowBase : MonoBehaviour
{
	private int rebuildAfterFrames;

	protected void QueueRebuild()
	{
	}

	private void LateUpdate()
	{
	}
}
