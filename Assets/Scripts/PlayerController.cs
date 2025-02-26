using JetBrains.Annotations;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Player player;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveX, moveY) * player.speed;

        rb.linearVelocity = movement;
    }
}
