using UnityEngine;

public class Hall : MonoBehaviour
{
    [SerializeField] private string _holeTag;

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();

        if (rb != null && other.CompareTag(_holeTag))
        {
            rb.isKinematic = true;
        }
    }
}