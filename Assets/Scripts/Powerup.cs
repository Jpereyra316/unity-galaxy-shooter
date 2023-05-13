using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3f;
    const float TOP_OF_SCREEN = 7f;
    const float BOTTOM_OF_SCREEN = -5f;

    public enum PowerUpType
    {
        TripleShot,
        Speed,
        Shield,

        LAST,
        FIRST = TripleShot
    };

    [SerializeField]
    private PowerUpType _powerupType;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(Random.Range(-8f, 8f), TOP_OF_SCREEN, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // Move down
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        // Move to the top of the screen if not dead at the bottom
        if (transform.position.y <= BOTTOM_OF_SCREEN)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                switch (_powerupType)
                {
                    case PowerUpType.TripleShot:
                        player.ActivateTripleShot();
                        break;

                    case PowerUpType.Speed:
                        player.ActivateSpeedPowerup();
                        break;

                    case PowerUpType.Shield:
                        player.ActivateShieldPowerup();
                        break;

                    default:
                        break;

                }
            }

            Destroy(this.gameObject);
        }
    }
}
