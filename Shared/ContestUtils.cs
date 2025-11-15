namespace Shared;

public static class ContestUtils
{
    public static int LevelId = 0;

    public static Func<string, string>? Runner;
    
    public static void Execute()
    {
        for (int i = 1; i <= 2; i++)
        {
            Console.WriteLine($"Level {LevelId} - Input {i}");
            var data = File.ReadAllText($"input/level{LevelId}_{i}.in");
            var output = Runner!(data);
            File.WriteAllText($"output/level{LevelId}_{i}.out", output);
            Console.WriteLine("\n-------------------------\n");
        }
    }
}