using System;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace Assignment.UtilityScripts
{
    [RequireComponent(typeof(TMP_Text))]
    public class SavedVariableText : MonoBehaviour
    {
        private TMP_Text _tmpText;

        [SerializeField]
        private SavedVariableType variableType;

        [SerializeField] private string key;
        [SerializeField] private string prefix;
        [SerializeField] private string suffix;
        
        private void Awake()
        {
            _tmpText = GetComponent<TMP_Text>();
        }

        private void Start()
        {
            UpdateText();
        }

        [UsedImplicitly]
        public void UpdateText()
        {
            switch (variableType)
            {
                case SavedVariableType.Int:
                    _tmpText.SetText($"{prefix}{SavedVariables.GetInt(key, 0).ToString()}{suffix}");
                    break;
                case SavedVariableType.Float:
                    _tmpText.SetText($"{prefix}{SavedVariables.GetFloat(key, 0f).ToString()}{suffix}");
                    break;
                case SavedVariableType.String:
                    _tmpText.SetText($"{prefix}{SavedVariables.GetString(key, "")}{suffix}");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}