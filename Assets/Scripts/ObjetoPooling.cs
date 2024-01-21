using UnityEngine;

public class ObjetoPooling : MonoBehaviour
{
    public int contadorMaximo = 3;
    public int contadorActual;
    public AudioSource audioSource;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verificar si el objeto ha colisionado con el jugador
        if (other.CompareTag("Player"))
        {
            audioSource.Play();
            ControlPooling control = other.gameObject.GetComponent<ControlPooling>();
            control.collectedItem();
            // Obtener el componente ObjetoPooling del objeto recolectable
            ObjetoPooling objetoPooling = GetComponent<ObjetoPooling>();

            // Verificar si el componente existe (por seguridad)
            if (objetoPooling != null)
            {
                Debug.Log("Objeto recolectado por el jugador.");
                // Llamar al método Recolectar del objeto recolectable
                objetoPooling.Recolectar();
            }
        }
    }

    public void Recolectar()
    {
        // Devolver al pool (desactivar objeto)
        Destroy(gameObject);
    }
}