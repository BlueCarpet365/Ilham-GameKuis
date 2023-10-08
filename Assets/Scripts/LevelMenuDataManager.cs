using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelMenuDataManager : MonoBehaviour
{
    [SerializeField] private UI_LevelPackList _levelPackList;
    [SerializeField] private PlayerProgress _playerProgress;
    [SerializeField] private TextMeshProUGUI _tempatKoin;
    [SerializeField] private LevelPackKuis[] _levelPacks = new LevelPackKuis[0];

    // Start is called before the first frame update
    void Start()
    {
        if (!_playerProgress.MuatProgress())
        {
            _playerProgress.SimpanProgress();
        }

        _levelPackList.LoadlevelPack(_levelPacks, _playerProgress.progressData);

        _tempatKoin.text = $"{_playerProgress.progressData.koin}"; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
