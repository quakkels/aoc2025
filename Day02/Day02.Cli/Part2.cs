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

		Console.WriteLine("==========================================");
		Console.WriteLine(string.Join(", ", badIds));
		Console.WriteLine($"Bad Sum: {sum}");
		Console.WriteLine("==========================================");

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

		Console.WriteLine("--------------------------------------------");
		Console.WriteLine($"Testing id: {id}");

		var pattern = new StringBuilder();
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
			else if (pattern.ToString() == token.Substring(i, pattern.Length))
			{
				/*Console.WriteLine(
						$"matching substring: pattern {pattern}, "
						+ $"substring {token.Substring(i, pattern.Length)}");*/

				isBad = true;

				var isPatternFit = (token.Length % pattern.Length) == 0;
				if (isPatternFit)
				{
					var repeatCount = token.Length / pattern.Length;
					for (var j = 0; j < repeatCount; j++)
					{
						var substringStart = j * pattern.Length;
						if (substringStart == token.Length)
						{
							continue;
						}

						if (pattern.ToString() != token.Substring(substringStart, pattern.Length))
						{
							isBad = false;
						}
					}

					Console.WriteLine($">>> pattern: {pattern}, token: {token}, isbad: {isBad}");

					if (isBad)
					{
						break;
					}
				}

				i += pattern.Length -1;
			}
			else
			{
				isBad = false;
			}

			pattern.Append(token[i]);

			if (isBad)
			{
				Console.WriteLine($"bad id: {token}");
			}
			else Console.WriteLine($"NOT BAD: {token}");
		}

		return isBad;
	}
}

