using UnityEngine;

class Collectable : MonoBehaviour
{
    [SerializeField] int value = 1;
    [SerializeField] Bounds teleportArea;

    public int GetValue() => value;

    public void Teleport()
    {
        int i = Random.Range(0, 10);

        float x = Random.Range(teleportArea.min.x, teleportArea.max.x);
        float y = Random.Range(teleportArea.min.y, teleportArea.max.y);
        float z = Random.Range(teleportArea.min.z, teleportArea.max.z);

        transform.position = new Vector3(x, y, z);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(teleportArea.center, teleportArea.size);
        
    }
}