using System.Text;

namespace CCC25;

public class Level2
{
    public static string Execute(string data)
    {
        var output = new StringBuilder();

        var itemCount = int.Parse(data.Split('\n', 2)[0]);
        Console.WriteLine("Line count: " + itemCount);

        var width = 3;
        var drillPos = 0;
        var depth = 0;
        var height = 0;

        foreach (var line in data.Split('\n').Skip(1))
        {
            Console.WriteLine(line);
            if (line.StartsWith('#'))
            {
                height++;
                continue;
            }

            if (line.StartsWith('\n') || line.StartsWith(' ') || line.StartsWith('\r') || string.IsNullOrWhiteSpace(line)) continue;

            var numbers = line.Split(' ');
            drillPos = int.Parse(numbers[0]);
            depth = int.Parse(numbers[1]);
            height = depth;

            for (int i = 0; i < width + 2; i++)
            {
                if (i == drillPos-1)
                    output.Append('S');
                else
                    output.Append('#');
            }

            for (int i = 0; i < height; i++)
            {
                output.AppendLine();
                output.Append('#');
                for (int j = 0; j < width; j++)
                {
                    if (j == drillPos-2 && i <= depth +1)
                        output.Append('X');
                    else
                        output.Append(':');
                }

                output.Append('#');
            }

            output.AppendLine();
            for (int i = 0; i < width + 2; i++)
            {
                output.Append('#');
            }

            output.AppendLine();
            output.AppendLine();
        }


        return output.ToString();
    }
}