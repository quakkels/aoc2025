namespace Day02.Cli;

public class Part1
{
	public int Solve(List<(int start, int end)> pairs)
	{
		var badIds = new List<int>();
		foreach (var pair in pairs)
		{
			badIds.AddRange(FindBadIds(pair.start, pair.end));
		}
		var sum = badIds.Sum();
		return sum;
	}

	public List<int> FindBadIds(int start, int end)
	{
		var result = new List<int>();

		var current = start;
		while (current <= end)
		{
			var isBad = IsBadId(current);
			if (isBad)
			{
				result.Add(current);
			}

			current++;
		}

		return result;

	}

	public bool IsBadId(int id)
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

