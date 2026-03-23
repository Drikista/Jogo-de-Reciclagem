using UnityEngine;

public class Player_control : MonoBehaviour
{

    private Rigidbody2D _playerRigidbody2D;
    public float _player_vel; //setar a velocidade do player dentro da unity
    private Vector2 _playerDirection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _playerRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _playerDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        
    }

    void FixedUpdate()
    {
        _playerRigidbody2D.MovePosition(_playerRigidbody2D.position + _playerDirection * _player_vel * Time.deltaTime);
        
    }
}
