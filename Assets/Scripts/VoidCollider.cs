using UnityEngine;

public class VoidCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Objeto detectado en el trigger: " + other.gameObject.name);
        Destroy(other.gameObject); // Destruir inmediatamente
    }
}