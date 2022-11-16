using UnityEngine;

public class FlyCamera : MonoBehaviour {

    private float moveSpeed = 0.5f;
    private float scrollSpeed = 10f;

    private Vector3 mouseOrigin;
    private bool isPanning;

    public float panSpeed = 4.0f;

    void Update () 
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0) 
        {
            transform.position += moveSpeed * new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        }

        if (Input.GetAxis("Mouse ScrollWheel") != 0) 
        {
            transform.position += scrollSpeed * new Vector3(0, -Input.GetAxis("Mouse ScrollWheel"), 0);
        }

        if (Input.GetMouseButtonDown (1)) 
          {  
              mouseOrigin = Input.mousePosition;
              isPanning = true;
          }
        if (!Input.GetMouseButton (1)) 
            {
             isPanning = false;
            }

        if (isPanning) 
            {
             Vector3 pos     = Camera.main.ScreenToViewportPoint (Input.mousePosition - mouseOrigin);
             Vector3 move     = new Vector3 (pos.x * panSpeed, pos.y * panSpeed, 0);
 
             Camera.main.transform.Translate (move, Space.Self);
            }

    }

}