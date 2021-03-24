
using UnityEngine;
using static UnityEngine.Debug;

namespace RunnerJumper
{

    public class GoodBonus : InteractiveObject,ICollect,IDisplay
    {

        public void Collect() //  Выключаем объект после соприкосновения
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
            Display();
        }

        
    }    
}

