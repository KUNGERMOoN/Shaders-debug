using UnityEngine;
using UnityEngine.Rendering;

public class Test : MonoBehaviour
{
    public ComputeShader Shader;
    ComputeBuffer buffer;

    GraphicsFence? fence;

    int[] Data;

    public bool GetData = true;

    private void Awake()
    {
        Data = new int[60000000];
        buffer = new ComputeBuffer(Data.Length, sizeof(int));
        buffer.SetData(Data);

        Shader.SetBuffer(0, "buffer", buffer);

        CreateFence();
    }

    private void Update()
    {
        if (fence != null && fence.Value.passed)
        {
            if (GetData)
                buffer.GetData(Data);
            //ReadingData();
            CreateFence();
        }
        //else NotReadingData();
    }

    void ReadingData() { }
    void NotReadingData() { }

    void CreateFence()
    {
        fence = Graphics.CreateGraphicsFence(GraphicsFenceType.AsyncQueueSynchronisation, SynchronisationStageFlags.ComputeProcessing);
    }
}