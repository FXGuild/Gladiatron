using UnityEngine;
using UnityEngine.SceneManagement;

namespace FXGuild.Gladiatron
{
    public class Water : MonoBehaviour
    {
        public int NumVertex = 25;
        public float[] WaveFrequencies = { 10, 8, 2 };
        public float WaveAmplitude = 0.01f;

        private void Start()
        {
            // Setup line renderer
            GetComponent<LineRenderer>().SetVertexCount(NumVertex);
        }

        private void Update()
        {
            // Move wave
            var lr = GetComponent<LineRenderer>();
            for (int i = 0; i < NumVertex; ++i)
            {
                float normX = i / (NumVertex - 1.0f);
                float y = 0;
                foreach (float freq in WaveFrequencies)
                {
                    y += Mathf.Cos(freq * normX * Time.fixedTime);
                }
                y *= WaveAmplitude;
                y += 0.5f;
                lr.SetPosition(i, new Vector3(normX - 0.5f, y, 0));
            }
        }

        private void OnTriggerEnter2D(Collider2D a_Collider)
        {
            if (a_Collider.gameObject.tag == "Player")
            {
                SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
            }
        }
    }
}