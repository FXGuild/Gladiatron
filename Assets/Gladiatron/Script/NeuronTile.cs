using System.Collections.Generic;
using UnityEngine;

namespace FXGuild.Gladiatron
{
    public sealed class NeuronTile : MonoBehaviour
    {
        private static readonly Color IDLE_COLOR = Color.gray;
        private static readonly Color NORMAL_COLOR = Color.green;
        private static readonly Color DEADLY_COLOR = Color.red;

        private const float TRANSPARENCY = 0.2f;

        private HashSet<Collider2D> m_NormalColliders;
        private HashSet<Collider2D> m_DeadlyColliders;

        private void Start()
        {
            m_NormalColliders = new HashSet<Collider2D>();
            m_DeadlyColliders = new HashSet<Collider2D>();
        }

        private void OnTriggerStay2D(Collider2D a_Collider)
        {
            if (!IsInARelevantLayer(a_Collider))
            {
                return;
            }

            // If a collider goes from deadly to normal
            if (m_DeadlyColliders.Contains(a_Collider) && !IsDeadly(a_Collider))
            {
                m_DeadlyColliders.Remove(a_Collider);
                m_NormalColliders.Add(a_Collider);
            }
            else
            {
                // Register collider
                var set = IsDeadly(a_Collider) ? m_DeadlyColliders : m_NormalColliders;
                if (!set.Contains(a_Collider))
                {
                    set.Add(a_Collider);
                }
            }
        }

        private void OnTriggerExit2D(Collider2D a_Collider)
        {
            if (!IsInARelevantLayer(a_Collider))
            {
                return;
            }

            // Remove collider
            m_DeadlyColliders.Remove(a_Collider);
            m_NormalColliders.Remove(a_Collider);
        }

        private bool IsInARelevantLayer(Collider2D a_Collider)
        {
            int layer = a_Collider.gameObject.layer;
            return a_Collider.gameObject.activeSelf && (layer >= 8 || layer <= 10);
        }

        private bool IsDeadly(Collider2D a_Collider)
        {
            return a_Collider.gameObject.layer == 10;
        }

        private void Update()
        {
            // Set color depending colliding objects
            Color color;
            if (m_DeadlyColliders.Count == 0)
            {
                color = m_NormalColliders.Count == 0 ? IDLE_COLOR : NORMAL_COLOR;
            }
            else
            {
                color = DEADLY_COLOR;
            }
            color.a = TRANSPARENCY;
            GetComponent<Renderer>().material.SetColor("_TintColor", color);
        }
    }
}