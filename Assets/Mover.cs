using UnityEngine;

class Mover : MonoBehaviour
{
    [SerializeField] float speed = 5;

    void Update()
    {
        bool up = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
        bool down = Input.GetKey(KeyCode.DownArrow);
        bool right = Input.GetKey(KeyCode.RightArrow);
        bool left = Input.GetKey(KeyCode.LeftArrow);

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

        Vector3 velocity = new (x, 0, z);

        velocity.Normalize();

        velocity *= speed;

        Vector3 p = transform.position;

        Vector3 newPos = p + (velocity * Time.deltaTime);

        transform.position = newPos;

        if(velocity != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(velocity);
    }
}
