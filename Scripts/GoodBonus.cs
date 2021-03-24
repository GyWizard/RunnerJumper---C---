
using UnityEngine;
using static UnityEngine.Debug;

namespace RunnerJumper
{

    public class GoodBonus : InteractiveObject,IFlay,ICollect,IDisplay
    {
        [SerializeField] private float _lengthFlay;
        private Vector2 _startPos;

        void Awake()
        {
            _startPos = transform.position;
        }
        public virtual void Fly()
        {
                transform.localPosition = new Vector3(transform.localPosition.x, 
                Mathf.PingPong(Time.time, _lengthFlay)+_startPos.y,
                transform.localPosition.z);
        }

        public void Collect()
        {
            gameObject.SetActive(false);
        }
        public void Display()
        {
            Log($"Collected! {this.gameObject.name}");
        }

        protected override void Interact()
        {
            Collect();
            Display();
        }

        
    }    
}

