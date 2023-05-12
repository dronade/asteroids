using System.Collections.Generic;
using UnityEngine;

public class CommandManager : MonoBehaviour
{
    private Stack<ICommand> commandStack = new Stack<ICommand>();

    public void Execute(ICommand command)
    {
        commandStack.Push(command);
        command.Execute();
    }
}
