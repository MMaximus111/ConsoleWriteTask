using System.Runtime.CompilerServices;

namespace ConsoleWriteTask;

public readonly struct ConfiguredConsoleWriteTaskAwaiter : INotifyCompletion
{
    private readonly ConsoleWriteTask _consoleWriteTask;
    private readonly bool _continueOnCapturedContext;

    public ConfiguredConsoleWriteTaskAwaiter(ConsoleWriteTask consoleWriteTask, bool continueOnCapturedContext)
    {
        _consoleWriteTask = consoleWriteTask;
        _continueOnCapturedContext = continueOnCapturedContext;
    }

    public bool IsCompleted => _consoleWriteTask.Finished;

    public ConsoleWriteTask GetResult() => _consoleWriteTask;

    public void OnCompleted(Action continuation)
    {
        SynchronizationContext? context = SynchronizationContext.Current;

        if (IsCompleted || context is null)
        {
            continuation();
            return;
        }

        if (_continueOnCapturedContext)
        {
            context.Post(_ => continuation(), null);
        }
        else
        {
            ThreadPool.QueueUserWorkItem(_ => { context.Post(_ => continuation(), null); });
        }
    }
}