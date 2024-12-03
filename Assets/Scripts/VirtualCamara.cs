using UnityEngine;
using Cinemachine;

public class VirtualCamara : MonoBehaviour
{
    // Referencia a la Virtual Camera de Cinemachine
    public CinemachineVirtualCamera virtualCamera;

    // Referencia al objetivo que la cámara seguirá
    public Transform target;

    // Configuraciones de la cámara
    [Header("Camera Settings")]
    public float followSpeed = 5f;
    public float lookAheadDistance = 3f;

    void Start()
    {
        // Verificación de seguridad
        if (target == null)
        {
            Debug.LogError("No se ha asignado un objetivo a la cámara virtual");
            return;
        }

        // Configurar el seguimiento de la cámara
        if (virtualCamera != null)
        {
            // Establecer el objetivo a seguir
            virtualCamera.Follow = target;

            // Establecer el punto de mira
            virtualCamera.LookAt = target;

            // Configurar parámetros de Cinemachine
            var transposer = virtualCamera.GetCinemachineComponent<CinemachineTransposer>();
            if (transposer != null)
            {
                // Ajustar offset de la cámara
                transposer.m_FollowOffset = new Vector3(0, 3, -2); // Más cerca (-2 en Z) y más alto (3 en Y)

                // Suavizado del movimiento
                transposer.m_XDamping = followSpeed;
                transposer.m_YDamping = followSpeed;
                transposer.m_ZDamping = followSpeed;
            }

            // Configuración de Framing
            var composer = virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
            if (composer != null)
            {
                // Ajustes de encuadre y suavizado
                composer.m_SoftZoneWidth = 0.5f;
                composer.m_SoftZoneHeight = 0.5f;
                composer.m_DeadZoneWidth = 0.3f;
                composer.m_DeadZoneHeight = 0.3f;
            }
        }
    }

    // Método opcional para cambiar dinámicamente el objetivo
    public void SetTarget(Transform newTarget)
    {
        if (virtualCamera != null)
        {
            virtualCamera.Follow = newTarget;
            virtualCamera.LookAt = newTarget;
        }
    }

    // Método para ajustar la distancia de la cámara
    public void SetCameraOffset(Vector3 offset)
    {
        var transposer = virtualCamera.GetCinemachineComponent<CinemachineTransposer>();
        if (transposer != null)
        {
            transposer.m_FollowOffset = offset;
        }
    }
}