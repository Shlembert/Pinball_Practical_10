using UnityEngine;

[RequireComponent(typeof(ConfigurableJoint))]
[RequireComponent(typeof(Rigidbody))]
public class PistonController : MonoBehaviour
{
    [SerializeField] private KeyCode activationKey = KeyCode.Space; // Клавиша для активации поршня
    [SerializeField] private float maxPushDistance; // Максимальная дистанция, на которую поршень сжимается
    [SerializeField] private Rigidbody ballRigidbody; // Rigidbody шарика
    [SerializeField] private float maxPushForce; // Максимальная сила толчка
    [SerializeField] private float forceMultiplier; // Множитель силы толчка

    private float holdTime = 0f;
    private Vector3 initialLocalPosition;
    private ConfigurableJoint configurableJoint;
    private Rigidbody pistonRigidbody;
    private bool isTouchingBall = false; // Флаг для отслеживания контакта с шариком

    void Start()
    {
        initialLocalPosition = transform.localPosition;
        configurableJoint = GetComponent<ConfigurableJoint>();
        pistonRigidbody = GetComponent<Rigidbody>();
        pistonRigidbody.isKinematic = true; // Начинаем с кинематичного состояния
    }

    void Update()
    {
        if (Input.GetKeyDown(activationKey))
        {
            holdTime = 0f;
            pistonRigidbody.isKinematic = true; // Включаем кинематику при нажатии пробела
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
        pistonRigidbody.isKinematic = false; // Отключаем кинематику при отпускании пробела

        if (isTouchingBall)
        {
            ApplyPushForce();
        }
        else
        {
            Debug.Log("Releasing Piston: Ball is NOT touching");
        }

        // Сбрасываем флаг контакта с шариком после применения силы
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
