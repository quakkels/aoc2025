using System.Text;

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
		var isBad = false;
		var halfIndex = (token.Length / 2);

		var pattern = new StringBuilder();
		Console.WriteLine("=============");
		for (var i = 0; i < token.Length; i++)
		{
			if (i == 0)
			{
				pattern.Append(token[i]).ToString();
				continue;
			}

			Console.WriteLine($"i={i}  pattern.Length={pattern.Length}  pattern='{pattern}'");

			if (pattern.Length + i > token.Length)
			{
				isBad = false;
				break;
			}

			if (pattern.ToString() == token.Substring(i, pattern.Length))
			{
				Console.WriteLine(
						$"matching substring: pattern {pattern}, "
						+ $"substring {token.Substring(i, pattern.Length)}");
				isBad = true;
				i += pattern.Length -1;
			}
			else
			{
				isBad = false;
				pattern.Append(token[i]);
				Console.WriteLine("NOT BAD");
			}

			Console.WriteLine(token[i]);
		}

		Console.WriteLine($"isbad: {isBad}");

		return isBad;
	}
}

