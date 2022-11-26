using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class PlayerControllerTest : MonoBehaviour
{
    // Player の移動速度
    [SerializeField]
    private float _playerMoveSpeed = default;

    private Rigidbody2D _rb2D = null;
    private CircleCollider2D _circleCol2D = null;

    // 現在の大豆の所持数
    public int BeanCount => _beanCount;
    private int _beanCount = default;
    // 大豆の最大所持数
    private int _maxBeanCount = default;

    // Start is called before the first frame update
    void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _circleCol2D = GetComponent<CircleCollider2D>();
        _rb2D.gravityScale = 0.0f;
        _rb2D.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        _rb2D.freezeRotation = true;
    }

    private void FixedUpdate()
    {
        Move();
    }

    /// <summary>
    /// Plyaer の移動処理
    /// </summary>
    private void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        gameObject.transform.Translate(new Vector3(moveX * _playerMoveSpeed * Time.deltaTime
                                                  , moveY * _playerMoveSpeed * Time.deltaTime
                                                  , 0.0f));
    }

    private void BeansCountUp()
    {
        if (_beanCount >= _maxBeanCount) { return; }
        _beanCount++;
        Debug.Log("大豆の所持数" + _beanCount);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bean"))
        {
            BeansCountUp();
        }
    }
}
