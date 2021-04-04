
using UnityEngine;
using System;
using static UnityEngine.Debug;

namespace RunnerJumper
{

    public class GoodBonus : InteractiveObject,IDisplay
    {
        protected Vector2 _startPos;
        
        public Vector2 StartPosition{set {_startPos = value;} }
        public Action Collect;

        public GoodBonus()
        {
            Collect += Deactivate;
            Collect += Display;
        }

        public void Deactivate() //  Выключаем объект после соприкосновения
        {
            gameObject.SetActive(false);
        }
        public void Display() //  Выводим имя объекта в консоль
        {
            Log($"Collected! {this.gameObject.name}");
        }

        protected override void Interact()
        {
            Collect();
        }


        
    }    
}

