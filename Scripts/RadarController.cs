using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerJumper
{
    public class RadarController : IExecuteLate
    {
        private Radar _radar;
        private Transform _playerPos;
        private readonly float _mapScale = 10;
        public RadarController(Radar radar, Transform player,float mapScale)
        {
            _radar = radar;
            _playerPos = player;
            _mapScale = mapScale;
        }
        private void DrawRadarDots() // Синхронизирует значки на миникарте с реальными объектами
        {
            foreach (RadarObject radObject in Radar.RadObjects)
            {
                Vector3 radarPos = (radObject.Owner.transform.position -
                                    _playerPos.position) * _mapScale;
                float distToObject = Vector3.Distance(_playerPos.position,
                                        radObject.Owner.transform.position) * _mapScale;

                radObject.Icon.transform.SetParent(_radar.transform);
                radObject.Icon.transform.position = new Vector3(radarPos.x,
                                                    radarPos.y, 0) + _radar.transform.position;
            }
        }

        public void LateExecute()
        {
            if (Time.frameCount % 2 == 0)
            {
                DrawRadarDots();
            }
        }
    }
}


