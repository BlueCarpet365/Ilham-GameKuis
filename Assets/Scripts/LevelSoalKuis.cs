using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
    fileName = "Soal Baru",
    menuName = "Trivia Game/Level Soal Trivia")]

public class LevelSoalKuis : ScriptableObject
{
    [System.Serializable]
    public struct OpsiJawaban
    {
        public string jawabanTeks;
        public bool adalahBenar;
    }

    public string pertanyaan;
    public Sprite petunjukJawaban;

    public OpsiJawaban[] opsiJawaban = new OpsiJawaban[0];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
