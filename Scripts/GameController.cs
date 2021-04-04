using UnityEngine;
using System;
namespace RunnerJumper
{
    internal sealed class GameController : MonoBehaviour
    {
        #region  SerializedFields

        [SerializeField] private Rigidbody2D _player;
        [SerializeField] private Transform _camera;
        [SerializeField] private float _jumpForce;
        [SerializeField] private float _runSpeed;
        [SerializeField] private AudioClip  _endAudio;
        [SerializeField] private AudioClip  _collectAudio;
        [SerializeField] private AudioSource _audioSource;

        #endregion
        
        private RestartManager restartManager = new RestartManager();
        private InputController _controller;
        private Movement _movement;
        private CameraMove _cameraMove;
        private InteractiveObject[] _listInteractiveObjects;
        private AudioManager _audioManager;

        void Awake()
        {

            CheckFields();

            _controller = new InputController(); // создаем менеджер Ввода
            _movement = new Movement(_runSpeed,_jumpForce,_player); // создаем менеджер Движения игрока
            _cameraMove = new CameraMove(_player.transform,_camera); //  создаем менеджер Движения камеры
            _listInteractiveObjects = FindObjectsOfType<InteractiveObject>(); // добавляем все интерактивные объекты в массив
            _audioManager = new AudioManager(_audioSource,_endAudio,_collectAudio);

            foreach(InteractiveObject io in _listInteractiveObjects) // Пробегаем по интерактивным объектам
            {
                if(io is GoodBonus goodBonus)
                {
                    goodBonus.StartPosition = goodBonus.gameObject.transform.localPosition;
                    goodBonus.Collect += _audioManager.PlayCollectAudio;
                }
                if(io is BadBonus badBonus)
                {
                    badBonus.Caught += DisplayScore;
                    badBonus.Caught += restartManager.Restart;
                    badBonus.Caught += _audioManager.PlayEndAudio;
                }
            }

            
        }

        void CheckFields()
        {
            if(!_player) { throw new Exception("Player is not signed");}
            if(!_camera) { throw new Exception("Camera is not signed");}
            if(!_endAudio) { throw new Exception("End sound is not signed");}
            if(!_collectAudio) { throw new Exception("Collect sound is not signed");}
            if(!_audioSource) { throw new Exception("Audio Source is not signed");}       
        }

        void DisplayScore()
        {
            Debug.Log("End of the game!");
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

        void WaitAndRestart()
        {
            restartManager.Restart();
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

