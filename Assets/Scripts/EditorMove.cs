using UnityEngine;
 
public class EditorMove : MonoBehaviour
{
    [SerializeField] float speed = 0.2f;
    [SerializeField] float sensitivity = 0.1f;
    [SerializeField] float scrollSpeed = 3.0f;
    [SerializeField] Transform topView;
    [SerializeField] Transform enemyBaseView;
    [SerializeField] Transform homeBaseView;
 
    private Vector3 initial_pos;
    private Quaternion initial_rot;

    private Vector3 curr;
    private Quaternion Rotation;
    private Quaternion Rotation_amount;

    private bool isOrthographic = false;
    


    private void Awake()
    {
        initial_pos = transform.position;
        initial_rot = transform.rotation;
        Camera.main.orthographicSize = 10;
    }
   
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0) 
            transform.position += scrollSpeed * new Vector3(0, -Input.GetAxis("Mouse ScrollWheel"), 0);

        Vector3 direction = Vector3.zero;

        // Camera Reset
        if (Input.GetKey(KeyCode.R))
            MoveTo(initial_pos, initial_rot);

        // Camera teleport
        if (topView != null && Input.GetKey(KeyCode.Alpha1))
            MoveTo(topView.position, topView.rotation);
        if (enemyBaseView != null && Input.GetKey(KeyCode.Alpha2))
            MoveTo(enemyBaseView.position, enemyBaseView.rotation);
        if (homeBaseView != null && Input.GetKey(KeyCode.Alpha3))
            MoveTo(homeBaseView.position, homeBaseView.rotation);

        // Camera movement
        if (Input.GetKey(KeyCode.W))
            direction += Vector3.forward * speed;
        if (Input.GetKey(KeyCode.A))
            direction -= Vector3.right * speed;
        if (Input.GetKey(KeyCode.S))
            direction -= Vector3.forward * speed;
        if (Input.GetKey(KeyCode.D))
            direction += Vector3.right * speed;
        if (Input.GetKey(KeyCode.E))
            direction += Vector3.up * speed;
        if (Input.GetKey(KeyCode.Q))
            direction -= Vector3.up * speed;
        transform.Translate(direction);
 
        // Mouse movement
        if (Input.GetMouseButton(1))
        {
            Quaternion Rotation = Rotation_amount;
            Vector3 dif = curr - new Vector3(Input.mousePosition.y, -Input.mousePosition.x);
            Rotation.eulerAngles += dif * sensitivity;
            transform.rotation = Rotation;
        } else {
			curr = new Vector3(Input.mousePosition.y, -Input.mousePosition.x);
            Rotation_amount = transform.rotation;
		}

        // Orthographic toggle
        if (Input.GetKeyDown(KeyCode.O) && isOrthographic)
        {
            Camera.main.orthographic = false;
            isOrthographic = false;
        } 
        else if (Input.GetKeyDown(KeyCode.O) && !isOrthographic)
        {
            Camera.main.orthographic = true;
            Camera.main.orthographicSize = 12;
            isOrthographic = true;
        }

    }

    private void MoveTo (Vector3 pos, Quaternion rot)
    {
        transform.position = pos;
        transform.rotation = rot;
    }
}