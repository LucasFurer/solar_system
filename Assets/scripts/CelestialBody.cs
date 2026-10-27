using UnityEngine;

namespace Solar
{
    public class CelestialBody
    {
        public float m_mass { get; set; }
        public GameObject m_game_object { get; set; }

        public CelestialBody(float mass, GameObject game_object)
        {
            m_mass = mass;
            m_game_object = game_object;
        }
    }
}
