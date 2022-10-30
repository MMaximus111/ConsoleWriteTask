# ConsoleWriteTask 🛰
### Custom awaitable type and asynchronius methods ⚙️🛠

Here you can find how to `await` any type and mark a method with any return class with `async` modifier:

1. `await` your custom type:
```csharp
await ConsoleWriteTaskAsync("Ho-Ho-Ho");
```

2. `async` method with your custom type:
```csharp
async ConsoleWriteTask ConsoleWriteAsync(string text)
{
    Console.WriteLine($"method started: {Environment.CurrentManagedThreadId}");

    await Task.Run(async () =>
    {
        await Task.Delay(1000);

        Console.WriteLine(text);
    });

    Console.WriteLine($"method finished: {Environment.CurrentManagedThreadId}");
}
```


