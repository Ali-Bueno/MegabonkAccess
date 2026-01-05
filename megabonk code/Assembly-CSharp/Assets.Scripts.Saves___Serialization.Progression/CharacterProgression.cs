namespace Assets.Scripts.Saves___Serialization.Progression;

public class CharacterProgression
{
	public int xp;

	public int numRuns;

	private float xpModifier;

	public void OnRunFinished(int xp)
	{
	}

	public int GetRank()
	{
		return 0;
	}

	public bool HasStar()
	{
		return false;
	}
}
