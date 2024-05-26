using UnityEngine;

public class ImpulseAdder : MonoBehaviour
{
    [SerializeField] private float impulseForce = 10f; // Настраиваемая сила импульса

    private void OnCollisionEnter(Collision collision)
    {
        // Проверяем, является ли столкнувшийся объект шариком
        if (collision.gameObject.TryGetComponent(out Rigidbody ballRigidbody))
        {
            // Вычисляем направление импульса с учетом нормали поверхности
            Vector3 normal = collision.GetContact(0).normal;
            Vector3 impulseDirection = Vector3.Reflect(collision.relativeVelocity, normal).normalized;

            // Добавляем импульс к шарику
            ballRigidbody.AddForce(impulseDirection * impulseForce, ForceMode.Impulse);
        }
    }
}
