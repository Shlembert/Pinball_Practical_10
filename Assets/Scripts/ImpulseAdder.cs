using UnityEngine;

public class ImpulseAdder : MonoBehaviour
{
    [SerializeField] private float impulseForce = 10f; // ������������� ���� ��������

    private void OnCollisionEnter(Collision collision)
    {
        // ���������, �������� �� ������������� ������ �������
        if (collision.gameObject.TryGetComponent(out Rigidbody ballRigidbody))
        {
            // ��������� ����������� �������� � ������ ������� �����������
            Vector3 normal = collision.GetContact(0).normal;
            Vector3 impulseDirection = Vector3.Reflect(collision.relativeVelocity, normal).normalized;

            // ��������� ������� � ������
            ballRigidbody.AddForce(impulseDirection * impulseForce, ForceMode.Impulse);
        }
    }
}
