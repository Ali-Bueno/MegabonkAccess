using Rewired;
using Steamworks;
using UnityEngine;

public class PauseHandler : MonoBehaviour
{
	protected Callback<GameOverlayActivated_t> m_GameOverlayActivated;

	public PauseUi pauseUi;

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnControllerDisconnected(ControllerStatusChangedEventArgs args)
	{
	}

	private void OnGameOverlayActivated(GameOverlayActivated_t pCallback)
	{
	}
}
