using UnityEngine;
using System.Collections.Generic;

public class DataKeeper : MonoBehaviour
{
    // Provides a public interface to add object data from the editor
    [SerializeField]
    private List<string> _editorKeys = new List<string>();
    [SerializeField]
    private List<string> _editorValues = new List<string>();
    // Provides an internal list of arbitrary data that we'll be storing
    private Dictionary<string, string> _data = new Dictionary<string, string>();

    private void Awake()
    {
        Debug.Assert(_editorKeys.Count == _editorValues.Count);

        AddDataFromEditor();
    }

    private void AddDataFromEditor()
    {
        for (int i = 0; i < _editorKeys.Count; i++)
        {
            AddData(_editorKeys[i], _editorValues[i]);
        }
    }

    public string GetData(string key)
    {
        return _data[key];
    }

    public void AddData(string key, string value)
    {
        _data.Add(key, value);
    }

    public void RemoveData(string key)
    {
        _data.Remove(key); 
    }

    public void ReplaceData(string key, string value)
    {
        _data[key] = value;
    }
}