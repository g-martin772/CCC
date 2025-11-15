using System.Text;

namespace CCC25;

public class Level1
{
    public static string Execute(string data)
    {
        var output = new StringBuilder();

        var itemCount = int.Parse(data.Split('\n', 2)[0]);
        Console.WriteLine("Line count: " + itemCount);

        foreach (var line in data.Split('\n').Skip(1).Take(itemCount))
        {
            
            
            
            var numbers = line.Split(' ');
            var width = int.Parse(numbers[0]);
            var height = int.Parse(numbers[1]);

            for (int i = 0; i < width + 2; i++)
            {
                output.Append('#');
            }

            for (int i = 0; i < height; i++)
            {
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
        }


        return output.ToString();
    }
}