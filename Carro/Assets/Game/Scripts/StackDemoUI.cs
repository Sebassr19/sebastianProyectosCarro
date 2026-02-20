using System.Collections.Generic;
using System.Text;
using UnityEngine;
using TMPro;

public class StackDemoUI : MonoBehaviour
{
    [Header("INPUTS")]
    public TMP_InputField inputID;
    public TMP_InputField inputMarca;
    public TMP_InputField inputModelo;
    public TMP_InputField inputPlaca;
    public TMP_InputField inputPuertas;

    [Header("VISTAS")]
    public TextMeshProUGUI stackView;
    public TextMeshProUGUI topView;

    private Stack<Carro> stack = new Stack<Carro>();

    public void Push()
    {
        if (string.IsNullOrEmpty(inputID.text)) return;

        Carro nuevoCarro = new Carro(
            inputID.text.Trim(),
            inputMarca.text.Trim(),
            inputModelo.text.Trim(),
            inputPlaca.text.Trim(),
            int.Parse(inputPuertas.text.Trim())
        );

        stack.Push(nuevoCarro);
        LimpiarInputs();
        ShowStack();
    }

    public void Pop()
    {
        if (stack.Count == 0) return;

        Carro eliminado = stack.Pop();
        Debug.Log("POP: " + eliminado.marca + " " + eliminado.modelo);
        ShowStack();
    }

    public void Clear()
    {
        stack.Clear();
        ShowStack();
    }

    private void ShowStack()
    {
        if (stack.Count > 0)
        {
            Carro top = stack.Peek();
            topView.text = $"TOP: {top.marca} {top.modelo} - {top.placa}";
        }
        else
        {
            topView.text = "TOP: (vacío)";
        }

        var sb = new StringBuilder();
        sb.AppendLine("PILA DE CARROS (Top → Bottom)");

        foreach (var c in stack)
        {
            sb.AppendLine($"• ID:{c.idVehiculo} | {c.marca} {c.modelo} | Placa: {c.placa} | Puertas: {c.numeroPuertas}");
        }

        stackView.text = sb.ToString();
    }

    private void LimpiarInputs()
    {
        inputID.text = "";
        inputMarca.text = "";
        inputModelo.text = "";
        inputPlaca.text = "";
        inputPuertas.text = "";
    }
}
