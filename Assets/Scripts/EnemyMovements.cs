using UnityEngine;

public class EnemyMovements : MonoBehaviour
{
   [SerializeField] float moveSpeed = 1f;
   Rigidbody2D myRigidbody2d;

    void Start()
    {
        myRigidbody2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        myRigidbody2d.linearVelocity = new Vector2(moveSpeed, 0);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        moveSpeed = -moveSpeed;
        FlipEnemyCharacter();
    }

    void FlipEnemyCharacter()
    {
        transform.localScale = new Vector2(-Mathf.Sign(myRigidbody2d.linearVelocity.x), 1f);
    }
}
