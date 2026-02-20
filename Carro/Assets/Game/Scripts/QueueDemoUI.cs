using System.Collections.Generic;
using System.Text;
using UnityEngine;
using TMPro;

public class QueueDemoUI : MonoBehaviour
{
    [Header("UI")]
    public TMP_InputField inputValue;
    public TextMeshProUGUI queueView;
    public TextMeshProUGUI frontView;

    private Queue<string> queue = new Queue<string>();

    public void Enqueue()
    {
        string v = inputValue.text.Trim();
        if (string.IsNullOrEmpty(v)) return;

        queue.Enqueue(v);
        inputValue.text = "";
        ShowQueue();
    }

    public void Dequeue()
    {
        if (queue.Count == 0) return;

        string served = queue.Dequeue();
        Debug.Log("DEQUEUE: " + served);
        ShowQueue();
    }

    public void Clear()
    {
        queue.Clear();
        ShowQueue();
    }

    private void ShowQueue()
    {
        frontView.text = queue.Count > 0 ? $"FRENTE: {queue.Peek()}" : "FRENTE: (vacío)";

        var sb = new StringBuilder();
        sb.AppendLine("COLA (Frente → Final)");

        foreach (var item in queue)
            sb.AppendLine("• " + item);

        queueView.text = sb.ToString();
    }
}