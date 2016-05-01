using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;

public class MENU : MonoBehaviour
{

    public Button PlayButton, OptionsButton, ExitButton;
    [Space(20)]
    public Slider VolumeBar;
    public Toggle BoxWindowMode;
    public Dropdown Resolutions, Quality;
    public Button BackButton, SavePrefButton;
    [Space(20)]
    public Text textVol;
    public string gameSceneName = "batman";
    private string sceneName;
    private float VOLUME;
    private int grapQuality, windowModeActive, resSaveIndex;
    private bool fullscreenActive;
    private Resolution[] SuppResolutions;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        SuppResolutions = Screen.resolutions;
    }

    void Start()
    {
        Options(false);
        ResCheck();
        AdjustQuality();
        //
        sceneName = SceneManager.GetActiveScene().name;
        Cursor.visible = true;
        Time.timeScale = 1;
        //
        VolumeBar.minValue = 0;
        VolumeBar.maxValue = 1;

        //=============== SAVES===========//
        if (PlayerPrefs.HasKey("VOLUME"))
        {
            VOLUME = PlayerPrefs.GetFloat("VOLUME");
            VolumeBar.value = VOLUME;
        }
        else
        {
            PlayerPrefs.SetFloat("VOLUME", 1);
            VolumeBar.value = 1;
        }
        //=============WINDOWS MODE===========//
        if (PlayerPrefs.HasKey("windowMode"))
        {
            windowModeActive = PlayerPrefs.GetInt("windowMode");
            if (windowModeActive == 1)
            {
                Screen.fullScreen = false;
                BoxWindowMode.isOn = true;
            }
            else
            {
                Screen.fullScreen = true;
                BoxWindowMode.isOn = false;
            }
        }
        else
        {
            windowModeActive = 0;
            PlayerPrefs.SetInt("windowMode", windowModeActive);
            BoxWindowMode.isOn = false;
            Screen.fullScreen = true;
        }
        //========RESOLUTIONS========//
        if (windowModeActive == 1)
        {
            fullscreenActive = false;
        }
        else
        {
            fullscreenActive = true;
        }
        if (PlayerPrefs.HasKey("RESOLUTION"))
        {
            resSaveIndex = PlayerPrefs.GetInt("RESOLUTION");
            Screen.SetResolution(SuppResolutions[resSaveIndex].width, SuppResolutions[resSaveIndex].height, fullscreenActive);
            Resolutions.value = resSaveIndex;
        }
        else
        {
            resSaveIndex = (SuppResolutions.Length - 1);
            Screen.SetResolution(SuppResolutions[resSaveIndex].width, SuppResolutions[resSaveIndex].height, fullscreenActive);
            PlayerPrefs.SetInt("RESOLUTION", resSaveIndex);
            Resolutions.value = resSaveIndex;
        }
        //=========QUALITY=========//
        if (PlayerPrefs.HasKey("grapQuality"))
        {
            grapQuality = PlayerPrefs.GetInt("grapQuality");
            QualitySettings.SetQualityLevel(grapQuality);
            Quality.value = grapQuality;
        }
        else
        {
            QualitySettings.SetQualityLevel((QualitySettings.names.Length - 1));
            grapQuality = (QualitySettings.names.Length - 1);
            PlayerPrefs.SetInt("grapQuality", grapQuality);
            Quality.value = grapQuality;
        }

        // =========SETING BUTTONS==========//
        PlayButton.onClick = new Button.ButtonClickedEvent();
        OptionsButton.onClick = new Button.ButtonClickedEvent();
        ExitButton.onClick = new Button.ButtonClickedEvent();
        BackButton.onClick = new Button.ButtonClickedEvent();
        SavePrefButton.onClick = new Button.ButtonClickedEvent();
        PlayButton.onClick.AddListener(() => Play());
        OptionsButton.onClick.AddListener(() => Options(true));
        ExitButton.onClick.AddListener(() => Exit());
        BackButton.onClick.AddListener(() => Options(false));
        SavePrefButton.onClick.AddListener(() => PrefSave());
    }
    //=========CHECKING VOIDS==========//
    private void ResCheck()
    {
        Resolution[] SuppResolutions = Screen.resolutions;
        Resolutions.options.Clear();
        for (int y = 0; y < SuppResolutions.Length; y++)
        {
            Resolutions.options.Add(new Dropdown.OptionData() { text = SuppResolutions[y].width + "x" + SuppResolutions[y].height });
        }
        Resolutions.captionText.text = "RESOLUTION";
    }
    private void AdjustQuality()
    {
        string[] nomes = QualitySettings.names;
        Quality.options.Clear();
        for (int y = 0; y < nomes.Length; y++)
        {
            Quality.options.Add(new Dropdown.OptionData() { text = nomes[y] });
        }
        Quality.captionText.text = "Qualidade";
    }
    private void Options(bool ativarOP)
    {
        PlayButton.gameObject.SetActive(!ativarOP);
        OptionsButton.gameObject.SetActive(!ativarOP);
        ExitButton.gameObject.SetActive(!ativarOP);
        //
        textVol.gameObject.SetActive(ativarOP);
        VolumeBar.gameObject.SetActive(ativarOP);
        BoxWindowMode.gameObject.SetActive(ativarOP);
        Resolutions.gameObject.SetActive(ativarOP);
        Quality.gameObject.SetActive(ativarOP);
        BackButton.gameObject.SetActive(ativarOP);
        SavePrefButton.gameObject.SetActive(ativarOP);
    }
    //=======SAVING VOIDS========//
    private void PrefSave()
    {
        if (BoxWindowMode.isOn == true)
        {
            windowModeActive = 1;
            fullscreenActive = false;
        }
        else
        {
            windowModeActive = 0;
            fullscreenActive = true;
        }
        PlayerPrefs.SetFloat("VOLUME", VolumeBar.value);
        PlayerPrefs.SetInt("grapQuality", Quality.value);
        PlayerPrefs.SetInt("windowMode", windowModeActive);
        PlayerPrefs.SetInt("RESOLUTION", Resolutions.value);
        resSaveIndex = Resolutions.value;
        AplicarPreferencias();
    }
    private void AplicarPreferencias()
    {
        VOLUME = PlayerPrefs.GetFloat("VOLUME");
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("grapQuality"));
        Screen.SetResolution(SuppResolutions[resSaveIndex].width, SuppResolutions[resSaveIndex].height, fullscreenActive);
    }
    //===========NORMAL VOIDS=========//
    void Update()
    {
        if (SceneManager.GetActiveScene().name != sceneName)
        {
            AudioListener.volume = VOLUME;
            Destroy(gameObject);
        }
    }
    private void Play()
    {
        SceneManager.LoadScene(gameSceneName);
    }
    private void Exit()
    {
        Application.Quit();
    }
}