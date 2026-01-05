using System;

public class ConsistentRandom : Random
{
	private const int MBIG = 2147483647;

	private const int MSEED = 161803398;

	private const int MZ = 0;

	private int inext;

	private int inextp;

	private int[] SeedArray;

	public ConsistentRandom()
	{
	}

	public ConsistentRandom(int seed)
	{
	}

	protected override double Sample()
	{
		return 0.0;
	}

	private int InternalSample()
	{
		return 0;
	}

	public override int Next()
	{
		return 0;
	}

	private double GetSampleForLargeRange()
	{
		return 0.0;
	}

	public override int Next(int minValue, int maxValue)
	{
		return 0;
	}

	public override void NextBytes(byte[] buffer)
	{
	}
}
