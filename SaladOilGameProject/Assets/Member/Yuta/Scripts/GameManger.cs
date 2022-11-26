using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    [SerializeField] GameObject beans;

    private int beans_number = 5;
    private int max = 10;
    private float time = 0f;

    // Start is called before the first frame update
    void Start()
    {
        beans_number = 5;
    }

    void Update()
    {
        time += Time.deltaTime;

        if (time >= 1f)
        {
            beans_number++;

            if (beans_number <= max)
            {
                //プレハブの位置をランダムで設定
                float x = Random.Range(-400f, 400f);
                float y = Random.Range(-450f, 450f);
                Vector3 pos = new Vector2(x, y);

                //プレハブを生成
                Instantiate(beans, pos, Quaternion.identity);

                time = 0f;
            }
        }
    }
}
