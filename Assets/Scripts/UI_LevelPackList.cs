using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_LevelPackList : MonoBehaviour
{
    [SerializeField] private InisialDataGameplay _inisialData;
    [SerializeField] private UI_LevelKuisList _levelList;
    [SerializeField] private UI_OpsiLevelPack _tombolLevelPack;
    [SerializeField] private RectTransform _content;
    [SerializeField] private LevelPackKuis[] _levelPacks = new LevelPackKuis[0];

    // Start is called before the first frame update
    void Start()
    {
        LoadlevelPack();

        if (_inisialData.SaatKalah)
        {
            UI_OpsiLevelPack_EventSaatKlik(_inisialData.levelPack);
        }

        UI_OpsiLevelPack.EventSaatKlik += UI_OpsiLevelPack_EventSaatKlik;
    }

    private void OnDestroy()
    {
        UI_OpsiLevelPack.EventSaatKlik -= UI_OpsiLevelPack_EventSaatKlik;
    }

    private void UI_OpsiLevelPack_EventSaatKlik(LevelPackKuis levelPack)
    {
        _levelList.gameObject.SetActive(true);
        _levelList.UnloadlevelPack(levelPack);
        gameObject.SetActive(false);
        _inisialData.levelPack = levelPack;

    }

    private void LoadlevelPack()
    {
        foreach(var lp in _levelPacks)
        {
            var t = Instantiate(_tombolLevelPack);
            t.SetLevelPack(lp);
            t.transform.SetParent(_content);
            t.transform.localScale = Vector3.one;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
