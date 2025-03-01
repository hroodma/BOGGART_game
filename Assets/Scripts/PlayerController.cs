using JetBrains.Annotations;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Player player; // Ссылка на класс Player

    private Rigidbody2D rb; // Ссылка на Rigidbody2D

    string controlMode;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        controlMode = GameSettings.ControlMode;
    }

    void Update()
    {
        switch (controlMode)
        {
            case "keyboard":
                player.MoveKeyboard(rb);
                break;

            case "joystick":
                Debug.Log("Игра запущена с управлением: джойстик");
                // Настройка управления джойстиком
                break;

            case "gyroscope":
                Debug.Log("Игра запущена с управлением: гироскоп");
                // Настройка управления гироскопом
                break;

            default:
                Debug.Log("Режим управления не выбран, используется клавиатура");
                break;
        }
    }
}
