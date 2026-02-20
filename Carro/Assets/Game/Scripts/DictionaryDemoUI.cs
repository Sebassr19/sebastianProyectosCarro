using System.Collections.Generic;
using System.Text;
using UnityEngine;
using TMPro;

public class DictionaryDemoUI : MonoBehaviour
{
    [Header("INPUTS")]
    public TMP_InputField inputID;
    public TMP_InputField inputMarca;
    public TMP_InputField inputModelo;
    public TMP_InputField inputPlaca;
    public TMP_InputField inputPuertas;

    [Header("VISTAS")]
    public TextMeshProUGUI resultView;
    public TextMeshProUGUI dictView;

    private Dictionary<string, Vehiculo> dict = new Dictionary<string, Vehiculo>();

    public void AddOrUpdate()
    {
        if (string.IsNullOrEmpty(inputID.text)) return;

        Carro nuevoCarro = new Carro(
            inputID.text.Trim(),
            inputMarca.text.Trim(),
            inputModelo.text.Trim(),
            inputPlaca.text.Trim(),
            int.Parse(inputPuertas.text.Trim())
        );

        dict[nuevoCarro.idVehiculo] = nuevoCarro;

        resultView.text = "Vehículo guardado correctamente";
        LimpiarInputs();
        ShowDictionary();
    }

    public void Get()
    {
        string id = inputID.text.Trim();
        if (string.IsNullOrEmpty(id)) return;

        if (dict.TryGetValue(id, out Vehiculo v))
        {
            Carro c = (Carro)v;
            resultView.text = $"Encontrado: {c.marca} {c.modelo} - {c.placa}";
        }
        else
        {
            resultView.text = "No existe ese ID";
        }
    }

    public void Remove()
    {
        string id = inputID.text.Trim();
        if (string.IsNullOrEmpty(id)) return;

        bool eliminado = dict.Remove(id);
        resultView.text = eliminado ? "Vehículo eliminado" : "No existe ese ID";
        ShowDictionary();
    }

    public void Clear()
    {
        dict.Clear();
        resultView.text = "Diccionario limpiado";
        ShowDictionary();
    }

    private void ShowDictionary()
    {
        var sb = new StringBuilder();
        sb.AppendLine("DICCIONARIO DE VEHÍCULOS");

        foreach (var kv in dict)
        {
            Carro c = (Carro)kv.Value;
            sb.AppendLine($"• ID:{c.idVehiculo} | {c.marca} {c.modelo} | Placa: {c.placa} | Puertas: {c.numeroPuertas}");
        }

        dictView.text = sb.ToString();
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