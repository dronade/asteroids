

public class Invoker
{
    Command _forwardCommand;
    Command _turnCommand;

    public Invoker(Command forwardCommand, Command turnCommand)
    {
        _forwardCommand = forwardCommand;
        _turnCommand = turnCommand;
    }

    public void Forward()
    {
        _forwardCommand.Execute();
    }

    public void Turn()
    {
        _turnCommand.Execute();
    }
}