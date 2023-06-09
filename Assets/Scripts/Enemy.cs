﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4f;
    const float TOP_OF_SCREEN = 7f;
    const float BOTTOM_OF_SCREEN = -5f;

    private Player _player;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(Random.Range(-8f, 8f), TOP_OF_SCREEN, 0);

        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if ( _player == null )
        {
            Debug.LogError("The Player is null for " + this.ToString() + "!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Move down
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        // Move to the top of the screen if not dead at the bottom
        if (transform.position.y <= BOTTOM_OF_SCREEN) {
            transform.position = new Vector3(Random.Range(-8f, 8f), TOP_OF_SCREEN, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);

            _player.IncrementScore(10);
            Destroy(this.gameObject);
        } else if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.Damage();
            }

            Destroy(this.gameObject);
        }
    }
}
