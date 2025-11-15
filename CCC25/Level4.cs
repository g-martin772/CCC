using System.Text;

namespace CCC25;

public class Level4
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


            for (int i = 0; i < width + 2; i++)
            {
                if (i == drillPos)
                    output.Append('S');
                else
                    output.Append('#');
            }

            int digLimit = 0;

            if (height < width)
            {
                digLimit = Height(output, width, drillPos, digLimit, height);
            }
            else
            {
                digLimit = Width(output, width, drillPos, digLimit, height);
            }
            
            // if (height % 3 == 0 && width % 3 == 0)
            // {
            //     
            // }
            // else if (width % 3 == 0)
            // {
            //     digLimit = Width(output, width, drillPos, digLimit, height);
            // }
            // else
            // {
            //     digLimit = Height(output, width, drillPos, digLimit, height);
            // }

            output.AppendLine();
            for (int i = 0; i < width + 2; i++)
            {
                output.Append('#');
            }

            if (digLimit > depth)
            {
                Console.WriteLine($"Dig Limit Exceeded {digLimit} > {depth}");
                Console.WriteLine($"Width: {width}, Height: {height}, Depth: {depth}, DrillPos: {drillPos}");
            }

            output.AppendLine();
            output.AppendLine();
            headerParsed = false;
        }


        return output.ToString();
    }

    private static int Height(StringBuilder output, int width, int drillPos, int digLimit, int height)
    {
        output.AppendLine();
        output.Append('#');
        for (int i = 0; i < width; i++)
        {
            if (drillPos - 1 == i)
            {
                output.Append('X');
                digLimit++;
            }
            else
                output.Append(':');
        }

        output.Append('#');


        for (int i = 0; i < height - 1; i++)
        {
            output.AppendLine();
            output.Append('#');

            if (i + 2 == height)
            {
                for (int j = 0; j < width; j++)
                {
                    output.Append(':');
                }

                output.Append('#');
                continue;
            }

            if (i % 3 != 0)
            {
                for (int j = 0; j < width; j++)
                {
                    if (drillPos - 1 == j)
                    {
                        output.Append('X');
                        digLimit++;
                    }
                    else
                        output.Append(':');
                }
            }
            else
            {
                for (int j = 0; j < width; j++)
                {
                    {
                        output.Append('X');
                        digLimit++;
                    }
                }
            }

            output.Append('#');
        }

        return digLimit;
    }

    private static int Width(StringBuilder output, int width, int drillPos, int digLimit, int height)
    {
        output.AppendLine();
        output.Append('#');
        for (int i = 0; i < width; i++)
        {
            if (i % 3 == 1 || width - 1 < i || i == drillPos - 1)
            {
                output.Append('X');
                digLimit++;
            }
            else
                output.Append(':');
        }

        output.Append('#');


        for (int i = 0; i < height - 3; i++)
        {
            output.AppendLine();
            output.Append('#');
            for (int j = 0; j < width; j++)
            {
                if (j % 3 == 1 || width - 1 < j)
                {
                    output.Append('X');
                    digLimit++;
                }
                else
                    output.Append(':');
            }

            output.Append('#');
        }

        output.AppendLine();
        output.Append('#');
        for (int j = 0; j < width; j++)
        {
            {
                output.Append('X');
                digLimit++;
            }
        }

        output.Append('#');

        output.AppendLine();
        output.Append('#');
        for (int j = 0; j < width; j++)
        {
            output.Append(':');
        }

        output.Append('#');
        return digLimit;
    }
}