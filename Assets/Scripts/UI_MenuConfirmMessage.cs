using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MenuConfirmMessage : MonoBehaviour
{
    [SerializeField] private PlayerProgress _playerProgress;
    [SerializeField] private GameObject _pesanCukupKoin;
    [SerializeField] private GameObject _pesanTakCukupKoin;

    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.activeSelf)
            gameObject.SetActive(false);

        UI_OpsiLevelPack.EventSaatKlik += UI_OpsiLevelPack_EventSaatKlik;
    }

    private void OnDestroy()
    {
        UI_OpsiLevelPack.EventSaatKlik -= UI_OpsiLevelPack_EventSaatKlik;
    }

    private void UI_OpsiLevelPack_EventSaatKlik(LevelPackKuis levelPack, bool terkunci)
    {
        if (!terkunci) return;

        gameObject.SetActive(true);

        if(_playerProgress.progressData.koin < levelPack.Harga)
        {
            _pesanCukupKoin.SetActive(false);
            _pesanTakCukupKoin.SetActive(true);
            return;
        }

        _pesanTakCukupKoin.SetActive(false);
        _pesanCukupKoin.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
