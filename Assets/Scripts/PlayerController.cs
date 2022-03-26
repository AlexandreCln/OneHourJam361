using UnityEngine;

namespace OneHourJam362
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private float _speed;

        private Vector2 _dir;
        private Rigidbody2D _rb;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            _dir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * _speed;
        }

        private void FixedUpdate()
        {
            _rb.velocity = _dir;
        }
    }

}