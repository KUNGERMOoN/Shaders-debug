using TMPro;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    public float MeasureTime;
    public TextMeshProUGUI Text;

    int frames;

    float timeSinceLastMeasure;
    void Update()
    {
        frames++;
        timeSinceLastMeasure += Time.deltaTime;
        if (timeSinceLastMeasure >= MeasureTime)
        {
            float fps = frames / timeSinceLastMeasure;
            Text.text = $"FPS: {fps}";

            frames = 0;
            timeSinceLastMeasure = 0;
        }
    }
}
