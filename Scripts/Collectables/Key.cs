using UnityEngine;

namespace RunnerJumper
{
    public sealed class Key : GoodBonus,IFlay // класс ключа
    {
        [SerializeField] private float _lengthFlay;
        private Vector2 _startPos;

        void Awake()
        {
            _startPos = transform.position; // начальная позиция для смещения
        }
        public void Fly() // парим в воздухе 
        {
            transform.localPosition = new Vector3(transform.localPosition.x, 
            Mathf.PingPong(Time.time, _lengthFlay)+_startPos.y,
            transform.localPosition.z);
        }
    }    
}

