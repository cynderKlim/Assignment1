string? choice;
string file = "superMarioCharacters.txt";
do
{
    Console.WriteLine("1) Read data from file.");
    Console.WriteLine("2) Append file from data.");
    Console.WriteLine("Enter any other key to exit.");

    choice = Console.ReadLine();
    if (choice == "1")
    {
        if (File.Exists(file))
        {
            int characterId = 0;
            int count = 0;

            StreamReader sr = new(file);
            while (!sr.EndOfStream)
            {
                string? line = sr.ReadLine();
                string[] arr = String.IsNullOrEmpty(line) ? [] : line.Split(',');
                Console.WriteLine("ID: {0}\nName: {1}\nRelationship to Mario: {2}", arr[0], arr[1], arr[2]);
                // add to accumulators
                characterId += arr[1] == "1" ? 1 : arr[1] == "2" ? 2 : arr[1] == "3" ? 3 : 0;
                count += 1;
            }
            sr.Close();
            int characters = characterId + count;
            Console.WriteLine("{0:n0} character(s) saved to file.", characters);
        }
        else
        {
            Console.WriteLine("File does not exist");
        }
    }
    else if (choice == "2")
    {
        StreamWriter sw = new(file);
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("Enter a character (Y/N)?");
            string? resp = Console.ReadLine()?.ToUpper();
            if (resp != "Y") { break; }
            Console.WriteLine("Enter a character ID (numbers 1-3).");
            string? id = Console.ReadLine();
            Console.WriteLine("Enter the character name.");
            string? name = Console.ReadLine();
            Console.WriteLine("Enter the relationship they have to Mario.");
            string? relationship = Console.ReadLine();
            sw.WriteLine("{0},{1},{2}", id, name, relationship);
        }
        sw.Close();
    }
} while (choice == "1" || choice == "2");