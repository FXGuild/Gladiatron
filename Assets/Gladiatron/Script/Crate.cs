using UnityEngine;

namespace FXGuild.Gladiatron
{
    public sealed class Crate : MonoBehaviour
    {
        private const float DEADLY_DURATION = 1.5f;

        private float m_CreationTime;

        public bool IsDeadly { get { return Time.fixedTime - m_CreationTime < DEADLY_DURATION; } }

        private void Start()
        {
            m_CreationTime = Time.fixedTime;
        }
    
        private void Update()
        {
            // If not deadly anymore
            if (!IsDeadly)
            {
                // Change color
                GetComponent<Renderer>().material.color = new Color(0, 0, 0);

                // Go in the ground layer
                gameObject.layer = 8;
            }
        }
    }
}