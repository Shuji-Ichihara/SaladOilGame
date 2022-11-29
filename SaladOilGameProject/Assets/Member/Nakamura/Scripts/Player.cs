using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 仮にプレイヤーとオブジェクト（後のサラダ油製造機を作ってもらい）
プレイヤー側は5秒たったら油製造機を触れるようになり
触れている状態でaキーを押したら製造機の処理を開始する。処理が始まったらプレイヤーのフラグをオフにする。
 */
public class Player : MonoBehaviour
{
    private float speed = 0.5f;        //移動速度

    [SerializeField]
    private GameObject _Salada;         //サラダ油製造機

    private Collision _collision;

    private bool _isTimerFlag = false;  //五秒経ったか判定する奴

    void Start()
    {
        StartCoroutine("Timer");
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

                //ここに製造機の処理やったらたぶんいけるはずずずzzz...

                _isTimerFlag = false;
                Debug.Log("false");
                StartCoroutine("Timer");

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

}
