using UnityEngine;

namespace RunnerJumper
{
    public sealed class InputController
    {
        public bool Action {get;set;}
 
        public void CheckActionPressed() //  проверка на нажатие кнопки действия
        {
            #if UNITY_ANDROID //  для андройда
            #endif
            
            #if UNITY_EDITOR // для юнити
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Action=true;
            }
            #endif
            
        }

    }   
    
}

