using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class OptionsMenu : MonoBehaviour
{
    public GameObject[] Tabs; //Кнопки для переключения раздела настроек

    Resolution[] resolutions;

    public TMPro.TMP_Dropdown resolutionDropdown;
    // Start is called before the first frame update
    void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height + ", " + resolutions[i].refreshRate + "Hz";
            options.Add(option);

            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }


    //_________________________________\\
    public void SwitchTabs(int TabID) //Функция смены раздела настроек
    {
        foreach (GameObject go in Tabs) //Для каждого неактивного раздела и кнопки раздела: если раздел неактивный, то кнопка раздела меняет текстуру на неактивную, а окно настроек скрывается
        {
            go.SetActive(false); //Окно настроек раздела скрывается
        }

        Tabs[TabID].SetActive(true); //Раздел становится активным
    }


    public void setResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
}
