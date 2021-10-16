using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsManager : MonoBehaviour
{
    [SerializeField] private GameObject _UI;
    [SerializeField] private GameObject _options;
    [SerializeField] private TextButtonOpt _textButtonOpt;

    public void ShowOptions()
    {
        _UI.SetActive(false);
        _options.SetActive(true);
    }

    public void HideOptions()
    {
        _textButtonOpt.DeleteTextSelect();
        _UI.SetActive(true);
        _options.SetActive(false);
    }
}
