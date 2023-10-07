using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
    fileName = "Inisial Data Gameplay",
    menuName = "Trivia Game/Inisial Data Gameplay")]

public class InisialDataGameplay : ScriptableObject
{
    public LevelPackKuis levelPack;
    public int levelIndex = 0;
    [SerializeField] private bool _saatKalah = false;

    public bool SaatKalah
    {
        get => _saatKalah;
        set => _saatKalah = value;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
