using UnityEngine;
using System.Collections;

public class DonDestroy : MonoBehaviour
{
    private static DonDestroy s_Instance = null;

    void Awake()
    {
        if (s_Instance)
        {
            DontDestroyOnLoad(this.gameObject);
            return;
        }

        s_Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
}
