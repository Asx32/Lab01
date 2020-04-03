using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerBody;
    private float xRot = 0;

    // Start is called before the first frame update
    void Start()
    {
        //blokujemy kursor, żeby nie wyjeżdżał poza "okno"
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //pobieram położenie kursora myszy na scenie
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        //obróć ciało w poziomie
        playerBody.Rotate(Vector3.up *mouseX);
        //obróć kamerę w pionie
        //transform.Rotate(Vector3.right * mouseY); - ale to pozwoli na zbyt duże odchylenia
        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRot, 0, 0);
    }
}
