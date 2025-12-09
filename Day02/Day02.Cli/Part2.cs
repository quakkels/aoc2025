using System.Text;

namespace Day02.Cli;

public class Part2
{
	public ulong Solve(List<(long start, long end)> pairs)
	{
		var badIds = new List<ulong>();
		foreach (var pair in pairs)
		{
			badIds.AddRange(FindBadIds(pair.start, pair.end));
		}

		ulong sum = badIds.Aggregate((a, b) => a + b);

		Console.WriteLine("==========================================");
		Console.WriteLine($"Cursed Sum: {sum}");
		Console.WriteLine("==========================================");

		return sum;
	}

	public List<ulong> FindBadIds(long start, long end)
	{
		var result = new List<ulong>();

		var current = start;
		while (current <= end)
		{
			var isBad = IsBadId(current);
			var isBadCursed = IsBadIdCursed(current);
			if (isBad != isBadCursed)
			{
				Console.WriteLine($"Cursed method should have returned bad: {isBad}, value: {current}");
			}

			if (isBad)
			{
				result.Add((ulong)current);
			}

			current++;
		}

		return result;

	}

	public bool IsBadId(long id)
	{
		string s = id.ToString();
		if (s.Length < 2) return false;

		for (int len = 1; len <= s.Length / 2; len++)
		{
			if (s.Length % len != 0) continue;

			string pattern = s.Substring(0, len);
			if (Enumerable.Repeat(pattern, s.Length / len).Aggregate(string.Concat) == s)
				return true;
		}
		return false;
	}

	public bool IsBadIdCursed(long id)
	{
		string token = id.ToString();
		var isBad = false;
		var halfIndex = (token.Length / 2);

		var pattern = new StringBuilder();
		for (var i = 0; i < token.Length; i++)
		{
			if (i == 0)
			{
				pattern.Append(token[i]).ToString();
				continue;
			}

			if (pattern.Length + i > token.Length)
			{
				Console.WriteLine("Set bad false 1");
				isBad = false;
				break;
			}
			else if (pattern.ToString() == token.Substring(i, pattern.Length))
			{
				Console.WriteLine("Set bad true 1");
				isBad = true;

				if (i + pattern.Length == halfIndex - 1)
				{
					break;
				}

				var isPatternFit = (token.Length % pattern.Length) == 0;
				if (isPatternFit)
				{
					var repeatCount = token.Length / pattern.Length;
					for (var j = 0; j < repeatCount; j++)
					{
						var substringStart = j * pattern.Length;
						if (substringStart == token.Length)
						{
							if (pattern.ToString() == token.Substring(substringStart, pattern.Length))
							{
								Console.WriteLine("Set bad true 2");
								isBad = true;
							}

							continue;
						}

						if (pattern.ToString() != token.Substring(substringStart, pattern.Length))
						{
							Console.WriteLine("set bad false 2");
							isBad = false;
						}
					}

					if (isBad)
					{
						break;
					}
				}
				else
				{
					Console.WriteLine("set bad false 3");
					isBad = false;
					break;
				}

				i += pattern.Length -1;
			}
			else
			{
				Console.WriteLine("set bad false 4");
				isBad = false;
			}

			pattern.Append(token[i]);
		}

		return isBad;
	}
}

