using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelMenuDataManager : MonoBehaviour
{
    [SerializeField] private PlayerProgress _playerProgress;
    [SerializeField] private TextMeshProUGUI _tempatKoin;

    // Start is called before the first frame update
    void Start()
    {
        _tempatKoin.text = $"{_playerProgress.progressData.koin}"; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
