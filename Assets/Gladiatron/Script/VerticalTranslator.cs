using UnityEngine;

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
        }
    }
}