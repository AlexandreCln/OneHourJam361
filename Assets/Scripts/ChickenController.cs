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

            _sr.sortingOrder = -(int)(transform.position.y * 1000f);
        }

        private void FixedUpdate()
        {
            _rb.velocity = _dir * _speed;
            if (_dir.x < 0)
            {
                _sr.flipX = true;
            }
            else if (_dir.x > 0)
            {
                _sr.flipX = false;
            }
        }
    }

}