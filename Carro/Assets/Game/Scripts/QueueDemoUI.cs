using System.Collections.Generic;
using System.Text;
using UnityEngine;
using TMPro;

public class QueueDemoUI : MonoBehaviour
{
    [Header("INPUTS")]
    public TMP_InputField inputID;
    public TMP_InputField inputMarca;
    public TMP_InputField inputModelo;
    public TMP_InputField inputPlaca;
    public TMP_InputField inputPuertas;

    [Header("VISTAS")]
    public TextMeshProUGUI queueView;
    public TextMeshProUGUI frontView;

    private Queue<Carro> queue = new Queue<Carro>();

    public void Enqueue()
    {
        if (string.IsNullOrEmpty(inputID.text)) return;

        Carro nuevoCarro = new Carro(
            inputID.text,
            inputMarca.text,
            inputModelo.text,
            inputPlaca.text,
            int.Parse(inputPuertas.text)
        );

        queue.Enqueue(nuevoCarro);
        LimpiarInputs();
        ShowQueue();
    }

    public void Dequeue()
    {
        if (queue.Count == 0) return;

        Carro atendido = queue.Dequeue();
        Debug.Log("DEQUEUE: " + atendido.marca + " " + atendido.modelo);
        ShowQueue();
    }

    public void Clear()
    {
        queue.Clear();
        ShowQueue();
    }

    private void ShowQueue()
    {
        if (queue.Count > 0)
        {
            Carro frente = queue.Peek();
            frontView.text = $"FRENTE: {frente.marca} {frente.modelo} - {frente.placa}";
        }
        else
        {
            frontView.text = "FRENTE: (vacío)";
        }

        var sb = new StringBuilder();
        sb.AppendLine("COLA DE CARROS (Frente → Final)");

        foreach (var c in queue)
        {
            sb.AppendLine($"• ID:{c.idVehiculo} | {c.marca} {c.modelo} | Placa: {c.placa} | Puertas: {c.numeroPuertas}");
        }

        queueView.text = sb.ToString();
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