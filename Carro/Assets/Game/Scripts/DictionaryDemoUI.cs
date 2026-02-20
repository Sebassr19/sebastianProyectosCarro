using System.Collections.Generic;
using System.Text;
using UnityEngine;
using TMPro;

public class DictionaryDemoUI : MonoBehaviour
{
    [Header("UI")]
    public TMP_InputField inputKey;
    public TMP_InputField inputValue;
    public TextMeshProUGUI resultView;
    public TextMeshProUGUI dictView;

    private Dictionary<string, string> dict = new Dictionary<string, string>();

    public void AddOrUpdate()
    {
        string k = inputKey.text.Trim();
        string v = inputValue.text.Trim();
        if (string.IsNullOrEmpty(k)) return;

        dict[k] = v; // si existe, actualiza; si no, agrega
        resultView.text = $"Guardado: [{k}] = {v}";
        ShowDictionary();
    }

    public void Get()
    {
        string k = inputKey.text.Trim();
        if (string.IsNullOrEmpty(k)) return;

        if (dict.TryGetValue(k, out var v))
            resultView.text = $"Encontrado: [{k}] = {v}";
        else
            resultView.text = $"No existe la clave: {k}";
    }

    public void Remove()
    {
        string k = inputKey.text.Trim();
        if (string.IsNullOrEmpty(k)) return;

        bool removed = dict.Remove(k);
        resultView.text = removed ? $"Eliminado: {k}" : $"No se pudo eliminar (no existe): {k}";
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
        sb.AppendLine("DICCIONARIO (Clave → Valor)");

        foreach (var kv in dict)
            sb.AppendLine($"• {kv.Key} → {kv.Value}");

        dictView.text = sb.ToString();
    }
}