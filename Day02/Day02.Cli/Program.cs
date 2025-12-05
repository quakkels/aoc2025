namespace Day02.Cli;

class Program
{
	static void Main(string[] args)
	{
		var lines = File.ReadAllLines(args[0]);
		var input = lines.ToList();
		SolvePuzzle(input);
	}

	static void SolvePuzzle(List<string> input)
	{
		var idRanges = input[0].Split(",");
		var pairs = new List<(long start, long end)>();
		foreach(var idRange in idRanges)
		{
			var parts = idRange.Split("-");
			pairs.Add((long.Parse(parts[0]), long.Parse(parts[1])));
		}

		var part1 = new Part1();
		var answer = part1.Solve(pairs);
		Console.WriteLine($"Part1: {answer}");

		var part2 = new Part2();
		var answer2 = part2.Solve(pairs);
		Console.WriteLine($"Part2: {answer2}");
	}
}

