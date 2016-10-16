using UnityEngine;

namespace FXGuild.Gladiatron
{
    public class NeuronTileGrid : MonoBehaviour
    {
        public GameObject NeuronPrefab;
        public uint NumRows = 5;
        public uint NumColumns = 5;
        public float Size = 1;

        private void Start()
        {
            for (uint j = 0; j < NumRows; ++j)
            {
                for (uint i = 0; i < NumColumns; ++i)
                {
                    var neuron = Instantiate(NeuronPrefab);
                    neuron.transform.parent = transform;

                    float x = (i - (NumColumns - 1) / 2.0f) * Size;
                    neuron.transform.localScale = new Vector3(Size, Size, 1);
                    neuron.transform.localPosition = new Vector3(x, j * Size, 0);
                }
            }
        }
    }
}