using Day02.Cli;

namespace Day02.Tests;

public class Part2Tests
{
	private readonly Part2 _target;

	public Part2Tests()
	{
		_target = new Part2();
	}

	[Theory]
	[InlineData(12, false)]
	[InlineData(11, true)]
	[InlineData(111, true)]
	[InlineData(123123, true)]
	[InlineData(1112, false)]
	public void IsBadIdWillReturnAnswer(int id, bool expectation)
	{
		// act
		var result = _target.IsBadId(id);

		// assert
		Assert.Equal(expectation, result);
	}

	[Theory]
	[InlineData(11, 22, new long[] {11, 22})]
	[InlineData(95, 115, new long[] {99})]
	public void FindBadIdsGiveListOfBadIds(long start, long end, long[] expected)
	{
		// act
		var result = _target.FindBadIds(start, end);
		Console.WriteLine($"result: {string.Join(", ", result)}");
		Console.WriteLine($"expected: {string.Join(", ", expected)}");

		// assert
		Assert.Equivalent(expected, result);
	}

	[Fact]
	public void WillSolveOneRange()
	{
		// arrange
		var start = 11;
		var end = 22;

		// act
		var result = _target.Solve([(start, end)]);

		// assert
		Assert.Equal(33, result);
	}
}
