using System.Runtime.CompilerServices;

namespace ConsoleWriteTask;

public readonly struct ConsoleWriteTaskAwaiter : INotifyCompletion
{
    private readonly ConsoleWriteTask _consoleWriteTask;

    public ConsoleWriteTaskAwaiter(ConsoleWriteTask consoleWriteTask)
    {
        _consoleWriteTask = consoleWriteTask;
    }

    public bool IsCompleted => _consoleWriteTask.Finished;

    public ConsoleWriteTask GetResult() => _consoleWriteTask;

    public void OnCompleted(Action continuation)
    {
        if (IsCompleted)
        {
            continuation();
            return;
        }

        ThreadPool.QueueUserWorkItem(_ =>
        {
            SynchronizationContext? context = SynchronizationContext.Current;

            if (context != null)
            {
                context.Post(_ => continuation(), null);
            }
            else
            {
                continuation();
            }
        });
    }
}