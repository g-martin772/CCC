using System.Text;

namespace Drone;

public class Level3
{
    public static string Execute(string data)
    {
        var output = new StringBuilder();

        var itemCount = int.Parse(data.Split('\n', 2)[0]);
        Console.WriteLine("Line count: " + itemCount);
        
        var timeLimit = int.Parse(data.Split('\n', 3)[1]);
        Console.WriteLine("TimeLimit: " + timeLimit);

        foreach (var line in data.Split('\n').Skip(2).Take(itemCount))
        {
            var targetHeight = int.Parse(line);
            Console.WriteLine("TargetHeight: " + targetHeight);

            var height = 0;
            var velocity = 0;
            var iterations = 0;
            var targetLandingVelocity = -1;
            
            while (height < targetHeight)
            {
                var a = 20;
                velocity += a - 10;
                height += velocity;
                
                output.Append($"{a} ");
                iterations++;
            }

            while (height > targetHeight)
            {
                var a = 0;
                velocity += a - 10;
                height += velocity;
                output.Append($"{a} ");
                iterations++;
            }

            // while (height > 10)
            // {
            //     var a = Math.Min(20, Math.Abs(targetLandingVelocity - velocity + height));
            //     velocity += a - 10;
            //     height += velocity;
            //     output.Append($"{a} ");
            //     iterations++;
            // }

            Console.WriteLine($"End height {height}");
            Console.WriteLine($"End velocity {velocity}");
            
            if (iterations > timeLimit)
                Console.WriteLine("Time limit exceeded!");
            
            output.Remove(output.Length - 1, 1);
            output.AppendLine();
        }

        return output.ToString();
    }
}