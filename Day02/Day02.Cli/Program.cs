namespace Day02.Cli;

class Program
{
	static void Main(string[] args)
	{
		var lines = File.ReadAllLines(args[0]);
		var input = lines.ToList();
		Solve(input);
	}

	static void Solve(List<string> input)
	{
		foreach ( var line in input) {
			Console.WriteLine($"({line.Count()}) {line}");
		}
	}
}
