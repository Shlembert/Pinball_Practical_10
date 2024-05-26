using UnityEngine;

public class BallReturn : MonoBehaviour
{
    [SerializeField] private Transform ballTransform; // ������ �� ��������� ������
    private Vector3 startPosition;

    void Start()
    {
        startPosition = ballTransform.position; // �������� ��������� ������� ������
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            ReturnBallToStart();
        }
    }

    void ReturnBallToStart()
    {
        ballTransform.position = startPosition;
        Rigidbody ballRigidbody = ballTransform.GetComponent<Rigidbody>();
        if (ballRigidbody != null)
        {
            ballRigidbody.velocity = Vector3.zero;
            ballRigidbody.angularVelocity = Vector3.zero;
        }
    }
}
