using UnityEngine;
 
public class EditorMove : MonoBehaviour
{
    [SerializeField] float speed = 0.5f;
    [SerializeField] float sensitivity = 1.0f;
    [SerializeField] float scrollSpeed = 1.0f;
 
    private Vector3 initial_pos;
    Camera cam;
    Vector3 anchorPoint;
    Quaternion anchorRot;
    Quaternion initial_rot;


    private void Awake()
    {
        initial_pos = transform.position;
        initial_rot = transform.rotation;
        cam = GetComponent<Camera>();
    }
   
    void FixedUpdate()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0) 
            transform.position += scrollSpeed * new Vector3(0, -Input.GetAxis("Mouse ScrollWheel"), 0);

        Vector3 move = Vector3.zero;
        if(Input.GetKey(KeyCode.R))
        {
            transform.position = initial_pos;
            transform.rotation = initial_rot;
        }
        if(Input.GetKey(KeyCode.W))
            move += Vector3.forward * speed;
        if (Input.GetKey(KeyCode.A))
            move -= Vector3.right * speed;
        if (Input.GetKey(KeyCode.S))
            move -= Vector3.forward * speed;
        if (Input.GetKey(KeyCode.D))
            move += Vector3.right * speed;
        if (Input.GetKey(KeyCode.E))
            move += Vector3.up * speed;
        if (Input.GetKey(KeyCode.Q))
            move -= Vector3.up * speed;
        transform.Translate(move);
 
        if (Input.GetMouseButtonDown(1))
        {
            anchorPoint = new Vector3(Input.mousePosition.y, -Input.mousePosition.x);
            anchorRot = transform.rotation;
        }
        if (Input.GetMouseButton(1))
        {
            Quaternion rot = anchorRot;
            Vector3 dif = anchorPoint - new Vector3(Input.mousePosition.y, -Input.mousePosition.x);
            rot.eulerAngles += dif * sensitivity;
            transform.rotation = rot;
        }
    }
}