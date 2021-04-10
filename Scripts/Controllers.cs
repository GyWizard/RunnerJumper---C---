using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerJumper
{
    public class Controllers: IExecute,IExecuteLate,IExecuteFixed
    {
        private List<IExecute> _listIExecuteObjects;
        private List<IExecuteFixed> _listIExecuteFixedObjects;
        private List<IExecuteLate> _listIExecuteLateObjects;

        public Controllers()
        {
            _listIExecuteObjects = new List<IExecute>();
            _listIExecuteFixedObjects = new List<IExecuteFixed>();
            _listIExecuteLateObjects = new List<IExecuteLate>();
        }

        public void AddController(IController controller)
        {
            if(controller is IExecute execute)
            {
                _listIExecuteObjects.Add(execute);
            }
            if(controller is IExecuteFixed executeFixed)
            {
                _listIExecuteFixedObjects.Add(executeFixed);
            }
            if(controller is IExecuteLate executeLate)
            {
                _listIExecuteLateObjects.Add(executeLate);
            }
        }

        public void Execute()
        {
            foreach(IExecute execute in _listIExecuteObjects)
            {
                execute.Execute();
            }
        }
        public void LateExecute()
        {
            foreach(IExecuteLate execute in _listIExecuteLateObjects)
            {
                execute.LateExecute();
            }    
        }
        public void FixedExecute()
        {
            foreach(IExecuteFixed execute in _listIExecuteFixedObjects)
            {
                execute.FixedExecute();
            }      
        }
    }    
}

