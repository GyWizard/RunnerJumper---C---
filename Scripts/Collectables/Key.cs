using UnityEngine;

namespace RunnerJumper
{
    public class Key : GoodBonus,IFlay
    {
        [SerializeField] private float _lengthFlay;
        private Vector2 _startPos;

        void Awake()
        {
            _startPos = transform.position;
        }
        public void Fly()
        {
            transform.localPosition = new Vector3(transform.localPosition.x, 
            Mathf.PingPong(Time.time, _lengthFlay)+_startPos.y,
            transform.localPosition.z);
        }
    }    
}

