using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FlashText : MonoBehaviour
{
    [SerializeField]
    private string _textName = "";
    [SerializeField]
    private float _flashTimeMaginicaton = default;      // �_�ł̑��x

    private TextMeshProUGUI _enterToStartText = null;   // �_�ł�����e�L�X�g

    private float _alpha = default;                     // �����x
    private bool _isFlash = false;                      // �����x�𑝌�������t���O

    // Start is called before the first frame update
    void Start()
    {
        _textName = this.gameObject.name;
        _enterToStartText = GameObject.Find(_textName).GetComponent<TextMeshProUGUI>();
        _enterToStartText.color = new Color32(255, 255, 255, 255);
        _alpha = _enterToStartText.color.a;
        StartCoroutine(FalshText());
    }

    private IEnumerator FalshText()
    {
        while (true)
        {
            Flash(_isFlash);
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }

    /// <summary>
    /// _isFlash �̐����ɂ���ăe�L�X�g�̓����x�𑝌�
    /// </summary>
    /// <param name="switchCalculation">�����x�����̃t���O</param>
    private void Flash(bool switchCalculation)
    {
        if (switchCalculation == false)
        {
            _alpha -= Time.deltaTime * 2.0f;
            _enterToStartText.color = new Color(0f, 0f, 0f, _alpha);
            if (_alpha <= 0.0f)
            {
                _alpha = 0.0f;
                _isFlash = true;
            }
        }
        else if (switchCalculation == true)
        {
            _alpha += Time.deltaTime * 2.0f;
            _enterToStartText.color = new Color(0f, 0f, 0f, _alpha);
            if (_alpha >= 1.0f)
            {
                _alpha = 1.0f;
                _isFlash = false;
            }
        }
    }
}
