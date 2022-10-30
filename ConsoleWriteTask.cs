using System.Runtime.CompilerServices;

namespace ConsoleWriteTask;

[AsyncMethodBuilder(typeof(ConsoleWriteTaskBuilder))]
public class ConsoleWriteTask
{
    public bool Finished { get; set; }

    public ConfiguredConsoleTaskAwaitable ConfigureAwait(bool continueOnCapturedContext)
    {
        return new ConfiguredConsoleTaskAwaitable(this, continueOnCapturedContext);
    }

    public ConsoleWriteTaskAwaiter GetAwaiter()
    {
        return new ConsoleWriteTaskAwaiter(this);
    }
}