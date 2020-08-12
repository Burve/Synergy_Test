using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Language", menuName = "Scriptable/Languages")]
public class Language : ScriptableObject
{
    public LanguageEnum CurrentLanguage;
    public List<LocalizationData> Localization;
}
