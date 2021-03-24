
using UnityEngine;

namespace  RunnerJumper
{
public abstract class InteractiveObject : MonoBehaviour
{
    protected abstract void Interact();

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
           Interact(); 
        }
    }

}

}

