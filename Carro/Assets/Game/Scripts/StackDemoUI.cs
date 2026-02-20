using System.Collections.Generic;
using System.Text;
using UnityEngine;
using TMPro;

public class StackDemoUI : MonoBehaviour
{
    [Header("UI")]
    public TMP_InputField inputValue;
    public TextMeshProUGUI stackView;
    public TextMeshProUGUI topView;

    private Stack<string> stack = new Stack<string>();

    public void Push()
    {
        string v = inputValue.text.Trim();
        if (string.IsNullOrEmpty(v)) return;

        stack.Push(v);
        inputValue.text = "";
        ShowStack();
    }

    public void Pop()
    {
        if (stack.Count == 0) return;

        string removed = stack.Pop();
        Debug.Log("POP: " + removed);
        ShowStack();
    }

    public void Clear()
    {
        stack.Clear();
        ShowStack();
    }

    private void ShowStack()
    {
        topView.text = stack.Count > 0 ? $"TOP: {stack.Peek()}" : "TOP: (vacío)";

        var sb = new StringBuilder();
        sb.AppendLine("PILA (Top → Bottom)");

        foreach (var item in stack) 
            sb.AppendLine("• " + item);

        stackView.text = sb.ToString();
    }
}
