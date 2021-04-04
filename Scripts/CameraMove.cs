using UnityEngine;

namespace RunnerJumper
{

    public sealed class CameraMove
    {
            private Transform _player;
            private Transform _camera;
            private float _offsetX;

            public CameraMove(Transform player,Transform camera)
            {
                _player = player;
                _camera = camera;
                _offsetX = camera.transform.position.x - _player.transform.position.x;    //  задаем отступление как в начале сцены
            }
            public void Move()
            {
                _camera.transform.position = new Vector3(_player.transform.position.x + _offsetX,0f,_camera.transform.position.z);  //  двигаем за игроком с заданным отступлением  
            }


    }
    
}
