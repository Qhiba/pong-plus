using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaddleCustomization : MonoBehaviour
{
    [SerializeField] private Slider speedSlider;
    [SerializeField] private Text speedSliderValue;

    [SerializeField] private Slider heightSlider;
    [SerializeField] private Text heightSliderValue;

    [SerializeField] private Image leftPaddle;
    [SerializeField] private Image rightPaddle;

    // Dictionary of codes and paddle height as fraction of screen height.
    private Dictionary<int, float> paddleHeightsCode = new Dictionary<int, float>()
    {
        {1, 0.08f}, // Code 1 for paddle height = 1/12 -> 0.08 of screen height.
        {2, 0.10f}, // Code 2 for paddle height = 1/10 -> 0.10 of screen height.
        {3, 0.12f}, // Code 3 for paddle height = 1/8 -> 0.12 of screen height.
        {4, 0.17f}, // Code 4 for paddle height = 1/6 -> 0.17 of screen height.
        {5, 0.25f}, // Code 5 for paddle height = 1/4 -> 0.25 of screen height.
    };

    private const float DEFAULT_SPEED = 10.0f;
    private const float DEFAULT_HEIGHT_FRACTION = 0.20f;
    private readonly string DEFAULT_LEFT_COLOR = ColorUtility.ToHtmlStringRGBA(Color.red);
    private readonly string DEFAULT_RIGHT_COLOR = ColorUtility.ToHtmlStringRGBA(Color.red);

    public float PaddleSpeed { get; private set; }
    public float PaddleHeight { get; private set; }
    public string LeftPaddleColor { get; private set; }
    public string RightPaddleColor { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        CheckPaddlePrefs();
        SetAllPaddlePrefs();
    }

    public void CheckPaddlePrefs()
    {
        if (!PlayerPrefs.HasKey("PaddleSpeed"))
        {
            PlayerPrefs.SetFloat("PaddleSpeed", DEFAULT_SPEED);
            PlayerPrefs.Save();
        }

        if (!PlayerPrefs.HasKey("PaddleHeight"))
        {
            PlayerPrefs.SetFloat("PaddleHeight", DEFAULT_HEIGHT_FRACTION);
            PlayerPrefs.Save();
        }

        if (!PlayerPrefs.HasKey("LeftPaddleColor"))
        {
            PlayerPrefs.SetString("LeftPaddleColor", DEFAULT_LEFT_COLOR);
            PlayerPrefs.Save();
        }

        if (!PlayerPrefs.HasKey("RightPaddleColor"))
        {
            PlayerPrefs.SetString("RightPaddleColor", DEFAULT_RIGHT_COLOR);
            PlayerPrefs.Save();
        }
    }

    private void SetAllPaddlePrefs()
    {
        SetSpeed();
        SetHeight();
        SetLeftColor();
        SetRightColor();
    }

    public void SetSpeed()
    {
        speedSliderValue.text = "Paddle Speed: \n" + speedSlider.value.ToString();
        PaddleSpeed = speedSlider.value;
    }

    public void SetHeight()
    {
        float paddleHeigthFraction;
        RectTransform leftPaddleScale = leftPaddle.GetComponent <RectTransform>();
        RectTransform rightPaddleScale = rightPaddle.GetComponent<RectTransform>();

        heightSliderValue.text = "Paddle heigth: " + heightSlider.value.ToString();
        paddleHeigthFraction = paddleHeightsCode[(int)heightSlider.value];
        PaddleHeight = CalculateFractionOfScreenHeight(paddleHeigthFraction);

        leftPaddleScale.localScale = new Vector2(leftPaddleScale.localScale.x, PaddleHeight);
        rightPaddleScale.localScale = new Vector2(rightPaddleScale.localScale.x, PaddleHeight);
    }

    private float CalculateFractionOfScreenHeight(float fraction)
    {
        Camera camera = Camera.main;
        float screenHeight = camera.orthographicSize * 2;
        return screenHeight * fraction;
    }

    private void SetLeftColor()
    {

    }

    private void SetRightColor()
    {

    }
}
