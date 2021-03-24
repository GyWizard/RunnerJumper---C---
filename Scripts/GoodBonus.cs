
using UnityEngine;
using static UnityEngine.Debug;

namespace RunnerJumper
{

    public class GoodBonus : InteractiveObject,ICollect,IDisplay
    {

        public void Collect()
        {
            gameObject.SetActive(false);
        }
        public void Display()
        {
            Log($"Collected! {this.gameObject.name}");
        }

        protected override void Interact()
        {
            Collect();
            Display();
        }

        
    }    
}

