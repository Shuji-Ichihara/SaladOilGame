using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerControllerTest : MonoBehaviour
{
    [Header("プレイヤーの移動速度")]
    [SerializeField]
    private float _playerMoveSpeed = default;   // Player の移動速度

    public int BeanCount => _beanCount;
    private int _beanCount = default;           // 現在の大豆の所持数
    
    [Header("豆を持てる最大個数")]
    [SerializeField]
    private int _maxBeanCount = 10;             // 大豆の最大所持数

    private Rigidbody2D _rb2D = null;

    // Start is called before the first frame update
    void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _rb2D.gravityScale = 0.0f;
        _rb2D.freezeRotation = true;
        _beanCount = 0;
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
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
#if UNITY_EDITOR
        Debug.Log(other.gameObject.tag);
        Debug.Log("大豆の所持数 - " + _beanCount);
#endif
        if (other.gameObject.CompareTag("Bean"))
        {
            BeansCountUp();
        }
        else if (other.gameObject.CompareTag("Bean") == false) { return; }
    }
}
