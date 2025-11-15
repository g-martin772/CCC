using CCC25;
using Shared;

ContestUtils.LevelId = int.Parse(args[0]);

ContestUtils.Runner = ContestUtils.LevelId switch
{
    1 => Level1.Execute,
    2 => Level2.Execute,
    3 => Level3.Execute,
    4 => Level4.Execute,
    5 => Level5.Execute,
    6 => Level6.Execute,
    _ => throw new Exception("Invalid level id")
};

ContestUtils.Execute();