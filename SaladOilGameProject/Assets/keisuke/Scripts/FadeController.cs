using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeController : MonoBehaviour
{
    public static FadeController Instance { get => _instance; }
    static FadeController _instance;

    [SerializeField]
    private float _fadeSpeed = 0.0f;
    [SerializeField]
    private GameObject _fadeCanvas = null;

    [System.NonSerialized]
    public bool _isFade = false;        // fade 開始フラグ

    private Image _fadeImage = null;    // Fade に使用する Image
    private float _alpha = 0.0f;        // 透過率
    private string _sceneName = "";     // 現在のシーン名

    private void Awake()
    {
        if (_instance == null) { _instance = this; }
        else { Destroy(this); }
        DontDestroyOnLoad(_instance);
    }

    // Start is called before the first frame update
    void Start()
    {
        _fadeCanvas = GameObject.Find("FadeCanvas");
        _fadeImage = _fadeCanvas.GetComponentInChildren<Image>();
        _fadeImage.color = new Color32(255, 255, 255, 0);
        _fadeCanvas.SetActive(false);
    }

    private void Update()
    {
        _sceneName = SceneManager.GetActiveScene().name;
    }

    /// <summary>
    /// FadeOut 開始
    /// </summary>
    /// <param name="alpha">現在の透明度</param>
    /// <returns></returns>
    public IEnumerator FadeIn(float alpha)
    {
        _alpha = alpha;
        while (true)
        {
            _alpha -= Time.deltaTime / _fadeSpeed;
            _fadeImage.color = new Color(0.0f, 0.0f, 0.0f, _alpha);
            if (_alpha < 0.0f)
            {
                _alpha = 0.0f;
                break;
            }
            yield return null;
        }
        _fadeCanvas.SetActive(false);
    }

    /// <summary>
    /// FadeIn 開始
    /// </summary>
    /// <returns></returns>
    public IEnumerator FadeOut()
    {
        _fadeCanvas.SetActive(true);
        _alpha = _fadeImage.color.a;
        while (true)
        {
            _alpha += Time.deltaTime / _fadeSpeed;
            _fadeImage.color = new Color(0.0f, 0.0f, 0.0f, _alpha);
            if (_alpha > 1.0f)
            {
                _alpha = 1.0f;
                break;
            }
            yield return null; ;
        }
        yield return SceneController.Instance.LoadScene(_sceneName);
        StartCoroutine(FadeIn(_alpha));
    }
}
