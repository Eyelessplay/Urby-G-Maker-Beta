using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Pause : MonoBehaviour
{
    public int resWidth = 3550;
    public int resHeight = 3550;

    private bool takeHiResShot = false;
    private bool paused;

    public static string ScreenShotName(int width, int height)
    {
        return string.Format("{0}/screenshots/sceen_{1}x{2}_{3}.png", Application.dataPath, width, height, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
    }
    public void TakeHiResShot()
    {
        takeHiResShot = true;
    }
    private void LateUpdate()
    {
        takeHiResShot |= Input.GetKeyDown("k");
        if (takeHiResShot)
        {
            RenderTexture rt = new RenderTexture(resWidth, resHeight, 24);
            Camera.main.targetTexture = rt;
            Texture2D sceenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
            Camera.main.Render();
            RenderTexture.active = rt;
            sceenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
            Camera.main.targetTexture = null;
            RenderTexture.active = null;
            Destroy(rt);
            byte[] bytes = sceenShot.EncodeToPNG();
            string filename = ScreenShotName(resWidth, resHeight);
            System.IO.File.WriteAllBytes(filename, bytes);
            Debug.Log(string.Format("Took screenshot to: {0}", filename));
            takeHiResShot = false;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
        }
        if(paused)
        {
            ActivatePause();
        }
        else
        {
            DesactivatePause();
        }
    }
    public void ActivatePause()
    {
        Time.timeScale = 0;

    }
    public void DesactivatePause()
    {
        Time.timeScale = 1;

    }
}
