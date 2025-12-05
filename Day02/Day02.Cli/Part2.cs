namespace Day02.Cli;

public class Part2
{
	public long Solve(List<(long start, long end)> pairs)
	{
		var badIds = new List<long>();
		foreach (var pair in pairs)
		{
			badIds.AddRange(FindBadIds(pair.start, pair.end));
		}
		var sum = badIds.Sum();
		return sum;
	}

	public List<long> FindBadIds(long start, long end)
	{
		var result = new List<long>();

		var current = start;
		while (current <= end)
		{
			var isBad = IsBadId(current);
			if (isBad)
			{
				result.Add(current);
				Console.WriteLine(current);
			}

			current++;
		}

		return result;

	}

	public bool IsBadId(long id)
	{
		string token = id.ToString();
		
		if (token.Length % 2 != 0)
		{
			return false;
		}

		var halfIndex = (token.Length / 2);

		var first = token.Substring(0, halfIndex);
		var second = token.Substring(halfIndex);

		return first == second;
	}
}

