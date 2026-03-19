using lab3ALG;

internal class Program
{
    private static void Main(string[] args)
    {
        MemoryManager memoryManager = new MemoryManager(1024, 2048);
        TaskManager taskManager = new TaskManager(memoryManager);
        taskManager.Start();
    }
}