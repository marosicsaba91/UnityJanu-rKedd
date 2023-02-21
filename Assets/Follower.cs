using UnityEngine;
class Follower : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float speed;

    [SerializeField] float bigRange = 15;
    [SerializeField] float smallRange = 10;

    void Update()
    {
        Vector3 selfPosition = transform.position;
        Vector3 targetPosition = target.position;

        float distance = Vector3.Distance(selfPosition, targetPosition);

        if (distance <= bigRange)
        {
            float t = Mathf.InverseLerp(bigRange, smallRange, distance);
            float actualSpeed = Mathf.Lerp(0,speed,t);

            transform.position = Vector3.MoveTowards(selfPosition, targetPosition, actualSpeed * Time.deltaTime);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, smallRange);
        Gizmos.DrawWireSphere(transform.position, bigRange);
    }
}