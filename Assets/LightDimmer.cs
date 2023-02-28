using UnityEngine;

class LightDimmer : MonoBehaviour
{
    [SerializeField] Light light;
    [SerializeField] Color c1 = Color.white;
    [SerializeField] Color c2 = Color.white;
    [SerializeField] float frequency = 1;

    // [SerializeField, Range(0,1) ] float dim = 0;

    void OnValidate()
    {
        Update();
    }

    void Update()
    {
        float t = Time.time;
        t *= frequency;
        t *= Mathf.PI * 2;

        float sin = Mathf.Sin(t);
        sin += 1;
        sin /= 2;

        light.color = Color.Lerp(c1, c2, sin);
    }
}
