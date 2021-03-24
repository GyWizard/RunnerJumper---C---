using UnityEngine;

namespace RunnerJumper
{
    internal sealed class GameController : MonoBehaviour
    {
        #region  SerializedFields

        [SerializeField] private Rigidbody2D _player;
        [SerializeField] private Transform _camera;
        [SerializeField] private float _jumpForce;
        [SerializeField] private float _runSpeed;

        #endregion
        

        private InputController _controller;
        private Movement _movement;
        private CameraMove _cameraMove;
        private InteractiveObject[] _listInteractiveObjects;

        void Awake()
        {
            _controller = new InputController(); // создаем менеджер Ввода
            _movement = new Movement(_runSpeed,_jumpForce,_player); // создаем менеджер Движения игрока
            _cameraMove = new CameraMove(_player.transform,_camera); //  создаем менеджер Движения камеры
            _listInteractiveObjects = FindObjectsOfType<InteractiveObject>(); // добавляем все интерактивные объекты в массив
        }


        void Update()
        {
            PlayerMovement(); // Перемещаем игрока
            InteractiveObjects(); // Взаимодействия с интерактивными объектами
        }

        void FixedUpdate() 
        {
            if(_controller.Action) //Если нажата кнопка действия совершаем прыжок
            {
                _movement.Jump();
                _controller.Action = false;
            }
        }

        void LateUpdate () 
        {
            _cameraMove.Move(); // обновляем камеру
        }

        void PlayerMovement() 
        {
            _movement.Run(); //выполняем бег с заданной скоростью
            _controller.CheckActionPressed(); // проверяем кнопку прыжка
        }

        void InteractiveObjects() 
        {
            foreach(InteractiveObject io in _listInteractiveObjects) // Пробегаем по интерактивным объектам
            {
                if(io is IFlay flay) 
                {

                    flay.Fly(); // Если есть интерфейс IFlay то летаем.
                }
            }
        }

    }   
}

