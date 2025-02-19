using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    //Fisicas
    public static GameController instance;
    public GameObject GameOverTexto, InsigniaBronce, InsigniaPlata, InsigniaOro, EstrellaBronce, EstrellaPlata, EstrellaOro;
    public TextMeshProUGUI ScoreText, ScoreMaxText, ScoreRondaText;
    public GameObject SonidoPunto;

    //Variables Globales
    public bool GameOver;

    public float VelocidadObjetos = -1.5f;

    private int Score = 0;
    private int ScoreRonda;
    private int ScoreMax;

    public string ScoreRondaPrefsName = "ScoreRonda";
    public string ScoreMaxPrefsName = "ScoreMax";

    // Se llama a Start antes de la actualización del primer cuadro
    void Start()
    {
        ScoreRondaText.text = ScoreRonda.ToString();
        ScoreMaxText.text = ScoreMax.ToString();
        Medallas();

    }

    // La actualización se llama una vez por cuadro
    void Update()
    {
        if (GameOver && Input.GetMouseButtonDown(0))
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("Leaderboards");
            ScoreRondaText.text = ScoreRonda.ToString();
            ScoreMaxText.text = ScoreMax.ToString();
            Medallas();
        }
    }

    public void MurcielagoMuerto()
    {
        GameOverTexto.SetActive(true);
        GameOver = true;
        ScoreRonda = Score;
    }

    private void Awake()
    {
        LoadData();
        if (GameController.instance == null)
        {
            GameController.instance = this;
        }
        else if(GameController.instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        SaveData();
        if(GameController.instance == this)
        {
            GameController.instance = null;
        }
    }

    public void MurcielagoScore()
    {
        if (GameOver) return;
        Score++;
        ScoreRonda = Score;
        if (Score > ScoreMax)
        {
            ScoreMax = Score;
        }
        ScoreText.text = Score.ToString();
        Instantiate(SonidoPunto);
    }

    public void BotonStart()
    {
        SceneManager.LoadScene("Juego");
    }

    public void BotonLeaderboard()
    {
        SceneManager.LoadScene("Leaderboards");
        Medallas();
    }

    public void BotonSalir()
    {
        SceneManager.LoadScene("Menus");
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt(ScoreRondaPrefsName, ScoreRonda);
        PlayerPrefs.SetInt(ScoreMaxPrefsName, ScoreMax);
    }

    public void LoadData()
    {
        ScoreRonda = PlayerPrefs.GetInt(ScoreRondaPrefsName, 0);
        ScoreMax = PlayerPrefs.GetInt(ScoreMaxPrefsName, 0);
    }

    public void Medallas()
    {
        if(ScoreRonda >= 10 && ScoreRonda <= 24)
        {
            InsigniaBronce.SetActive(true);
        }
        else if(ScoreRonda >= 25 && ScoreRonda <= 49)
        {
            InsigniaPlata.SetActive(true);
        }
        else if(ScoreRonda >= 50 && ScoreRonda <= 99)
        {
            InsigniaOro.SetActive(true);
        }
        else if (ScoreRonda >= 100 && ScoreRonda <= 149)
        {
            InsigniaOro.SetActive(true);
            EstrellaBronce.SetActive(true);
        }
        else if (ScoreRonda >= 150 && ScoreRonda <= 199)
        {
            InsigniaOro.SetActive(true);
            EstrellaPlata.SetActive(true);
        }
        else if (ScoreRonda >= 200)
        {
            InsigniaOro.SetActive(true);
            EstrellaOro.SetActive(true);
        }
    }
}
