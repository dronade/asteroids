public abstract class Command
{
    protected Player player;
    public Command(Player p)
    {
        player = p;
    }
    

    public abstract void Execute();
}