using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RunnerJumper
{
    public sealed class Radar : MonoBehaviour,IExecute
    {
        private Transform _playerPos; // Позиция главного героя
        private readonly float _mapScale = 10;
        public static List<RadarObject> RadObjects = new List<RadarObject>();


        public void SetPlayer(Transform playerPos)
        {
            _playerPos = playerPos;
        }

        public static void RegisterRadarObject(GameObject o, Image i)
        {
            Image image = Instantiate(i);
            image.name = o.name;
            RadObjects.Add(new RadarObject { Owner = o, Icon = image });
        }
        
        public static void RemoveRadarObject(GameObject o)
        {
            List<RadarObject> newList = new List<RadarObject>();
            foreach (RadarObject t in RadObjects)
            {
                if (t.Owner == o)
                {
                Destroy(t.Icon);
                continue;
                }
                newList.Add(t);
            }
            RadObjects.RemoveRange(0, RadObjects.Count);
            RadObjects.AddRange(newList);
        }
        
        private void DrawRadarDots() // Синхронизирует значки на миникарте с реальными объектами
        {
            foreach (RadarObject radObject in RadObjects)
            {
                Vector3 radarPos = (radObject.Owner.transform.position -
                                    _playerPos.position) * _mapScale;
                float distToObject = Vector3.Distance(_playerPos.position,
                                        radObject.Owner.transform.position) * _mapScale;

                radObject.Icon.transform.SetParent(transform);
                radObject.Icon.transform.position = new Vector3(radarPos.x,
                                                    radarPos.y, 0) + transform.position;
            }
        }

        public static void ClearDots()
        {
            RadObjects.Clear();
        }
        
        public void Execute()
        {
            if (Time.frameCount % 2 == 0)
            {
                DrawRadarDots();
            }
        }
    }
    
    public sealed class RadarObject
    {
        public Image Icon;
        public GameObject Owner;
    }

}

  

