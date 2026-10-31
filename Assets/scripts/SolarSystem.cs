using System.Collections.Generic;
using UnityEngine;

public class SolarSystem : MonoBehaviour
{
    public GameObject celestial_body_prefab;

    public float step_size = 0.1f;
    public float sim_delay = 1.0f / 60.0f;
    private float time_since_last_step = 0.0f;
    public float G = 1f;

    CelestialBody[] celestial_bodies;

    void Awake()
    {
        celestial_bodies = FindObjectsByType<CelestialBody>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        time_since_last_step += Time.deltaTime;

        if (time_since_last_step > sim_delay)
        {
            time_since_last_step -= sim_delay;

            ComputeGravity();
            TimeStep();
        }
    }

    void ComputeGravity()
    {
        for (int i = 0; i < celestial_bodies.Length; ++i)
        {
            CelestialBody A_prop = celestial_bodies[i];
            Vector3 A_pos = celestial_bodies[i].gameObject.transform.position;
            A_prop.acc = Vector3.zero;

            for (int j = 0; j < celestial_bodies.Length; ++j)
            {
                if (i != j)
                {
                    CelestialBody B_prop = celestial_bodies[j];
                    Vector3 B_pos = celestial_bodies[j].gameObject.transform.position;

                    Vector3 R = B_pos - A_pos;
                    float r = Mathf.Max(R.magnitude, 0.1f);
                    R = Vector3.Normalize(R);

                    A_prop.acc += G * R * B_prop.mass / (r * r);
                }
            }
        }
    }

    void TimeStep()
    {
        for (int i = 0; i < celestial_bodies.Length; ++i)
        {
            CelestialBody prop = celestial_bodies[i];
            prop.vel += step_size * prop.acc;
            celestial_bodies[i].transform.position += step_size * prop.vel;
        }
    }
}
