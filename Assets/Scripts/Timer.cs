using TMPro;
using UnityEngine;

namespace OneHourJam362
{
    public class Timer : MonoBehaviour
    {
        public static Timer Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
        }

        public bool IsActive { set; private get; } = true;

        [SerializeField]
        private TMP_Text _text;

        private float _timer;

        private void Update()
        {
            if (!IsActive)
            {
                return;
            }
            _timer += Time.deltaTime;
            _text.text = $"{_timer:0.00}s";
        }
    }
}
