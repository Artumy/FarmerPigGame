using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] public float speed = 0f;
    [SerializeField] public Bomb bomb;
    [SerializeField] public Joystick joystick;
    [SerializeField] public List<Sprite> sprites = new List<Sprite>();
    [SerializeField] public GameObject lose;

    private Rigidbody2D _rb;
    private Vector2 _moveVelocity;
    private SpriteRenderer _spriteRenderer;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        Vector2 moveInput = new Vector2(joystick.Horizontal, joystick.Vertical);
        Debug.Log(moveInput);
        if (moveInput.x > 0 && moveInput.x > Mathf.Abs(moveInput.y)) _spriteRenderer.sprite = sprites[0];
        else if (moveInput.x < 0 && Mathf.Abs(moveInput.x) > Mathf.Abs(moveInput.y)) _spriteRenderer.sprite = sprites[1];
        else if (moveInput.y > 0 && moveInput.y > Mathf.Abs(moveInput.x)) _spriteRenderer.sprite = sprites[3];
        else _spriteRenderer.sprite = sprites[2];
        _moveVelocity = moveInput * speed;
    }

    void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _moveVelocity * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.TryGetComponent(out Enemy enemy))
        {
            Destroy(gameObject, 0.5f);
            lose.SetActive(true);
        }
    }

}
