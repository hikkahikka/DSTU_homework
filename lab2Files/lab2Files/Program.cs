bool IsExistOrNull(string path)
{
    if (!File.Exists(path))
    {
        Console.WriteLine("File is not exist");
        return false;
    }
    if (string.IsNullOrEmpty(File.ReadAllText(path))){
        Console.WriteLine("File is null or empty");
        return false;
    }
    return true;
}
void ShowFile(string path)
{
    Console.WriteLine();
    Console.WriteLine(File.ReadAllText(path));
}
void AppendToFile(string path, string line)
{
    File.AppendAllText(path, line + "\n");
}
void DeleteLines(string path, int k) {
    var l = File.ReadAllLines(path).ToList();
    if (l.Count < k)
    {
        Console.WriteLine("The file contains fewer k lines"); 
        return;
    }
    File.WriteAllText(path, "");
    for(int i  = 0; i < l.Count - k; i++)
    {
        AppendToFile(path, l[i]);
    }
}
bool CheckValue(string? value, out int result)
{
    return Int32.TryParse(value, out result);
}
void Task1()
{
    if (!IsExistOrNull("b.txt")) return;
    Console.WriteLine("Input k: ");
    string? ans;
    int k;
    while (true)
    {
        ans = Console.ReadLine();
        if (CheckValue(ans, out k) && k > 0) break;
        else
        {
            Console.WriteLine("Input correct value!!!");
            Console.WriteLine("Input k: ");
        }
    }
    DeleteLines("b.txt",k);
    ShowFile("b.txt");
}
string ReadFile(string path)
{
    return File.ReadAllText(path);
}
void Task2()
{
    if(!IsExistOrNull("t2.txt"))return;
    File.Create("g.txt").Close();
    int value;
    int i = 1;
    foreach (var word in ReadFile("t2.txt").Replace("\n", " ").Replace("\r","").Split(" "))
    {
        if(CheckValue(word, out value)) AppendToFile("g.txt", word+" — "+i++);
    }
    ShowFile("g.txt");
}
void Start()
{
    while (true)
    {
        Console.WriteLine("Choose the task (1/2) or \"e\" to exit: ");

        string ans = Console.ReadLine();
        switch (ans)
        {
            case "1":
                Task1();
                break;
            case "2":
                Task2();
                break;
            case "e":
                Console.WriteLine("Goodbye");
                return;
            default:
                Console.WriteLine("Incorrect answer!");
                break;
        }
    }
}

Start();