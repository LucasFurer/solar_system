using UnityEngine;

public class BodyProperties : MonoBehaviour
{
    public float mass;
    public Vector3 vel;
    public Vector3 acc;

    public void Init(float mass, Vector3 vel, Vector3 acc)
    {
        this.mass = mass;
        this.vel = vel;
        this.acc = acc;
    }

    //     void OnDestroy()
    //     {
    //         if (ownedMaterial != null)
    //             Destroy(ownedMaterial);
    //     }
}
