using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] UnitCanvasController uCC = null;
    [SerializeField] Transform cameraChild = null;

    [SerializeField] float zoomingSpeed = 1f;
    [SerializeField] float movingSpeed = 1f;
    [SerializeField] float mouseSensitivityH = 1f;
    [SerializeField] float mouseSensitivityV = 1f;

    private float yaw = 0f;
    private float pitch = 0f;

    // Start is called before the first frame update
    private void Start()
    {
        yaw = transform.eulerAngles.y;
        pitch = transform.eulerAngles.x;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hitInfo))
            {
                UnitUpgrade currentUnit = hitInfo.transform.gameObject.GetComponent<UnitUpgrade>();

                if(currentUnit)
                {
                    uCC.GetCurrentUnit(currentUnit);
                    uCC.EnableUI(hitInfo.transform.position);
                }
            }
        }

        cameraChild.transform.rotation = Quaternion.Euler(new Vector3(-transform.rotation.eulerAngles.x, 0f, 0f));

        if (Input.GetMouseButton(1))
        {
            yaw += mouseSensitivityH * Input.GetAxis("Mouse X");
            pitch -= mouseSensitivityV * Input.GetAxis("Mouse Y");

            transform.eulerAngles = new Vector3(pitch, yaw, 0f);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(cameraChild.transform.forward * movingSpeed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-cameraChild.transform.forward * movingSpeed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-cameraChild.transform.right * movingSpeed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(cameraChild.transform.right * movingSpeed);
        }
        
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            transform.Translate(Vector3.forward * Input.GetAxis("Mouse ScrollWheel") * zoomingSpeed);
        }
    }
}
