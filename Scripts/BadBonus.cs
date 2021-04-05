using System;
namespace RunnerJumper
{
public class BadBonus : InteractiveObject
{
    public event Action Caught;
    protected override  void Interact()
    {
        Caught();
    }


    
}   
}

