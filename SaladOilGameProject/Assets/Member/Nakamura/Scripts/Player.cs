using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 ���Ƀv���C���[�ƃI�u�W�F�N�g�i��̃T���_�������@������Ă��炢�j
�v���C���[����5�b��������������@��G���悤�ɂȂ�
�G��Ă����Ԃ�a�L�[���������琻���@�̏������J�n����B�������n�܂�����v���C���[�̃t���O���I�t�ɂ���B

�T���_�������@�����̑���
�������n�܂���10�b�o������1�T���_���i�o���邽�тɃT���_���̏������𑝂₵�Ă��������j���o����悤�ɂ���B
 */
public class Player : MonoBehaviour
{
    private float speed = 0.5f;        //�ړ����x

    [SerializeField,Header("�ő�Ŏ��Ă�T���_���̐�")]
    private int _maxSaladaCount = 5;        

    private int _saladaCount = 0;       //�T���_���̐�

    [SerializeField]
    private GameObject _Salada;         //�T���_�������@

    private Collision _collision;

    private bool _isTimerFlag = false;  //�ܕb�o���������肷��z

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
    /// �^�O��"Machine"�������珈�����s����iMachine�̃^�O���t���Ă��̓R���C�_�[��Is Trigger�Ƀ`�F�b�N����Ă��j
    /// </summary>
    /// <param name="other">�Ԃ������I�u�W�F�N�g</param>
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Machine"))
        {
            //Debug.Log("Machine�^�O����!!");

            if (_isTimerFlag == true && Input.GetKey(KeyCode.A))   //�ܕb�����ăL�[�������瑖��
            {

                if(_maxSaladaCount�@> _saladaCount)
                {
                    StartCoroutine("SaladaCount");
                }


            }

        }
    }

    /// <summary>
    /// �^�C�}�[�@�\
    /// </summary>
    /// <returns></returns>
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(5.0f);
        _isTimerFlag = true;
        Debug.Log("true �ܕb��������");
    }



    /// <summary>
    /// �T���_�̃J�E���g
    /// </summary>
    /// <returns></returns>
    IEnumerator SaladaCount()
    {
        
        _isTimerFlag = false;
        Debug.Log("false ���Z�b�g������");
        yield return new WaitForSeconds(10.0f);
        _saladaCount++;
        Debug.Log(_saladaCount);

        StartCoroutine("Timer");

    }

}
