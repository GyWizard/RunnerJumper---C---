using UnityEngine;
using System;
using UnityEngine.UI;
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
        private Radar _radar;

        [SerializeField] Camera miniCamera;

        void Awake()
        {


            Time.timeScale=1f;

            _reference = new Reference();

            CheckFields();

            _radar = FindObjectOfType<Radar>();

            Radar.RegisterRadarObject(_reference.Player,_reference.RadarGreen);

            PhotoController _photoController = new PhotoController(miniCamera);

            _movement = new Movement(_runSpeed,_jumpForce, _reference.Player.GetComponent<Rigidbody2D>() );
            _inputController = new InputController(_movement); // создаем менеджер Ввода
            _cameraMove = new CameraController(_reference.Player.transform, _reference.Camera.transform); //  создаем менеджер Движения камеры
            _listInteractiveObjects = FindObjectsOfType<InteractiveObject>(); // добавляем все интерактивные объекты в массив
            _audioManager = new AudioManager(GetComponent<AudioSource>() ,_reference.EndAudio,_reference.CollectAudio);
            
            

            _controllers = new Controllers();


            _controllers.AddController(_inputController);
            _controllers.AddController(_cameraMove);
            _controllers.AddController(new RadarController(_radar,Camera.main.transform,10f));
            //_controllers.AddController(new PhotoController(miniCamera));

            foreach(InteractiveObject io in _listInteractiveObjects) // Пробегаем по интерактивным объектам
            {
                if(io is IController controller)
                {
                    _controllers.AddController(controller);
                }

                if(io is GoodBonus goodBonus)
                {
                    goodBonus.StartPosition = goodBonus.gameObject.transform.localPosition;
                    goodBonus.Collect += _audioManager.PlayCollectAudio;
                    Radar.RegisterRadarObject(io.gameObject, _reference.RadarYellow);
                }
                if(io is BadBonus badBonus)
                {
                    badBonus.Caught += DisplayScore;
                    badBonus.Caught += EndGame;
                    badBonus.Caught += _audioManager.PlayEndAudio;
                    badBonus.Caught += Radar.ClearDots;
                    Radar.RegisterRadarObject(io.gameObject,_reference.RadarRed);
                }
                if(io is Exit exit)
                {
                    exit.EnterExit += WinGame;
                    exit.EnterExit += Radar.ClearDots;
                }

                
            }

        }

        void CheckFields()
        {
            if(!_reference.Player) { throw new Exception("Player is not signed");}  
            if(_jumpForce==0) { throw new Exception("Jump Force is 0");}   
            if(_runSpeed==0) { throw new Exception("Run Speed is 0");}   
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

      
        void LateUpdate () 
        {
            _controllers.LateExecute();
        }

        void EndGame()
        {
            Time.timeScale=0;
            _reference.RestartButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener( restartManager.Restart );
        }

        void WinGame()
        {
            Instantiate(_reference.WinningText,_reference.Canvas.transform);
            EndGame();
        }



    }   
}

