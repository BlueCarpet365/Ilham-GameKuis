using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Timer : MonoBehaviour
{
    [SerializeField] private UI_PesanLevel _tempatPesan;
    [SerializeField] private Slider _timeBar;
    [SerializeField] private float _waktuJawab = 30f;
    private float _sisaWaktu = 0f;
    private bool _waktuBerjalan = true;

    // Start is called before the first frame update

    public bool WaktuBerjalan
    {
        get => _waktuBerjalan;
        set => _waktuBerjalan = value;
    }

    private void Start()
    {
        UlangWaktu();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!_waktuBerjalan)
            return;

        _sisaWaktu -= Time.deltaTime;
        _timeBar.value = _sisaWaktu / _waktuJawab;
        
        if(_sisaWaktu <= 0f)
        {
            _tempatPesan.Pesan = "You ran out of time!";
            _tempatPesan.gameObject.SetActive(true);
            Debug.Log("You ran out of time!");
            _waktuBerjalan = false;
            return;
        }

        //Debug.Log(_sisaWaktu);
    }

    public void UlangWaktu()
    {
        _sisaWaktu = _waktuJawab;
    }
}
