namespace day01;

class Program
{
	static void Main(string[] args)
	{
		var lines = File.ReadAllLines(args[0]);
		Part2(lines.ToList());
	}

	static void Part2(List<string> input)
	{
		int zeroPositionCount = 0;
		var currentPosition = 50;
		var finalCrossedZeroCount = 0;

		foreach (var line in input)
		{
			var turn = GetTurn(line);

			(currentPosition, var crossedZeroCount) = GetPosition(currentPosition,turn);
			finalCrossedZeroCount += crossedZeroCount;

			if (currentPosition == 0)
			{
				zeroPositionCount++;
			}
		}
		Console.WriteLine(zeroPositionCount);
		Console.WriteLine("crossed zero count:" + finalCrossedZeroCount);

		GetPosition(82, -30);
		GetPosition(82, -200);
		GetPosition(99, 2);
		GetPosition(99, 102);
	}

	static int GetTurn(string line)
	{
		var numberOnly = line.Substring(1);
		if (line.StartsWith("L"))
		{
			return int.Parse("-" + numberOnly);
		}
		return int.Parse(numberOnly);
	}

	static (int newPosition, int crossedZeroCount) GetPosition(int currentPosition, int move)
	{
		var raw = currentPosition + move;
		var newPosition = (raw % 100 + 100) % 100;

		if (move == 0) return (currentPosition, 0);

		int totalCrossings = 0;
		if (move >= 0)
		{
			totalCrossings = (int)((raw + 99L - currentPosition) / 100L);
			long distance = currentPosition - raw;
		}
		else 
		{
			if (-move < currentPosition)
			{
				totalCrossings = 0;
			}
			else
			{
				totalCrossings = (int)((currentPosition - raw + 99L) / 100L);
			}
		}

		var startedAtZero = currentPosition == 0;
		var landedOnZero = newPosition == 0;

		if (startedAtZero) totalCrossings--;
		if (landedOnZero) totalCrossings--;

		int crossedZeroCount = Math.Max(0, totalCrossings);

		Console.WriteLine($"current: {currentPosition, 5}, move: {move,5}, raw: {raw, 5}, newPosition: {newPosition,5}, crossed: {crossedZeroCount,3}, landed:{newPosition == 0}");

		if (newPosition == 0)
		{
			crossedZeroCount++;
		}

		return (newPosition, crossedZeroCount);
		/*
			 var crossedZeroCount = 0;
			 var newPosition = currentPosition + move;
			 if (newPosition > 99)
			 {
			 newPosition %= 100;
			 }
			 else if (newPosition < 0)
			 {
			 newPosition = (newPosition % 100 + 100) % 100;
			 }

			 return (newPosition, crossedZeroCount);
			 */
	}
}
