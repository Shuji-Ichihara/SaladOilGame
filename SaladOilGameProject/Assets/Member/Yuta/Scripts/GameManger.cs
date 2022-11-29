using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    //豆のプレハブ
    [SerializeField] GameObject Beans;
    //次に豆が出る時間
    private float NextTime = 1f;
    //豆のMax
    private int Max_beans = 10;
    //現在の豆の数
    public static int beans = 5;
    //時間を記憶
    private float time = 0f;

    // Start is called before the first frame update
    void Start()
    {
        beans = 5;
        time = 0f;
    }

    void Update()
    {
        //出現数を超えたら何もしない
        if(beans >= Max_beans)
        {
            return;
        }

        //経過時間を足す
        time += Time.deltaTime;

        if(time >= NextTime)
        {
            time = 0;

            beans++;

            SpawnBeans();
        }
    }

    void SpawnBeans()
    {
        //プレハブの位置をランダムで設定
        float x = Random.Range(-400f, 400f);
        float y = Random.Range(-450f, 450f);
        Vector3 pos = new Vector2(x, y);

        //プレハブを生成
        Instantiate(Beans, pos, Quaternion.identity);

        time = 0;
    }
}
