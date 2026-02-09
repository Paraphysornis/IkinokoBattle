using UnityEngine;

public class RoundLight : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(0, -6) * Time.deltaTime);
    }
}
