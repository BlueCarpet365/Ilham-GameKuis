using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Pertanyaan : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _tempatJudul;
    [SerializeField] private TextMeshProUGUI _tempatTeks;
    [SerializeField] private Image _tempatGambar;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(_tempatTeks.text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPertanyaan(string judul, string teksPertanyaan, Sprite gambarHint)
    {
        _tempatJudul.text = judul;
        _tempatTeks.text = teksPertanyaan;
        _tempatGambar.sprite = gambarHint;
    }
}
