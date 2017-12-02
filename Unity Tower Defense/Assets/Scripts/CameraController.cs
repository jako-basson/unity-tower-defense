using UnityEngine;

public class CameraController : MonoBehaviour
{
    private bool canMoveCamera = true;

    public float panSpeed = 30f;
    public float panBorderThickness = 10f;
    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 80f;


    // Update is called once per frame
    void Update()
    {
        // for testing only, stop camera movement
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            canMoveCamera = !canMoveCamera;
        }

        if (!canMoveCamera)
        {
            return;
        }

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {

            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        Vector3 position = transform.position;

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        position.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;

        // restrict positions 
        position.y = Mathf.Clamp(position.y, minY, maxY);
        position.x = Mathf.Clamp(transform.position.x, 20f, 50f);
        position.z = Mathf.Clamp(transform.position.z, -100f, 0f);

        transform.position = position;
    }
}

