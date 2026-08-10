using UnityEngine;
public class SettingsShit : MonoBehaviour
{
    [SerializeField] private int TargetFrameRate = 60;
    [Tooltip("Vsync overrides Target Frame Rate")]
    [SerializeField] private bool VSyncON = false;

    void Awake()
    {
        Application.targetFrameRate = TargetFrameRate;
        if (VSyncON)
        {
            QualitySettings.vSyncCount = 1;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }

    }
}
