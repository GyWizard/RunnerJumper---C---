using System;
namespace RunnerJumper
{
public class BadBonus : InteractiveObject
{
    public Action Caught;
    protected override  void Interact()
    {
        Caught();
    }
}   
}

