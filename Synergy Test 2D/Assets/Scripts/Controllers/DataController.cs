using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DataController : MonoSingleton<DataController>
{
    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public string GetLocalizedString(LocalizationStrings str)
    {
        var result = "???";

        if (_currentLanguageData == null)
        {
            _currentLanguageData = _allLanguagesData.FirstOrDefault(x => x.CurrentLanguage == _activeLanguage);
            if (_currentLanguageData == null)
            {
                _currentLanguageData = _defaultLanguageData;
            }
        }

        if (_currentLanguageData != null)
        {
            var local = _currentLanguageData.Localization.FirstOrDefault(x => x.LocalizationType == str);
            if (local == null)
            {
                local = _defaultLanguageData.Localization.FirstOrDefault(x => x.LocalizationType == str);
            }

            if (local != null)
            {
                result = local.Data;
            }
            else
            {
                Debug.LogError(string.Format("!!! ERROR finding localization for {0} !!!",str));
            }
        }

        return result;
    }

    #region Fields

    [SerializeField]
    private Camera _mainCamera;

    [SerializeField]
    private LanguageEnum _activeLanguage;

    [SerializeField]
    private Language _defaultLanguageData;

    [SerializeField]
    private List<Language> _allLanguagesData;

    private Language _currentLanguageData = null;

    #endregion

    #region Properties

    public Camera MainCamera => _mainCamera;

    #endregion
}
