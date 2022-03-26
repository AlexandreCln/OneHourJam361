using UnityEngine;

namespace OneHourJam362
{
    public class ChickenController : MonoBehaviour
    {
        private float _dirTimer;
        private float _minSpeed = 15f, _maxSpeed = 20f;
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

            _rb.velocity = _dir * Time.deltaTime * _speed;
            transform.localScale = new Vector3(_rb.velocity.x < 0f ? -1f : 1f, 1f, 1f);

            _sr.sortingOrder = -(int)(transform.position.y * 1000f);
        }
    }

}