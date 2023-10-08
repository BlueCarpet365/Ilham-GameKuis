using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private InisialDataGameplay _inisialData;
    [SerializeField] private PlayerProgress _playerProgress;
    [SerializeField] private LevelPackKuis _soalSoal;
    [SerializeField] private UI_Pertanyaan _pertanyaan = null;
    [SerializeField] private UI_PoinJawaban[] _pilihanJawaban = new UI_PoinJawaban[0];
    [SerializeField] private GameSceneManager _gameSceneManager;
    [SerializeField] private string _namaScenePilihMenu = string.Empty;
    private int _indexSoal = 0;

    // Start is called before the first frame update
    void Start()
    {
        //if (!_playerProgress.MuatProgress())
        //{
        //    _playerProgress.SimpanProgress();
        //}

        _soalSoal = _inisialData.levelPack;
        _indexSoal = _inisialData.levelIndex - 1;

        NextLevel();
        UI_PoinJawaban.EventJawabSoal += UI_PoinJawaban_EventJawabSoal;
    }

    private void OnDestroy()
    {
        UI_PoinJawaban.EventJawabSoal -= UI_PoinJawaban_EventJawabSoal;
    }

    private void UI_PoinJawaban_EventJawabSoal(string jawaban, bool adalahBenar)
    {
        if (adalahBenar)
        {
            _playerProgress.progressData.koin += 10;
        }
    }

    private void OnApplicationQuit()
    {
        _inisialData.SaatKalah = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextLevel()
    {
        _indexSoal++;

        if(_indexSoal >= _soalSoal.BanyakLevel)
        {
            //_indexSoal = 0;
            _gameSceneManager.BukaScene(_namaScenePilihMenu);
            return;
        }

        LevelSoalKuis soal = _soalSoal.AmbilLevelKe(_indexSoal);

        _pertanyaan.SetPertanyaan($"Soal {_indexSoal + 1}", soal.pertanyaan, soal.petunjukJawaban);

        for(int i = 0; i < _pilihanJawaban.Length; i++)
        {
            UI_PoinJawaban poin = _pilihanJawaban[i];
            LevelSoalKuis.OpsiJawaban opsi = soal.opsiJawaban[i];
            poin.SetJawaban(opsi.jawabanTeks, opsi.adalahBenar);
        }
    }

}
