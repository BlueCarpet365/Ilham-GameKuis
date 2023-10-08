using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_OpsiLevelKuis : MonoBehaviour
{
    public static event System.Action<int> EventSaatKlik;
    [SerializeField] private Button _tombolLevel;
    [SerializeField] private TextMeshProUGUI _levelName;
    [SerializeField] private LevelSoalKuis _levelKuis;
    
    public bool InteraksiTombol
    {
        get => _tombolLevel.interactable;
        set => _tombolLevel.interactable = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (_levelKuis != null)
            SetLevelKuis(_levelKuis, _levelKuis.levelPackIndex);

        _tombolLevel.onClick.AddListener(SaatKlik);
    }

    private void OnDestroy()
    {
        _tombolLevel.onClick.RemoveListener(SaatKlik);
    }

    public void SetLevelKuis(LevelSoalKuis levelKuis, int index)
    {
        _levelName.text = levelKuis.name;
        _levelKuis = levelKuis;
        _levelKuis.levelPackIndex = index;
    }

    private void SaatKlik()
    {
        EventSaatKlik?.Invoke(_levelKuis.levelPackIndex);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
