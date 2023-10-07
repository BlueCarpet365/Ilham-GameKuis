using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_OpsiLevelPack : MonoBehaviour
{
    public static event System.Action<LevelPackKuis> EventSaatKlik;
    [SerializeField] Button _tombol;
    [SerializeField] private TextMeshProUGUI _packName;
    [SerializeField] private LevelPackKuis _levelPack;
    // Start is called before the first frame update
    void Start()
    {
        if (_levelPack != null)
            SetLevelPack(_levelPack);

        _tombol.onClick.AddListener(SaatKlik);
    }

    private void OnDestroy()
    {
        _tombol.onClick.RemoveListener(SaatKlik);
    }

    public void SetLevelPack(LevelPackKuis levelPack)
    {
        _packName.text = levelPack.name;
        _levelPack = levelPack;
    }

    private void SaatKlik()
    {
        //Debug.Log("yay!!!!!!");
        EventSaatKlik?.Invoke(_levelPack);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
