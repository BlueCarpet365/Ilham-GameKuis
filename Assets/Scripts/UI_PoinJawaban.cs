using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_PoinJawaban : MonoBehaviour
{
    public static event System.Action<string, bool> EventJawabSoal;
    //[SerializeField] private UI_PesanLevel _tempatPesan;
    [SerializeField] private TextMeshProUGUI _teksJawaban = null;
    [SerializeField] private bool _adalahBenar = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PilihJawaban()
    {
        //Debug.Log($"{_teksJawaban.text} Adalah {_adalahBenar}");
        //_tempatPesan.Pesan = $"{_teksJawaban.text} Adalah {_adalahBenar}";
        EventJawabSoal?.Invoke(_teksJawaban.text, _adalahBenar);
    }

    public void SetJawaban(string teksJawaban, bool adalahBenar)
    {
        _teksJawaban.text = teksJawaban;
        _adalahBenar = adalahBenar;
    }
}