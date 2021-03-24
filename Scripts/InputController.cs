using UnityEngine;

namespace RunnerJumper
{
    public class InputController
    {
        public bool Action {get;set;}
 
        public void CheckActionPressed()
        {
            #if UNITY_ANDROID
            #endif
            
            #if UNITY_EDITOR
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Action=true;
            }
            #endif
            
        }

    }   
    
}

