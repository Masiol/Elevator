using UnityEngine;

public class FloorVisualization : MonoBehaviour
{
    public float radius = 1f;

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}