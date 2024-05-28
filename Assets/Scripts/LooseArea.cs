using UnityEngine;

public class LooseArea : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private TargetSet targetSet;

    void OnTriggerEnter(Collider col)
    {
        col.transform.position = spawnPoint.position;
        targetSet.ResetAllTargets();
    }
}
