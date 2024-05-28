using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Plunger : MonoBehaviour
{
    [SerializeField] private float maxPower = 10f;
    [SerializeField] private float powerCountPerTick = 1f;
    public Animator plungerAnim;  

    private float power;
    private Rigidbody ballRb;
    private ContactPoint contact;
    private bool ballReady;

    private void Update()
    {
        if (ballReady && Input.GetKey(KeyCode.Space))
        {
            if (power <= maxPower)
            {
                power += powerCountPerTick * Time.deltaTime;
            }
            plungerAnim.SetBool("activate", true);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (ballRb != null)
            {
                ballRb.AddForce(-1 * power * contact.normal, ForceMode.Impulse);
            }
            plungerAnim.SetBool("activate", false);
            power = 0f;
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        ballReady = true;
        contact = col.contacts[0];
        ballRb = contact.otherCollider.attachedRigidbody;
    }

    private void OnCollisionExit(Collision col)
    {
        ballReady = false;
        ballRb = null;
    }
}
