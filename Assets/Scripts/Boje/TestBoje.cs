using UnityEngine;

namespace Boje
{
    public class TestBoje : MonoBehaviour
    {
        [SerializeField] private int count = 0;

        private void Update()
        {
            count += 1;
            if (count % 10 == 0)
            {
                Debug.Log(count);
            }
        }
    }
}