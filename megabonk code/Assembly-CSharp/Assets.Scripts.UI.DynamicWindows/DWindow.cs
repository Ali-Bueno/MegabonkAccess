using TMPro;

namespace Assets.Scripts.UI.DynamicWindows;

public class DWindow : DWindowBase
{
	public TextMeshProUGUI t_header;

	public TextMeshProUGUI t_content;

	public TextMeshProUGUI t_button;

	public void Set(string header, string content, string buttonText = "Okey")
	{
	}

	public void Close()
	{
	}
}
