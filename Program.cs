Console.WriteLine($"before await: {Environment.CurrentManagedThreadId}");

await ConsoleWriteAsync("Ho-Ho-Ho");

Console.WriteLine($"after await: {Environment.CurrentManagedThreadId}");

Console.ReadLine();

async ConsoleWriteTask.ConsoleWriteTask ConsoleWriteAsync(string text)
{
    Console.WriteLine($"method started: {Environment.CurrentManagedThreadId}");

    await Task.Run(async () =>
    {
        await Task.Delay(1000);

        Console.WriteLine(text);
    });

    Console.WriteLine($"method finished: {Environment.CurrentManagedThreadId}");
}