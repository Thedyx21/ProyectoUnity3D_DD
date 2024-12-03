using UnityEngine;

public class DestroyOnRoad : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Verifica si la colisión es con un objeto etiquetado como "Road"
        if (collision.gameObject.CompareTag("Road"))
        {
            // Asegúrate de que este script está en una instancia y no en el prefab original
            if (gameObject.scene.IsValid())
            {
                Destroy(gameObject, 6f); // Destruir después de 2 segundos
            }
            else
            {
                Debug.LogWarning("Intentando destruir el prefab original. Este script debe estar en instancias, no en el prefab.");
            }
        }
    }
}