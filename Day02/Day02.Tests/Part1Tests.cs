using Day02.Cli;

namespace Day02.Tests;

public class Part1Tests
{
	private readonly Part1 _target;

	public Part1Tests()
	{
		_target = new Part1();
	}

	[Theory]
	[InlineData(11, true)]
	[InlineData(22, true)]
	[InlineData(111, false)]
	[InlineData(123123123, false)]
	public void IsBadIdWillReturnAnswer(int id, bool expectation)
	{
		// act
		var result = _target.IsBadId(id);

		// assert
		Assert.Equal(expectation, result);
	}

	[Theory]
	[InlineData(11, 22, new [] {11, 22})]
	[InlineData(95, 115, new [] {99})]
	public void FindBadIdsGiveListOfBadIds(int start, int end, int[] expected)
	{
		// act
		var result = _target.FindBadIds(start, end);

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
