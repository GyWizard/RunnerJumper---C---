using System;
namespace RunnerJumper
{
    public class Exit : InteractiveObject
    {
        public event Action EnterExit;
        protected override  void Interact()
        {
            EnterExit();
        }
    }    
}

