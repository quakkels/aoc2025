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
	[InlineData(1188511885, true)]
	[InlineData(123123, true)]
	[InlineData(1112, false)]
	[InlineData(112, false)]
	[InlineData(111, true)]
	[InlineData(121212, true)]
	public void IsBadIdWillReturnAnswer(long id, bool expectation)
	{
		// act
		var result = _target.IsBadId(id);

		// assert
		Assert.Equal(expectation, result);
	}

	///*
	[Theory]
	[InlineData(11, 22, new long[] {11, 22})]
	[InlineData(95, 115, new long[] {99})]
	public void FindBadIdsGiveListOfBadIds(long start, long end, long[] expected)
	{
		// act
		var result = _target.FindBadIds(start, end);

		// assert
		Assert.Equivalent(expected, result);
	}

	[Theory]
	[InlineData(11, 22, 33)]
	[InlineData(95, 115, 210)]
	[InlineData(998, 1012, 2009)]
	[InlineData(1188511880, 1188511890, 1188511885)]
	public void SolveReturnsCorrectSumOfBadIds(long start, long end, long expectedSum)
	{
		// arrange

		// act
		var result = _target.Solve([(start, end)]);

		// assert
		Assert.Equal(expectedSum, result);
	}
	//*/
}
