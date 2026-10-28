using System.Collections.Generic;
using UnityEngine;

public class SolarSystem : MonoBehaviour
{
    public GameObject celestial_body_prefab;

    public float step_size = 0.1F;
    public float G = 1f;

    private List<GameObject> celestial_bodies = new List<GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AddBody(
            name: "sun",
            position: new Vector3(0, 0, 0),
            mass: 20,
            vel: new Vector3(0, 0, 0),
            acc: Vector3.zero
        );
        AddBody(
            name: "earth",
            position: new Vector3(10, 0, 10),
            mass: 10,
            vel: new Vector3(-1, 0, 0),
            acc: Vector3.zero
        );
        AddBody(
            name: "mars",
            position: new Vector3(-20, 0, -20),
            mass: 3,
            vel: new Vector3(0, 0, 1),
            acc: Vector3.zero
        );
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ComputeGravity();
        TimeStep();
    }

    void AddBody(string name, Vector3 position, float mass, Vector3 vel, Vector3 acc)
    {
        GameObject obj = Instantiate(celestial_body_prefab, transform);
        BodyProperties prop = obj.GetComponent<BodyProperties>();
        if (prop == null)
            Debug.Log("prefab doesnt have BodyProperties");
        obj.name = name;
        obj.transform.position = position;
        prop.Init(mass: mass, vel: vel, acc: acc);
        celestial_bodies.Add(obj);
    }

    void ComputeGravity()
    {
        for (int i = 0; i < celestial_bodies.Count; ++i)
        {
            BodyProperties A_prop = celestial_bodies[i].GetComponent<BodyProperties>();
            Vector3 A_pos = celestial_bodies[i].transform.position;
            A_prop.acc = Vector3.zero;

            for (int j = 0; j < celestial_bodies.Count; ++j)
            {
                if (i != j)
                {
                    BodyProperties B_prop = celestial_bodies[j].GetComponent<BodyProperties>();
                    Vector3 B_pos = celestial_bodies[j].transform.position;

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
        for (int i = 0; i < celestial_bodies.Count; ++i)
        {
            BodyProperties prop = celestial_bodies[i].GetComponent<BodyProperties>();
            prop.vel += step_size * prop.acc;
            celestial_bodies[i].transform.position += step_size * prop.vel;
        }
    }
}
