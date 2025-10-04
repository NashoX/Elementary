using UnityEngine;

public class MovimientoFPS : MonoBehaviour
{
    [Header("Velocidades")]
    public float velocidadMovimiento = 5f;
    public float sensibilidadMouse = 2f;
    public float gravedad = -9.81f; // puedes ajustar la fuerza de caída

    [Header("Referencias")]
    public CharacterController controller;
    public Transform camara;

    private float rotacionX = 0f;
    private float velocidadY = 0f; // velocidad vertical (gravedad)

    void Start()
    {
        // Bloquea el cursor en el centro de la pantalla
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        MoverJugador();
        MoverCamara();
    }

    void MoverJugador()
    {
        float movX = Input.GetAxis("Horizontal");  // A/D o flechas
        float movZ = Input.GetAxis("Vertical");    // W/S o flechas

        // Movimiento relativo a la rotación del jugador
        Vector3 direccion = transform.right * movX + transform.forward * movZ;

        // Aplicar gravedad
        if (controller.isGrounded)
        {
            velocidadY = 0f; // resetea velocidad al tocar el suelo
        }
        else
        {
            velocidadY += gravedad * Time.deltaTime;
        }

        direccion.y = velocidadY;

        // Mover al jugador
        controller.Move(direccion * velocidadMovimiento * Time.deltaTime);
    }

    void MoverCamara()
    {
        float ratonX = Input.GetAxis("Mouse X") * sensibilidadMouse;
        float ratonY = Input.GetAxis("Mouse Y") * sensibilidadMouse;

        rotacionX -= ratonY;
        rotacionX = Mathf.Clamp(rotacionX, -90f, 90f);

        camara.localRotation = Quaternion.Euler(rotacionX, 0f, 0f);
        transform.Rotate(Vector3.up * ratonX);
    }
}
