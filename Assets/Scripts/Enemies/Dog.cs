using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    [SerializeField] public Sprite dogDie;

    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.TryGetComponent(out Bomb bomb))
        {
            _animator.enabled = false;
            _spriteRenderer.sprite = dogDie;
            Destroy(gameObject, 2f);
        }
    }
}
