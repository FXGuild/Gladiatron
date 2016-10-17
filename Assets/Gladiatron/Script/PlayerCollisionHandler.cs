using UnityEngine;
using UnityEngine.SceneManagement;

namespace FXGuild.Gladiatron
{
    public sealed class PlayerCollisionHandler : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D a_Collision)
        {
            RestartLevelIfDeadly(a_Collision.gameObject);
        }

        private void OnTriggerEnter2D(Collider2D a_Collider)
        {
            //RestartLevelIfDeadly(a_Collider.gameObject);
        }

        private void RestartLevelIfDeadly(GameObject a_Obj)
        {
            if (a_Obj.layer == 10)
            {
                Destroy(gameObject);
            }
        }
    }
}
