using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4f;

    private Player _player = null;
    private Animator _anim;
    private AudioSource _audioSource;

    void Start()
    {
        print("Enemy.cs: Start()");     //FOO

        GameManager gm = GameObject.Find("Game_Manager").GetComponent<GameManager>();
        print("Coop Mode = " + gm.getCoopMode());

        if (!gm.getCoopMode())
        {
            _player = GameObject.Find("Player").GetComponent<Player>();
            if (_player != null) print("Found Player");
        }
        else
        {
            if (_player == null)
            {
                _player = GameObject.Find("Player_1").GetComponent<Player>();
                if (_player != null) print("Found Player_1");
            }
            if (_player == null)
            {
                _player = GameObject.Find("Player_2").GetComponent<Player>();
                if (_player != null) print("Found Player_2");
            }
        }

        if (_player == null)
        {
            Debug.LogError("The Player is NULL");
        }
        _anim = GetComponent<Animator>();

        if (_anim == null)
        {
            Debug.LogError("Animator is NULL");
        }

        if (_audioSource == null)
        {
            Debug.LogWarning("Audio Source is NULL. Should have been set in Enemy Game Object");
            _audioSource = GetComponent<AudioSource>();
        }
    }

    void Update()
    {
        transform.Translate(_speed * Time.deltaTime * Vector3.down);
        if (transform.position.y < -4f)
        {
            float randomX = Random.Range(-8f, 8f);
            transform.position = new Vector3(randomX, 7f, 0);
        }
    }

    public AudioClip footsteps;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
            if (player != null)
            {
                player.Damage();
            }

            _anim.SetTrigger("OnEnemyDeath");
            _speed = 0;
            _audioSource.Play();
            Destroy(this.gameObject, 2.8f);
        }

        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);

            if (_player != null)
            {
                _player.AddScore(10);
            }

            _anim.SetTrigger("OnEnemyDeath");
            _speed = 0;
            _audioSource.Play();

            Destroy(GetComponent<Collider2D>());
            Destroy(this.gameObject, 2.8f);
        }
    }
}
