using System.Runtime.CompilerServices;

namespace ConsoleWriteTask;

public class ConsoleWriteTaskBuilder
{
    private readonly ConsoleWriteTask _task;
    private ConsoleWriteTaskBuilder(ConsoleWriteTask task)
    {
        _task = task;
    }

    public static ConsoleWriteTaskBuilder Create() => new ConsoleWriteTaskBuilder(new ConsoleWriteTask());

    public void Start<TStateMachine>(ref TStateMachine stateMachine) where TStateMachine : IAsyncStateMachine
    {
        stateMachine.MoveNext();
    }

    public void SetStateMachine(IAsyncStateMachine stateMachine)
    {
    }

    public void SetResult()
    {
        _task.Finished = true;
    }

    public void SetException(Exception exception)
    {
    }

    public ConsoleWriteTask Task => _task;

    public void AwaitOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine)
        where TAwaiter : INotifyCompletion where TStateMachine : IAsyncStateMachine
    {
        awaiter.OnCompleted(stateMachine.MoveNext);
    }

    public void AwaitUnsafeOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine)
        where TAwaiter : ICriticalNotifyCompletion where TStateMachine : IAsyncStateMachine
    {
        awaiter.UnsafeOnCompleted(stateMachine.MoveNext);
    }
}