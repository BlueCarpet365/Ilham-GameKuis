using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_LevelKuisList : MonoBehaviour
{
    [SerializeField] private InisialDataGameplay _inisialData;
    [SerializeField] private UI_OpsiLevelKuis _tombolLevel;
    [SerializeField] private RectTransform _content;
    [SerializeField] private LevelPackKuis _levelPack;
    [SerializeField] private GameSceneManager _gameSceneManager;
    [SerializeField] private string _gameplayScene;

    // Start is called before the first frame update
    void Start()
    {
        //if(_levelPack != null)
        //{
        //    UnloadlevelPack(_levelPack);
        //}
        UI_OpsiLevelKuis.EventSaatKlik += UI_OpsiLevelKuis_EventSaatKlik;
    }

    private void OnDestroy()
    {
        UI_OpsiLevelKuis.EventSaatKlik -= UI_OpsiLevelKuis_EventSaatKlik;
    }

    private void UI_OpsiLevelKuis_EventSaatKlik(int index)
    {
        _inisialData.levelIndex = index;
        _gameSceneManager.BukaScene(_gameplayScene);
    }

    public void UnloadlevelPack(LevelPackKuis levelPack)
    {
        HapusIsiKonten();
        _levelPack = levelPack;
        for(int i = 0; i < levelPack.BanyakLevel; i++)
        {
            var t = Instantiate(_tombolLevel);
            t.SetLevelKuis(levelPack.AmbilLevelKe(i), i);
            t.transform.SetParent(_content);
            t.transform.localScale = Vector3.one;
        }
    }

    private void HapusIsiKonten()
    {
        var cc = _content.childCount;

        for (int i = 0; i < cc; i++)
        {
            Destroy(_content.GetChild(i).gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
