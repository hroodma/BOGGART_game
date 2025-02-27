using JetBrains.Annotations;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Player player; // ������ �� ����� Player

    private Rigidbody2D rb; // ������ �� Rigidbody2D

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        player.Move(rb);
    }
}
