using UnityEngine;

public class BodyProperties : MonoBehaviour
{
    public float mass;

    public void Init(float mass)
    {
        this.mass = mass;
    }

    //     void OnDestroy()
    //     {
    //         if (ownedMaterial != null)
    //             Destroy(ownedMaterial);
    //     }
}
