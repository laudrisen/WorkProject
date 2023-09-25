using UnityEngine;
using UnityEngine.UI;

public class preventUIrotation : MonoBehaviour
{
    private Quaternion initialRotation; // Начальный поворот UI элемента

    private void Start()
    {
        initialRotation = transform.rotation;
    }

    private void LateUpdate()
    {
        // Заблокировать поворот UI элемента
        transform.rotation = initialRotation;
    }
}

