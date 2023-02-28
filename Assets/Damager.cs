using UnityEngine;

class Damager : MonoBehaviour
{
    [SerializeField] int damage = 10;

    void OnTriggerEnter(Collider other)
    {
        // GameObject go = other.gameObject;
        // Debug.Log(go.name);

        HealthObject ho = other.GetComponent<HealthObject>();

        if (ho != null) 
        {
            ho.Damage(damage);
        }
    }
}
