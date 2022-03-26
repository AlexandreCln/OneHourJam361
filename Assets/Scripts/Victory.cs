using TMPro;
using UnityEngine;

namespace OneHourJam362
{
    public class Victory : MonoBehaviour
    {
        public static Victory Instance { private set; get; }

        private void Awake()
        {
            Instance = this;
        }

        public bool IsWon { private set; get; }

        [SerializeField]
        private TMP_Text _text;

        private int _chickenCount;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Chicken"))
            {
                _chickenCount++;
                _text.text = $"{_chickenCount} / 10";
                if (_chickenCount == 1)
                {
                    IsWon = true;
                    Timer.Instance.IsActive = false;
                }
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Chicken"))
            {
                _chickenCount--;
                _text.text = $"{_chickenCount} / 10";
            }
        }
    }
}