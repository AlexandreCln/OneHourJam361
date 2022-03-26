using UnityEngine;

namespace OneHourJam362
{
    public class ChickenController : MonoBehaviour
    {
        private float _dirTimer;
        private float _minSpeed = 0.5f, _maxSpeed = 1.0f;
        private Rigidbody2D _rb;
        private SpriteRenderer _sr;
        private Vector2 _dir;
        private float _speed;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _sr = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            _dirTimer -= Time.deltaTime;
            if (_dirTimer <= 0f)
            {
                _dirTimer = Random.Range(1f, 3f);

                _dir = Random.insideUnitCircle;
                _speed = Random.Range(_minSpeed, _maxSpeed);
                _dir.Normalize();
            }
            transform.localScale = new Vector3(_rb.velocity.x < 0f ? -1f : 1f, 1f, 1f);

            _sr.sortingOrder = -(int)(transform.position.y * 1000f);

            float distFromPlayer = Vector2.Distance(transform.position, PlayerController.Instance.transform.position);
        
            if (distFromPlayer <= 3)
            {
                Debug.Log(distFromPlayer);
                _dir = _dir * -1;
            }
        }

        private void FixedUpdate()
        {
            _rb.velocity = _dir * _speed;
        }
    }
}