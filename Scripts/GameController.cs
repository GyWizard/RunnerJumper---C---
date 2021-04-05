using UnityEngine;
using System;
using System.Collections.Generic;
namespace RunnerJumper
{
    internal sealed class GameController : MonoBehaviour
    {
        #region  SerializedFields

        [SerializeField] private float _jumpForce;
        [SerializeField] private float _runSpeed;
 

        #endregion
        
        private RestartManager restartManager = new RestartManager();
        private InputController _inputController;
        private Movement _movement;
        private CameraController _cameraMove;
        private InteractiveObject[] _listInteractiveObjects;

        private Controllers _controllers;

        private Reference _reference;

        private AudioManager _audioManager;

        void Awake()
        {
            Time.timeScale=1f;

            _reference = new Reference();

            CheckFields();

            
            _movement = new Movement(_runSpeed,_jumpForce, _reference.Player.GetComponent<Rigidbody2D>() );
            _inputController = new InputController(_movement); // создаем менеджер Ввода
            _cameraMove = new CameraController(_reference.Player.transform, _reference.Camera.transform); //  создаем менеджер Движения камеры
            _listInteractiveObjects = FindObjectsOfType<InteractiveObject>(); // добавляем все интерактивные объекты в массив
            _audioManager = new AudioManager(GetComponent<AudioSource>() ,_reference.EndAudio,_reference.CollectAudio);
            _controllers = new Controllers();

            _controllers.AddController(_inputController);
            _controllers.AddController(_cameraMove);

            foreach(InteractiveObject io in _listInteractiveObjects) // Пробегаем по интерактивным объектам
            {
                if(io is IController controller)
                {
                    _controllers.AddController(controller);
                }
            }

            foreach(InteractiveObject io in _listInteractiveObjects) // Пробегаем по интерактивным объектам
            {
                if(io is GoodBonus goodBonus)
                {
                    goodBonus.StartPosition = goodBonus.gameObject.transform.localPosition;
                    goodBonus.Collect += _audioManager.PlayCollectAudio;;
                }
                if(io is BadBonus badBonus)
                {
                    badBonus.Caught += DisplayScore;
                    badBonus.Caught += EndGame;
                    badBonus.Caught += _audioManager.PlayEndAudio;
                }
            }



            
        }

        void CheckFields()
        {
            if(!_reference.Player) { throw new Exception("Player is not signed");}
            // if(!_endAudio) { throw new Exception("End sound is not signed");}
            // if(!_collectAudio) { throw new Exception("Collect sound is not signed");}
            // if(!_audioSource) { throw new Exception("Audio Source is not signed");}       
        }

        void DisplayScore()
        {
            Debug.Log("End of the game!");
        }

        void Update()
        {
            _controllers.Execute();
        }

        void FixedUpdate() 
        {
            _controllers.FixedExecute();
        }

        void EndGame()
        {
            Time.timeScale=0;
            _reference.RestartButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener( restartManager.Restart );
        }

        void LateUpdate () 
        {
            _controllers.LateExecute();
        }

        // void InteractiveObjects() 
        // {
        //     foreach(InteractiveObject io in _listInteractiveObjects) // Пробегаем по интерактивным объектам
        //     {
        //         if(io is IExecute ex) 
        //         {
        //             ex.Execute();
        //         }
        //     }
        // }

    }   
}

