namespace RunnerJumper
{
public class BadBonus : InteractiveObject
{
    private RestartManager restartManager = new RestartManager();
    

    // Start is called before the first frame update
    protected override  void Interact()
    {
        restartManager.Restart();
    }
}
    
}

