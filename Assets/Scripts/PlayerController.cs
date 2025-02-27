using JetBrains.Annotations;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Player player; // —сылка на класс Player

    private Rigidbody2D rb; // —сылка на Rigidbody2D

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        player.Move(rb);
    }
}
