using UnityEngine;

namespace RunnerJumper
{
    public sealed class InputController: IExecute,IExecuteFixed
    {
        private readonly Movement _movement;
        private bool _jump;
        public InputController(Movement movement)
        {
            _movement = movement;
        }
        private void CheckActionPressed() //  проверка на нажатие кнопки действия
        {
            #if UNITY_ANDROID //  для андройда
            #endif
            
            #if UNITY_EDITOR // для юнити
            if(Input.GetKeyDown(KeyCode.Space))
            {
                _jump=true;
            }
            #endif
        }

        public void Execute()
        {
            CheckActionPressed(); 
        }
        public void FixedExecute()
        {
            _movement.Run();
            if(_jump)
            {
                _movement.Jump();
                _jump = false;
            }
        }
    }      
}

