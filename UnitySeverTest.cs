using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.IO;           // Input, Output 의미로 파일 관리시 활용
using UnityEngine.UI;           // UI 캔버스 활용
using UnityEngine.Networking;   // 네트워크 활용

// 찾아보기
// 스크립트로 이미지 생성하기
// 생성한 이미지 스크립트에서 찾기
// 다운받은 이미지 스플라이트 저장하기
// 다운받은 이미지 스클리이트 있는지 판단하기
// 다운받은 이미지 스클리아트 삭제 or 새로고침

// 웹에서 url 주소 변경 없이 이미지 교체하는 방법
// (참고)블로그에서 사진으로 올리면 빨리 다운로드 받고 파일로 올리면 랜덤으로 오류발생

// 웹에 여러가지 파일 올리고 다운받기

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
