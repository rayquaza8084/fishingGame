using UnityEngine;
public class SettingsShit : MonoBehaviour
{
    [Tooltip("Vsync overrides Target Frame Rate")]
    [SerializeField] private bool VSyncON = false;
    [SerializeField] private int TargetFrameRate = 60;
    

    void Awake()
    {
        if (VSyncON)
        {
            QualitySettings.vSyncCount = 1;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }

        Application.targetFrameRate = TargetFrameRate;
        

    }
}
