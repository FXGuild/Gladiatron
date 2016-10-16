using UnityEngine;

namespace FXGuild.Gladiatron
{
    public sealed class CrateGenerator : MonoBehaviour
    {
        public GameObject CratePrefab;

        // Number of frames without creating a crate
        private uint m_NumFramesWoCreate;

        // Average crate creation frequency
        private uint m_Frequency;

        private float m_StartTime;

        private void Start()
        {
            m_NumFramesWoCreate = 0;
            m_Frequency = 150;
            m_StartTime = Time.fixedTime;
        }

        private void Update()
        {
            ++m_NumFramesWoCreate;

            float denom = m_Frequency + 100 * Mathf.Cos((Time.fixedTime - m_StartTime) * 0.025f);

            // Generate a crate with a probability
            float probGenerate = Mathf.Pow(m_NumFramesWoCreate / denom, 4);
            if (Random.value < probGenerate)
            {
                GenerateCrate();
                m_NumFramesWoCreate = 0;
            }
        }

        private void GenerateCrate()
        {
            var crate = Instantiate(CratePrefab);
            float posX = (Random.value - 0.5f) * transform.localScale.x;
            crate.transform.position = new Vector3(posX, transform.position.y, 1);
            crate.transform.Rotate(0, 0, 360 * Random.value);
            crate.transform.localScale = Vector3.one * (1 + 0.5f * Random.value);
        }
    }
}
