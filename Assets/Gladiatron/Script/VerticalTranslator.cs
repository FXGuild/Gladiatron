using UnityEngine;
using UnityEngine.SceneManagement;

namespace FXGuild.Gladiatron
{
    public sealed class VerticalTranslator : MonoBehaviour
    {
        public float Speed = 0.005f;

        private void Update()
        {
            var pos = transform.position;
            pos.y += Speed;
            transform.position = pos;

            if (Input.GetButton("Restart"))
            {
                SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
            }
        }
    }
}