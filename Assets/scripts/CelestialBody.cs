using UnityEngine;

public class CelestialBody : MonoBehaviour
{
    public float mass;
    public Vector3 vel;
    public Vector3 acc;
    public Color col;

    public void Init(float mass, Vector3 vel, Vector3 acc, Color col)
    {
        this.mass = mass;
        this.vel = vel;
        this.acc = acc;
        this.col = col;
    }

    //     void OnDestroy()
    //     {
    //         if (ownedMaterial != null)
    //             Destroy(ownedMaterial);
    //     }
}
