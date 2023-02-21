using UnityEngine;

class Mover : MonoBehaviour
{
    [SerializeField] Transform cameraTransform;
    [SerializeField] float speed = 5;

    [SerializeField] bool moveInCameraSpace = true;
    [SerializeField] float angularVelocity = 180;

    void Update()
    {
        bool up = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
        bool down = Input.GetKey(KeyCode.DownArrow);
        bool right = Input.GetKey(KeyCode.RightArrow);
        bool left = Input.GetKey(KeyCode.LeftArrow);

        /*
        Vector3 upDir = Vector3.up;
        Vector3 upDir2 = new Vector3(0,1,0);
        Vector3 localUp = transform.up;
        */

        float z = 0;
        if (up && down)
            z = 0;
        else if (up)
            z = 1;
        else if (down)
            z = -1;

        float x = 0;
        if (right)
            x += 1;
        if (left)
            x -= 1;

        //Vector3 rightDir = Vector3.right;
        //Vector3 forwardDir = Vector3.forward;

        Vector3 rightDir = moveInCameraSpace ? cameraTransform.right : Vector3.right;
        Vector3 forwardDir = moveInCameraSpace ? cameraTransform.forward : Vector3.forward;

        // Vector3 velocity = new (x, 0, z);
        Vector3 velocity = rightDir * x + forwardDir * z;
        velocity.y = 0;

        velocity.Normalize();

        velocity *= speed;

        Vector3 p = transform.position;

        Vector3 newPos = p + (velocity * Time.deltaTime);

        transform.position = newPos;

        if (velocity != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(velocity);
            Quaternion currentRotation = transform.rotation;
            transform.rotation = Quaternion.RotateTowards(currentRotation, targetRotation, angularVelocity * Time.deltaTime);
        }
    }
}
