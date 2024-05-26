using UnityEngine;

[RequireComponent(typeof(ConfigurableJoint))]
[RequireComponent(typeof(Rigidbody))]
public class PistonController : MonoBehaviour
{
    [SerializeField] private KeyCode activationKey = KeyCode.Space; // ������� ��� ��������� ������
    [SerializeField] private float maxPushDistance; // ������������ ���������, �� ������� ������� ���������
    [SerializeField] private Rigidbody ballRigidbody; // Rigidbody ������
    [SerializeField] private float maxPushForce; // ������������ ���� ������
    [SerializeField] private float forceMultiplier; // ��������� ���� ������

    private float holdTime = 0f;
    private Vector3 initialLocalPosition;
    private ConfigurableJoint configurableJoint;
    private Rigidbody pistonRigidbody;
    private bool isTouchingBall = false; // ���� ��� ������������ �������� � �������

    void Start()
    {
        initialLocalPosition = transform.localPosition;
        configurableJoint = GetComponent<ConfigurableJoint>();
        pistonRigidbody = GetComponent<Rigidbody>();
        pistonRigidbody.isKinematic = true; // �������� � ������������� ���������
    }

    void Update()
    {
        if (Input.GetKeyDown(activationKey))
        {
            holdTime = 0f;
            pistonRigidbody.isKinematic = true; // �������� ���������� ��� ������� �������
        }

        if (Input.GetKey(activationKey))
        {
            holdTime += Time.deltaTime;
            CompressPiston();
        }

        if (Input.GetKeyUp(activationKey))
        {
            ReleasePiston();
        }
    }

    void CompressPiston()
    {
        float compressDistance = Mathf.Clamp(holdTime, 0, maxPushDistance);
        Vector3 targetPosition = initialLocalPosition - new Vector3(0, 0, compressDistance);
        transform.localPosition = targetPosition;
    }

    void ReleasePiston()
    {
        pistonRigidbody.isKinematic = false; // ��������� ���������� ��� ���������� �������

        if (isTouchingBall)
        {
            ApplyPushForce();
        }
        else
        {
            Debug.Log("Releasing Piston: Ball is NOT touching");
        }

        // ���������� ���� �������� � ������� ����� ���������� ����
        isTouchingBall = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Rigidbody rb) && rb == ballRigidbody)
        {
            isTouchingBall = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Rigidbody>(out Rigidbody rb) && rb == ballRigidbody)
        {
            isTouchingBall = false;
        }
    }

    void ApplyPushForce()
    {
        //float pushForce = maxPushForce * forceMultiplier;
        //ballRigidbody.AddForce(transform.forward * pushForce, ForceMode.Impulse);
    }
}
