using UnityEngine;
 
public class EditorMove : MonoBehaviour
{
    [SerializeField] float speed = 0.2f;
    [SerializeField] float sensitivity = 0.1f;
    [SerializeField] float scrollSpeed = 3.0f;
 
    private Vector3 initial_pos;
    private Quaternion initial_rot;

    private Camera camera;
    private Vector3 curr;
    private Quaternion Rotation;
    private Quaternion Rotation_amount;
    
    


    private void Awake()
    {
        initial_pos = transform.position;
        initial_rot = transform.rotation;
        camera = GetComponent<Camera>();
    }
   
    void FixedUpdate()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0) 
            transform.position += scrollSpeed * new Vector3(0, -Input.GetAxis("Mouse ScrollWheel"), 0);

        Vector3 direction = Vector3.zero;
        if(Input.GetKey(KeyCode.R))
        {
            transform.position = initial_pos;
            transform.rotation = initial_rot;
        }
        if(Input.GetKey(KeyCode.W))
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
    }
}