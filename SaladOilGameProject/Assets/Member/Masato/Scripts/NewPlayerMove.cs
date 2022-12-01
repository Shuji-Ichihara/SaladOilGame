using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 仮にプレイヤーとオブジェクト（後のサラダ油製造機を作ってもらい）
プレイヤー側は5秒たったら油製造機を触れるようになり
触れている状態でaキーを押したら製造機の処理を開始する。処理が始まったらプレイヤーのフラグをオフにする。
 */
public class NewPlayerMove : MonoBehaviour
{
    private float speed = 0.5f;        //移動速度

    private Rigidbody2D rb;

    public bool Get_Water = false;
    public bool Set_Water = false;
    public bool Set_Ground = false;
    public static bool Revival = false;

    public int BeanCount => _beanCount;
    private int _beanCount = default;           // 現在の大豆の所持数

    [Header("豆を持てる最大個数")]
    [SerializeField]
    private int _maxBeanCount = 10;             // 大豆の最大所持数

    [SerializeField, Header("最大で持てるサラダ油の数")]
    private int _maxSaladaCount = 5;

    private int _saladaCount = 0;       //サラダ油の数

    [SerializeField]
    private GameObject _Salada;         //サラダ油製造機

    private Collision _collision;

    private bool _isTimerFlag = false;  //五秒経ったか判定する奴

    // Start is called before the first frame update
    void Start()
    {
        _beanCount = 0;
        StartCoroutine("Timer");
        Get_Water = false;
        Set_Water = false;
        Set_Ground = false;
        Revival = false;

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;

        if (Input.GetKey("left"))
        {
            position.x -= speed;
        }
        else if (Input.GetKey("right"))
        {
            position.x += speed;
        }
        else if (Input.GetKey("up"))
        {
            position.y += speed;
        }
        else if (Input.GetKey("down"))
        {
            position.y -= speed;
        }

        transform.position = position;

        if (Set_Water == true)
        {
            if (Input.GetKey(KeyCode.B))
            {
                Debug.Log("水ゲットだぜ");
                Get_Water = true;
            }
        }

        if (Set_Ground == true)
        {
            if (Input.GetKey(KeyCode.B) && Get_Water)
            {
                Debug.Log("畑に水をスローイン");
                Get_Water = false;
                Revival = true;
            }
            else if (Input.GetKey(KeyCode.B) && !Get_Water)
            {
                Debug.Log("水持って無いよ");
            }
        }
    }

    private void BeansCountUp()
    {
        if (_beanCount >= _maxBeanCount) { return; }
        _beanCount++;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.tag);
        Debug.Log("大豆の所持数 - " + _beanCount);
        if (other.gameObject.CompareTag("Bean"))
        {
            BeansCountUp();
        }
        else if (other.gameObject.CompareTag("Bean") == false) { return; }
    }
    /// <summary>
    /// タグが"Machine"だったら処理を行うやつ（Machineのタグが付いてるやつはコライダーのIs Triggerにチェック入れてるよ）
    /// </summary>
    /// <param name="other">ぶつかったオブジェクト</param>
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Machine"))
        {
            //Debug.Log("Machineタグだよ!!");

            if (_isTimerFlag == true && Input.GetKey(KeyCode.A))   //五秒たってキー押したら走る
            {

                if (_maxSaladaCount > _saladaCount)
                {
                    StartCoroutine("SaladaCount");
                }


            }

        }
    }
    /// <summary>
    /// タイマー機能
    /// </summary>
    /// <returns></returns>
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(5.0f);
        _isTimerFlag = true;
        Debug.Log("true");
    }

    /// <summary>
    /// サラダのカウント
    /// </summary>
    /// <returns></returns>
    IEnumerator SaladaCount()
    {
        
        _isTimerFlag = false;
        Debug.Log("false リセットしたよ");
        yield return new WaitForSeconds(10.0f);
        _saladaCount++;
        Debug.Log(_saladaCount);

        StartCoroutine("Timer");

    }

    //豆を拾った処理
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Beans")
        {
            Debug.Log("当たった");
            GameManger.beans -= 1;
            Destroy(collision.gameObject);
        }
    }


    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Water")
        {
            Debug.Log("水に触れてま～す");
            Set_Water = true;
        }

        if (collision.gameObject.tag == "Ground")
        {
            Debug.Log("畑の周りだよ～");
            Set_Ground = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Water")
        {
            Debug.Log("離れたよ");
            Set_Water = false;
        }
        if (collision.gameObject.tag == "Ground")
        {
            Debug.Log("離れたよ");
            Set_Ground = false;
        }
    }
}
