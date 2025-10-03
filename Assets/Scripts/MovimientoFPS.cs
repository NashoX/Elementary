using UnityEngine;

public class MovimientoFPS : MonoBehaviour
{
    [Header("Velocidades")]
    public float velocidadMovimiento = 5f;
    public float sensibilidadMouse = 2f;

    [Header("Referencias")]
    public CharacterController controller;
    public Transform camara;

    private float rotacionX = 0f;

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

        Vector3 direccion = transform.right * movX + transform.forward * movZ;
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
