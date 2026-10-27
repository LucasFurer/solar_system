using System.Collections.Generic;
using Solar;
using UnityEngine;

public class solar_system_script : MonoBehaviour
{
    List<CelestialBody> celestial_bodies = new List<CelestialBody> { };

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject obj = new GameObject("sun");
        MeshFilter mesh_filter = obj.AddComponent<MeshFilter>();
        mesh_filter.sharedMesh = Resources.GetBuiltinResource<Mesh>("Sphere.fbx");
        MeshRenderer mesh_renderer = obj.AddComponent<MeshRenderer>();
        Shader litShader = Shader.Find("Universal Render Pipeline/Lit");
        mesh_renderer.sharedMaterial = new Material(litShader);

        CelestialBody sun = new CelestialBody(10, obj);
        celestial_bodies.Add(sun);
    }

    // Update is called once per frame
    void Update() { }
}
