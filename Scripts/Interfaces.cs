namespace  RunnerJumper
{ 
    interface IFlay // Летать туда сюда
    {
        void Fly();
    }

    interface ICollect // Поднятие объекта
    {
        void Collect();
    }

    interface IDamage // Нанесения урона
    {
        void Damage();
    }

    interface IDisplay //  Отображения
    {
        void Display();
    }
    interface IInteract // Взаимодействие
    {
        void Interact();
    }

    interface IExecute : IController
    {
        void Execute();
    }
     interface IExecuteFixed : IController
    {
        void FixedExecute();
    }
    interface IExecuteLate : IController
    {
        void LateExecute();
    }

    public interface IController
    {

    }

}