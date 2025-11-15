using System.Text;

namespace CCC25;

public class Level3
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
        var headerParsed = false;

        foreach (var line in data.Split('\n').Skip(1))
        {
            if (line.StartsWith('#'))
            {
                if (line.IndexOf('S') != -1)
                    drillPos = line.IndexOf('S');
                continue;
            }

            if (!headerParsed && string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            if (!headerParsed)
            {
                var numbers = line.Split(' ');
                width = int.Parse(numbers[0]);
                height = int.Parse(numbers[1]);
                depth = int.Parse(numbers[2]);
                headerParsed = true;
                continue;
            }

            Console.WriteLine($"Width: {width}, Height: {height}, Depth: {depth}, DrillPos: {drillPos}");

            for (int i = 0; i < width + 2; i++)
            {
                if (i == drillPos)
                    output.Append('S');
                else
                    output.Append('#');
            }

            if (width == 3)
            {
                output.AppendLine();
                output.Append('#');

                if (drillPos == 1)
                {
                    output.Append('X');
                    output.Append('X');
                    output.Append(':');
                }
                else if (drillPos == 2)
                {
                    output.Append(':');
                    output.Append('X');
                    output.Append(':');
                }
                else if (drillPos == 3)
                {
                    output.Append(':');
                    output.Append('X');
                    output.Append('X');
                }

                output.Append('#');


                for (int i = 0; i < height - 1; i++)
                {
                    output.AppendLine();
                    output.Append('#');
                    for (int j = 0; j < width; j++)
                    {
                        if (j == 1)
                            output.Append('X');
                        else
                            output.Append(':');
                    }

                    output.Append('#');
                }
            }
            else
            {
                for (int i = 0; i < 1; i++)
                {
                    output.AppendLine();
                    output.Append('#');
                    for (int j = 0; j < width; j++)
                    {
                        if (j == drillPos - 1 && i <= depth + 1)
                            output.Append('X');
                        else
                            output.Append(':');
                    }

                    output.Append('#');
                }

                output.AppendLine();
                output.Append('#');
                for (int j = 0; j < width; j++)
                {
                    output.Append('X');
                }

                output.Append('#');

                output.AppendLine();
                output.Append('#');
                for (int j = 0; j < width; j++)
                {
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
            headerParsed = false;
        }


        return output.ToString();
    }
}