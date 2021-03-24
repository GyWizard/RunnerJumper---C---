using UnityEngine;

namespace RunnerJumper
{
    internal sealed class GameStart : MonoBehaviour
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
            _controller = new InputController();
            _movement = new Movement(_runSpeed,_jumpForce,_player);
            _cameraMove = new CameraMove(_player.transform,_camera);
            _listInteractiveObjects = FindObjectsOfType<InteractiveObject>();
        }


        void Update()
        {
            PlayerMovement();
            InteractiveObjects();
        }

        void FixedUpdate()
        {
            if(_controller.Action)
            {
                _movement.Jump();
                _controller.Action = false;
            }
        }

        void LateUpdate ()
        {
            _cameraMove.Move();
        }

        void PlayerMovement()
        {
            _movement.Run();
            _controller.CheckActionPressed();    
        }

        void InteractiveObjects()
        {
            foreach(InteractiveObject io in _listInteractiveObjects)
            {
                if(io is IFlay flay)
                {
                    flay.Fly();
                }
            }
        }

    }   
}

