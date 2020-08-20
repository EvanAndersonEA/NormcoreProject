using UnityEngine;

public class Move : MonoBehaviour
{
    private void FixedUpdate()
    {
        transform.position += new Vector3(0, 0, -50) * Time.deltaTime;
    }
}
