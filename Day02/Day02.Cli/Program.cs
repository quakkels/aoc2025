namespace Day02.Cli;

class Program
{
	static void Main(string[] args)
	{
		var lines = File.ReadAllLines(args[0]);
		var input = lines.ToList();
		SolvePart1(input);
	}

	static void SolvePart1(List<string> input)
	{
		var idRanges = input[0].Split(",");
		var pairs = new List<(int start, int end)>();
		foreach(var idRange in idRanges)
		{
			var parts = idRange.Split("-");
			pairs.Add((int.Parse(parts[0]), int.Parse(parts[1])));
		}

		var part1 = new Part1();
		var answer = part1.Solve(pairs);
		Console.WriteLine($"Part1: {answer}");
	}
}

