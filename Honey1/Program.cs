using System.Text;

var content = File.ReadAllText("../../../Input.txt");

var combs = content.Split(new string[] { "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries);

var combCount = int.Parse(combs[0]);
Console.WriteLine($"Comb count: {combCount}");

var output = new StringBuilder();

var directions = new (int x, int y)[]
{
    (-1, -1),
    (-1, 1),
    (0, 2),
    (0, -2),
    (1, -1),
    (1, 1)
};

// Combs
for (var i = 0; i < combCount; i++)
{
    var lines = combs[i+1].Split(new string[]{"\r\n"}, StringSplitOptions.RemoveEmptyEntries);
    
    // Lines
    for (var j = 1; j < lines.Length; j++)
    {
        // Chars
        for (var k = 0; k < lines[j].Length; k++)
        {
            if (lines[j][k] != 'W') 
                continue;
            
            var empyCount = 0;
            bool free = false;
            
            try
            {
                foreach (var direction in directions)
                {
                        int x = j, y = k;
                        while (!free)
                        {
                            x += direction.x;
                            y += direction.y;
                            if (lines[x][y] == 'X')
                                break;
                        }
                }
            }
            catch (IndexOutOfRangeException e)
            {
                free = true;
            }
            
            if(!free)
                output.AppendLine("TRAPPED");
            else
                output.AppendLine("FREE");
        }
    }
}

File.WriteAllText("../../../Out.txt", output.ToString());
