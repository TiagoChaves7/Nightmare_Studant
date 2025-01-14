using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tiro : MonoBehaviour
{
    // SFX Sounds
    private AudioSource tzum;

    public float speed;
    public float timeDestroy;

    public int Damage;
    public int resp;

    void Start()
    {
        timeDestroy = 1.0f;
        Destroy(gameObject, timeDestroy);
        Damage = 1;
        resp = 1;
    }

    // Initialize and play sound
    private void Awake()
    {
        tzum = GetComponent<AudioSource>();
        tzum.Play();
    }

    void Update()
    {
        // Move the projectile
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    // Handle collision with other objects
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
        {
            if (other.CompareTag("Sombra") || other.CompareTag("Parede"))
            {
                Sombra enemy = other.GetComponent<Sombra>();

                if (enemy != null)
                {
                    enemy.DamageEnemy(Damage);
                }
            }
            if (other.CompareTag("Livro"))
            {
                Livro dano = other.GetComponent<Livro>();
                if (dano != null)
                {
                    dano.DamageEnemy(Damage);
                }
            }
            Destroy(gameObject);
        }
    }
}
