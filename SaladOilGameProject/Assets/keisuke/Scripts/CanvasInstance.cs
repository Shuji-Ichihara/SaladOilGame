using UnityEngine;
using UnityEngine.UI;

public class CanvasInstance : MonoBehaviour
{
    public static CanvasInstance Instance { get => _instance; }
    static CanvasInstance _instance;

    [SerializeField]
    private Image _canvasImage = null;

    private void Awake()
    {
        if (_instance == null) { _instance = this; }
        else { Destroy(this); }
        DontDestroyOnLoad(_instance);
    }
    private void Update()
    {
        _canvasImage.color = new Color32(255, 255, 255, 0);
    }
}
