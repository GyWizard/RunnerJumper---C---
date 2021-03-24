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

}