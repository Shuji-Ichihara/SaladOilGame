using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    //���̃v���n�u
    [SerializeField] GameObject Beans;
    //���ɓ����o�鎞��
    private float NextTime = 1f;
    //����Max
    private int Max_beans = 10;
    //���݂̓��̐�
    public static int beans = 5;
    //���Ԃ��L��
    private float time = 0f;

    // Start is called before the first frame update
    void Start()
    {
        beans = 5;
        time = 0f;
    }

    void Update()
    {
        //�o�����𒴂����牽�����Ȃ�
        if(beans >= Max_beans)
        {
            return;
        }

        //�o�ߎ��Ԃ𑫂�
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
        //�v���n�u�̈ʒu�������_���Őݒ�
        float x = Random.Range(-400f, 400f);
        float y = Random.Range(-450f, 450f);
        Vector3 pos = new Vector2(x, y);

        //�v���n�u�𐶐�
        Instantiate(Beans, pos, Quaternion.identity);

        time = 0;
    }
}
