namespace ConsoleWriteTask;

public readonly struct ConfiguredConsoleTaskAwaitable
{
    private readonly ConsoleWriteTask _task;
    private readonly bool _continueOnCapturedContext;

    public ConfiguredConsoleTaskAwaitable(ConsoleWriteTask task, bool continueOnCapturedContext)
    {
        _task = task;
        _continueOnCapturedContext = continueOnCapturedContext;
    }

    public ConfiguredConsoleWriteTaskAwaiter GetAwaiter()
    {
        return new ConfiguredConsoleWriteTaskAwaiter(_task, _continueOnCapturedContext);
    }
}