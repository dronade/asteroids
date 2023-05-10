

public class Invoker
{
    ICommand _forwardCommand;
    ICommand _turnCommand;

    public Invoker(ICommand forwardCommand, ICommand turnCommand)
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