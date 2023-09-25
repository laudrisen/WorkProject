using UnityEngine;
using TMPro;

public class playerController : MonoBehaviour
{
    [SerializeField] private FixedJoystick fixedJoystick;
    [SerializeField] private Animator animator;
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject bodyTransformLeft;
    [SerializeField] private GameObject bodyTransformRight;
    [SerializeField] private TextMeshProUGUI healthText;

    private bool lastMoveLeft = false; // Переменная для отслеживания последнего движения влево

    private void Update()
    {
        float horizontalInput = fixedJoystick.Horizontal;
        float verticalInput = fixedJoystick.Vertical;

        // Перемещаем игрока на основе входных данных от джойстика
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f).normalized;
        transform.Translate(movement * moveSpeed * Time.deltaTime);

        // Устанавливаем анимацию в зависимости от направления движения
        if (horizontalInput < 0)
        {
            bodyTransformLeft.SetActive(true);
            bodyTransformRight.SetActive(false);
            lastMoveLeft = true; // Запоминаем, что последнее движение было влево
        }
        else if (horizontalInput > 0)
        {
            bodyTransformLeft.SetActive(false);
            bodyTransformRight.SetActive(true);
            lastMoveLeft = false; // Запоминаем, что последнее движение было вправо
        }

        if (healthText.text == "0")
        {
            Destroy(gameObject);
        }
    }

    public bool IsFacingLeft()
    {
        return lastMoveLeft; // Возвращаем информацию о направлении поворота
    }
}



