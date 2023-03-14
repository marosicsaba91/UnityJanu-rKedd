using UnityEditor.Experimental.GraphView;
using UnityEngine;

class PathMover : MonoBehaviour
{
    [SerializeField] Transform posA, posB;
    [SerializeField] float speed;

    [SerializeField, Range(0, 1)] float startPosition = 0.5f;

    Transform nextTarget;

    void Start()
    {
        nextTarget = posA;
    }

    void Update()
    {
        Vector3 targetPosition = nextTarget.position;

        Vector3 nextPosition = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        transform.position = nextPosition;

        if (nextPosition == targetPosition) 
        {
            if(nextTarget == posA)
                nextTarget = posB;
            else
                nextTarget = posA;
        }
    }


    void OnValidate()
    {
        transform.position = Vector3.Lerp(posA.position, posB.position, startPosition);  
    }

    void OnDrawGizmos()
    {
        if (posA == null) return;
        if (posB == null) return;

        Color c1 = Color.red;
        Color c2 = new Color(0,0,1); // blues;
        Gizmos.color = Color.Lerp(c1, c2, startPosition);

        Gizmos.DrawSphere(posA.position, 0.1f);
        Gizmos.DrawSphere(posB.position, 0.1f);
        Gizmos.DrawLine(posA.position, posB.position);
    }
}
