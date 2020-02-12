using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Loadscene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1024, 600, false);//设置屏幕固定大小
        Invoke("Loading", 2);
    }

    private void Loading()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
