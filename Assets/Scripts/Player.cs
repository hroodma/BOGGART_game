using UnityEngine;

public class Player : MonoBehaviour
{

    int _hp;
    int _maxHp = 3;
    int _score;
    public float speed;
    float _maxSpeed = 2.5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Health") && _hp < _maxHp)
        {
            _hp++;
        }
        else if (other.CompareTag("Key"))
        {
            _score++;
        }
        else if (other.CompareTag("BoostSpeed") && speed < _maxSpeed)
        {
            speed += 2f;
        }
    }
}
