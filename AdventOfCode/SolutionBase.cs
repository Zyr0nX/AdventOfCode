namespace AdventOfCode;

public abstract class SolutionBase
{
    public int Day { get; init; }
    public int Year { get; init; }
    public string Input { get => LoadInput(); }
    public IEnumerable<string> Answer { get => Solve(); }
    public string LoadInput()
    {
        var inputLocation = $"../../../Year{Year}/Day{Day}/input";
        return File.ReadAllText(inputLocation);
    }

    public IEnumerable<string> Solve()
    {
        yield return Part1Solver();
        yield return Part2Solver();
    }

    public abstract string Part1Solver();
    public abstract string Part2Solver();
}