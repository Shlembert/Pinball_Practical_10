using UnityEngine;

public class FlipperController : MonoBehaviour
{
    [SerializeField] private HingeJoint leftFlipperHinge;
    [SerializeField] private HingeJoint rightFlipperHinge;
    [SerializeField] private float leftFlipperTargetPosition = 60f;
    [SerializeField] private float rightFlipperTargetPosition = -60f;
    [SerializeField] private float returnPosition = 0f;

    void Update()
    {
        // Обновляем Target Position для левого флиппера
        if (Input.GetKey(KeyCode.LeftShift))
        {
            JointSpring leftSpring = leftFlipperHinge.spring;
            leftSpring.targetPosition = leftFlipperTargetPosition;
            leftFlipperHinge.spring = leftSpring;
        }
        else
        {
            JointSpring leftSpring = leftFlipperHinge.spring;
            leftSpring.targetPosition = returnPosition;
            leftFlipperHinge.spring = leftSpring;
        }

        // Обновляем Target Position для правого флиппера
        if (Input.GetKey(KeyCode.RightShift))
        {
            JointSpring rightSpring = rightFlipperHinge.spring;
            rightSpring.targetPosition = rightFlipperTargetPosition;
            rightFlipperHinge.spring = rightSpring;
        }
        else
        {
            JointSpring rightSpring = rightFlipperHinge.spring;
            rightSpring.targetPosition = returnPosition;
            rightFlipperHinge.spring = rightSpring;
        }
    }
}
