using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.IO;           // Input, Output �ǹ̷� ���� ������ Ȱ��
using UnityEngine.UI;           // UI ĵ���� Ȱ��
using UnityEngine.Networking;   // ��Ʈ��ũ Ȱ��

// ã�ƺ���
// ��ũ��Ʈ�� �̹��� �����ϱ�
// ������ �̹��� ��ũ��Ʈ���� ã��
// �ٿ���� �̹��� ���ö���Ʈ �����ϱ�
// �ٿ���� �̹��� ��Ŭ����Ʈ �ִ��� �Ǵ��ϱ�
// �ٿ���� �̹��� ��Ŭ����Ʈ ���� or ���ΰ�ħ

// ������ url �ּ� ���� ���� �̹��� ��ü�ϴ� ���
// (����)��α׿��� �������� �ø��� ���� �ٿ�ε� �ް� ���Ϸ� �ø��� �������� �����߻�

// ���� �������� ���� �ø��� �ٿ�ޱ�

public class UnitySeverTest : MonoBehaviour
{
    //Image testImage = GameObject.Find("SeverTestImage").GetComponent<Image>();
    public Image testImage;

    string nowURL;
    string url_01 = "https://postfiles.pstatic.net/MjAyMjEyMTdfMjM0/MDAxNjcxMjM3NDQ1MTg3.fyxiglWN612sK0s5sjiSviWpe4pUdr03p1wi0KpP0bkg.ke0puuOZmsW-hey_Bzzz4jIucJy22am-K0rkclskmSEg.PNG.kchanghun/UnityServerTest_01.png?type=w773";
    string url_02 = "https://postfiles.pstatic.net/MjAyMjEyMTdfMjQ5/MDAxNjcxMjM3NDQ1MTg5.q7a4u8x-PHFaVzKAsstO3PwRcy9XFmbgQpoyyJQq2Kwg.u2er7D-AKEHN2D5lYc5lOxcrMzPMl3PQuz6RijTUq4Qg.PNG.kchanghun/UnityServerTest_02.png?type=w773";
    string url_03 = "https://postfiles.pstatic.net/MjAyMjEyMTdfMjU3/MDAxNjcxMjM3NDQ1MTky.nEsv2eyS_nrrdHXWNEEhMSkXnk9ifogwAX136RlfyM0g.OS3-p2Nic0y8hTmbtIZqJxBMzZ6HOF34cOJvKwtUTrAg.PNG.kchanghun/UnityServerTest_03.png?type=w773";

    void Start()
    {
        nowURL = url_01;
        StartCoroutine(TextureLoad(nowURL));
    }

    IEnumerator TextureLoad(string url)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);

        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            print(www.error);
        }
        else
        {
            float imageWidth = ((DownloadHandlerTexture)www.downloadHandler).texture.width;
            float imageHeight = ((DownloadHandlerTexture)www.downloadHandler).texture.height;
            Rect rect = new Rect(0, 0, imageWidth, imageHeight);
            testImage.sprite = Sprite.Create(((DownloadHandlerTexture)www.downloadHandler).texture, rect, new Vector2());
        }
    }

    public void ImageChange()
    {
        if (nowURL == url_01)
        {
            nowURL = url_02;
            StartCoroutine(TextureLoad(nowURL));
        }
        else if (nowURL == url_02)
        {
            nowURL = url_03;
            StartCoroutine(TextureLoad(nowURL));
        }
        else
        {
            nowURL = url_01;
            StartCoroutine(TextureLoad(nowURL));
        }
    }
}
