using UnityEngine;

public class Bullets : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 10f;
    Rigidbody2D myRigidbody;
    PlayerMovements player;
    float bulletFinalSpeed;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        player = FindFirstObjectByType<PlayerMovements>();
        bulletFinalSpeed = player.gameObject.transform.localScale.x * bulletSpeed;
    }

    void Update()
    {
        myRigidbody.linearVelocity = new Vector2(bulletFinalSpeed, 0f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject, 1f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }
}
