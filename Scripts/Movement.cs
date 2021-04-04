using UnityEngine;

public sealed class Movement // Описываем движения игрока
{

    private float _speed;
    private float _jumpForce;

    private Rigidbody2D _rigidbody;

    public float Speed {get => _speed; set {_speed = value;} }
    public float JumpForce {get => _jumpForce; set {_jumpForce = value;} }

    public Movement(float speed,float jumpForce, Rigidbody2D player) // конструктор
    {
        Speed = speed;
        JumpForce = jumpForce;
        _rigidbody = player;
    }
    public void Jump() // Прыжок вверх
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x,_jumpForce);
        _rigidbody.AddForce(new Vector2(0f,_jumpForce),ForceMode2D.Impulse);
    }
    public void Run() // Бег с постоянной скоростью
    {
        _rigidbody.velocity = new Vector2(_speed,_rigidbody.velocity.y);
    }

}
