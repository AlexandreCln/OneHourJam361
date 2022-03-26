using UnityEngine;

namespace OneHourJam362
{
    public class PlayerController : MonoBehaviour
    {
        public static PlayerController Instance { private set; get; }

        private void Awake()
        {
            Instance = this;
        }

        [SerializeField]
        private float _speed;

        private Vector2 _dir;
        private Rigidbody2D _rb;
        private SpriteRenderer _sr;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _sr = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            if (Victory.Instance.IsWon)
            {
                return;
            }
            _dir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * _speed;
            if (_dir.x < 0)
            {
                _sr.flipX = true;
            }
            else if (_dir.x > 0)
            {
                _sr.flipX = false;
            }
        }

        private void FixedUpdate()
        {
            if (Victory.Instance.IsWon)
            {
                _rb.velocity = Vector2.zero;
                return;
            }
            _rb.velocity = _dir;
        }
    }

}