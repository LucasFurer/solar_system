using System.Collections.Generic;
using UnityEngine;

public class solar_system_script : MonoBehaviour
{
    [SerializeField]
    private GameObject celestial_body_prefab;

    private List<GameObject> celestial_bodies = new List<GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AddBody("sun", mass: 20);
    }

    // Update is called once per frame
    void Update() { }

    void AddBody(string name, float mass)
    {
        GameObject obj = Instantiate(celestial_body_prefab, transform);
        obj.name = name;
        obj.GetComponent<BodyProperties>().Init(mass: mass);
        celestial_bodies.Add(obj);
    }
}
