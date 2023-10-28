using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject popupBtn, itemWindow ,miniMap ,map,jukeBox;
    public TextMeshProUGUI coinCnt, potionCnt, keyCnt,candyCnt , cakeCnt, giftCnt;
    public bool isMapOpen = false;

    private void Awake()
    {
        Instance = this;
        popupBtn.SetActive(true);
        itemWindow.SetActive(false);
        miniMap.SetActive(true);
        map.SetActive(false);
        jukeBox.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            popupBtn.SetActive(!popupBtn.activeInHierarchy);
            itemWindow.SetActive(!itemWindow.activeInHierarchy);  //렬려있으면 닫고 닫혀있으면 연다.
            ItemRefresh(); //창을 열때마다 아이템 갯수 UI갱신
        }
        if(Input .GetKeyDown(KeyCode.M))
        {
            miniMap.SetActive(!miniMap.activeInHierarchy);
            map.SetActive(!miniMap.activeInHierarchy);
            isMapOpen = miniMap.activeInHierarchy;
        }

        if(Input .GetKeyDown(KeyCode.J))
        {
            jukeBox.SetActive(!jukeBox.activeInHierarchy);

        }
    }

    public void ItemRefresh()
    {
        if(!itemWindow.activeInHierarchy)//아이템 창이 닫혀있으면 아래 내용 부시하고 리턴
        {
            return;
        }
            coinCnt.text = UserData.coinCount.ToString("D2"); // 변수를 문자열 두자리로 바꾸는 방법1
            potionCnt.text = $"{UserData.pointCount:00}";  // 변수를 문자열 두자리로 바꾸는 방법2
            keyCnt.text = UserData.keyCount.ToString("D2"); // 변수를 문자열 두자리로 바꾸는 방법3
            candyCnt.text = UserData.candyCount.ToString("D2");
            cakeCnt.text = UserData.cakeCount.ToString("D2");
            giftCnt.text = UserData.giftCount.ToString("D2");
            

           //$"{첫번째변수:00} :{두번째 변수:00} : {세번째변수:00}"
           //string.Format("{0:00}:{1:00} : {2:00}" ,0에 들어갈거,1에 들어갈것,3에 들어갈거)
           //간단한건 ToString()쓰고,복잡하게 변수 여러개 쓸땐$""을 쓰는게 좋다.
    }
}
