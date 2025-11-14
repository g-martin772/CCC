using System.Text;

namespace Drone;

public class Level1
{
    public static string Execute(string data)
    {
        var output = new StringBuilder();

        var itemCount = int.Parse(data.Split('\n', 2)[0]);
        Console.WriteLine("Line count: " + itemCount);

        foreach (var line in data.Split('\n').Skip(1).Take(itemCount))
        {
            var sum = 0;
            foreach (var number in line.Split(' '))
            {
                sum += int.Parse(number);
                Console.WriteLine();
            }

            output.AppendLine(sum.ToString());
        }

        return output.ToString();
    }
}