using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerJumper
{
    public sealed class Reference
    {
        private GameObject _player;
        private Camera _mainCamera;
        private GameObject _endGame;
        private Canvas _canvas; 
        private AudioClip  _endAudio;
        private AudioClip  _collectAudio;
        private AudioSource _audioSource;

        private GameObject _restartButton;

        public Canvas Canvas
        {
            get
            {
                if (_canvas == null)
                {
                    _canvas = Object.FindObjectOfType<Canvas>();
                }
                return _canvas;
            }
        }
        public Camera Camera
        {
            get
            {
                if (_mainCamera == null)
                {
                    _mainCamera = Camera.main;
                }
                return _mainCamera;
            }
        }

        public  GameObject Player
        {
            get
            {
                if (_player == null)
                {
                    var gameObject = Resources.Load<GameObject>("Prefab/Player");
                    _player = Object.Instantiate(gameObject);
                }
                return _player;
            }
        } 


        public AudioClip EndAudio
        {
            get
            {
                if (_endAudio == null)
                {
                    _endAudio = Resources.Load<AudioClip>("Audio/EndAudio");
                }
                return _endAudio;
            }
        } 

        public AudioClip CollectAudio
        {
            get
            {
                if (_collectAudio == null)
                {
                    _collectAudio = Resources.Load<AudioClip>("Audio/CollectAudio");
                }
                return _collectAudio;
            }
        } 

        public GameObject RestartButton
        {
            get
            {
                if (_restartButton == null)
                {
                    var gameObject = Resources.Load<GameObject>("UI/RestartButton");
                    _restartButton = Object.Instantiate(gameObject, Canvas.transform);
                }
                
                return _restartButton;
            }
        }

    }

}

