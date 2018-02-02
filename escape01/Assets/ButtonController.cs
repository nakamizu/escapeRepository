using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class ButtonController : BaseButtonController
{
    public Camera mainCamera;
    public Camera wiiCamera;
    public Camera trashBoxCamera;
    public Camera potatoCamera;
    public Camera doorCamera;
    public Camera deskCamera;
    public Camera pigCamera;
    public Camera underSofaCamera;
    public Camera monitorCamera;
    public Camera wallCamera;
    public Camera itemListCamera;
    public GameObject item_key;
    public GameObject item_paper;
    public GameObject item_fiveyen;
    public GameObject item_goldcoin;
    public GameObject item_goldcoin2;
    public GameObject itemlist_key;
    public GameObject itemlist_paperkey;
    public GameObject itemlist_paper;
    public GameObject itemlist_fiveyen;
    public GameObject itemlist_goldcoin;
    public GameObject itemlist_goldcoin2;

    private AudioSource ok2a;
    private AudioSource doordondon;
    private AudioSource dooropen;
    private AudioSource printer;
    private AudioSource decision;
    private AudioSource money;

    string position;
    int paperFlag;
    int keyFlag;
    int deleteFlag;
    int fiveyenFlag;
    int goldcoinFlag;
    int goldcoin2Flag;
    int itemflag1, itemflag2, itemflag3, itemflag4, itemflag5;
    int collectflag;
    int i;

    void Start()
    {
        wiiCamera.enabled = false;
        trashBoxCamera.enabled = false;
        potatoCamera.enabled = false;
        doorCamera.enabled = false;
        deskCamera.enabled = false;
        pigCamera.enabled = false;
        underSofaCamera.enabled = false;
        pigCamera.enabled = false;
        wallCamera.enabled = false;
        item_key = GameObject.Find("Keys");
        item_paper = GameObject.Find("paper");
        item_fiveyen = GameObject.Find("fiveyen");
        item_goldcoin = GameObject.Find("goldcoin");
        item_goldcoin2 = GameObject.Find("goldcoin2");
        itemlist_key = GameObject.Find("itemBoxKeys");
        itemlist_paper = GameObject.Find("itemPaper");
        itemlist_paperkey = GameObject.Find("itemPaperKey");
        itemlist_fiveyen = GameObject.Find("itemBoxFiveYen");
        itemlist_goldcoin = GameObject.Find("itemBoxGoldCoin");
        itemlist_goldcoin2 = GameObject.Find("itemBoxGoldCoin2");

        position = "main";
        deleteFlag = 0;
        itemflag1 = 0;
        itemflag2 = 0;
        itemflag3 = 0;
        itemflag4 = 0;
        itemflag5 = 0;
        collectflag = 0;
        i = 0;

        AudioSource[] audioSources = GetComponents<AudioSource>();
        ok2a = audioSources[0];
        doordondon = audioSources[1];
        dooropen = audioSources[2];
        printer = audioSources[3];
        decision = audioSources[4];
        money = audioSources[5];
    }

    void Update()
    {
        if (deleteFlag == 0)
        {
            MyCanvas.SetActive("doorButton", false);
            MyCanvas.SetActive("itemBoxButton1", false);
            MyCanvas.SetActive("itemBoxButton2", false);
            MyCanvas.SetActive("itemBoxButton3", false);
            MyCanvas.SetActive("itemBoxButton4", false);
            MyCanvas.SetActive("itemBoxButton5", false);
            MyCanvas.SetActive("itemPaperButton", false);

            GameObject.Find("keyPlane").GetComponent<Renderer>().enabled = false;
            GameObject.Find("paperPlane").GetComponent<Renderer>().enabled = false;
            GameObject.Find("fiveyenPlane").GetComponent<Renderer>().enabled = false;
            GameObject.Find("goldcoinPlane").GetComponent<Renderer>().enabled = false;
            GameObject.Find("goldcoin2Plane").GetComponent<Renderer>().enabled = false;

            MyCanvas.SetActive("itemKeyButton", false);
            item_key.SetActive(false);
            itemlist_key.SetActive(false);
            itemlist_paperkey.SetActive(false);
            itemlist_paper.SetActive(false);
            itemlist_fiveyen.SetActive(false);
            itemlist_goldcoin.SetActive(false);
            itemlist_goldcoin2.SetActive(false);
            item_paper.SetActive(false);
            paperFlag = 0;
            keyFlag = 0;
            fiveyenFlag = 0;
            goldcoinFlag = 0;
            goldcoin2Flag = 0;
            deleteFlag = 1;
        }

        //視点ごとのカメラオンオフ切り替え
        switch (position)
        {
            case "main":
                mainCamera.enabled = true;
                wiiCamera.enabled = false;
                trashBoxCamera.enabled = false;
                potatoCamera.enabled = false;
                doorCamera.enabled = false;
                deskCamera.enabled = false;
                pigCamera.enabled = false;
                underSofaCamera.enabled = false;
                monitorCamera.enabled = false;

                MyCanvas.SetActive("rightButton", true);
                MyCanvas.SetActive("leftButton", true);
                MyCanvas.SetActive("underButton", false);
                MyCanvas.SetActive("wiiButton", true);
                MyCanvas.SetActive("potatoButton", true);
                MyCanvas.SetActive("trashButton", true);
                MyCanvas.SetActive("sofaButton", true);
                MyCanvas.SetActive("monitorButton", false);
                MyCanvas.SetActive("shelfButton", false);
                MyCanvas.SetActive("3dButton", false);
                MyCanvas.SetActive("doorButton", false);
                MyCanvas.SetActive("pigButton", false);
                MyCanvas.SetActive("itemKeyButton", false);
                MyCanvas.SetActive("itemPaperButton", false);
                MyCanvas.SetActive("itemFiveYenButton", false);
                MyCanvas.SetActive("itemGoldCoinButton", false);
                MyCanvas.SetActive("itemGoldCoin2Button", false);
                break;
            case "wii":
                mainCamera.enabled = false;
                potatoCamera.enabled = false;
                wiiCamera.enabled = true;
                break;
            case "wall":
                doorCamera.enabled = false;
                mainCamera.enabled = false;
                wallCamera.enabled = true;
                break;
            case "trash":
                mainCamera.enabled = false;
                trashBoxCamera.enabled = true;
                break;
            case "potato":
                mainCamera.enabled = false;
                potatoCamera.enabled = true;
                break;
            case "door":
                wallCamera.enabled = false;
                mainCamera.enabled = false;
                doorCamera.enabled = true;
                break;
            case "desk":
                wallCamera.enabled = false;
                mainCamera.enabled = false;
                pigCamera.enabled = false;
                monitorCamera.enabled = false;
                deskCamera.enabled = true;
                break;
            case "pig":
                mainCamera.enabled = false;
                pigCamera.enabled = true;
                break;
            case "under":
                mainCamera.enabled = false;
                underSofaCamera.enabled = true;
                break;
            case "monitor":
                mainCamera.enabled = false;
                monitorCamera.enabled = true;
                break;
            default:
                break;
        }
    }

    //ボタンのクリック分岐
    protected override void OnClick(string objectName)
    {
        // 渡されたオブジェクト名で処理を分岐
        if ("rightButton".Equals(objectName))
        {
            //右ボタン
            this.RightButtonClick();
        }
        else if ("leftButton".Equals(objectName))
        {
            //左ボタン
            this.LeftButtonClick();
        }
        else if ("underButton".Equals(objectName))
        {
            //下ボタン
            this.UnderButtonClick();
        }
        else if ("wiiButton".Equals(objectName))
        {
            //Wiiへ行くボタン
            this.WiiButtonClick();
        }
        else if ("potatoButton".Equals(objectName))
        {
            //ポテチへ行くボタン
            this.PotatoButtonClick();
        }
        else if ("trashButton".Equals(objectName))
        {
            //ゴミ箱へ行くボタン
            this.TrashButtonClick();
        }
        else if ("sofaButton".Equals(objectName))
        {
            //ソファの下へ行くボタン
            this.SofaButtonClick();
        }
        else if ("monitorButton".Equals(objectName))
        {
            //モニターへ行くボタン
            this.MonitorButtonClick();
        }
        else if ("shelfButton".Equals(objectName))
        {
            //棚へ行くボタン
            this.ShelfButtonClick();
        }
        else if ("3dButton".Equals(objectName))
        {
            //3Dプリンター
            this.PrinterButtonClick();
        }
        else if ("pigButton".Equals(objectName))
        {
            //貯金箱
            this.PigButtonClick();
        }
        else if ("itemPaperButton".Equals(objectName))
        {
            //アイテムの紙を取得するボタン
            this.ItemPaperButtonClick();
        }
        else if ("itemFiveYenButton".Equals(objectName))
        {
            //アイテムの5円を取得するボタン
            this.ItemFiveYenButtonClick();
        }
        else if ("itemGoldCoinButton".Equals(objectName))
        {
            //アイテムの金貨を取得するボタン
            this.ItemGoldCoinButtonClick();
        }
        else if ("itemGoldCoin2Button".Equals(objectName))
        {
            //アイテムの金貨2を取得するボタン
            this.ItemGoldCoin2ButtonClick();
        }
        else if ("itemKeyButton".Equals(objectName))
        {
            //アイテムの鍵を取得するボタン
            this.ItemKeyButtonClick();
        }
        else if ("itemBoxButton1".Equals(objectName))
        {
            //1番上のアイテムを選択するボタン
            this.ItemBoxButton1Click();
        }
        else if ("itemBoxButton2".Equals(objectName))
        {
            //2番目のアイテムを選択するボタン
            this.ItemBoxButton2Click();
        }
        else if ("itemBoxButton3".Equals(objectName))
        {
            //3番目のアイテムを選択するボタン
            this.ItemBoxButton3Click();
        }
        else if ("itemBoxButton4".Equals(objectName))
        {
            //4番目のアイテムを選択するボタン
            this.ItemBoxButton4Click();
        }
        else if ("itemBoxButton5".Equals(objectName))
        {
            //5番目のアイテムを選択するボタン
            this.ItemBoxButton5Click();
        }
        else if ("doorButton".Equals(objectName))
        {
            //ドアノブをガチャガチャするボタン
            this.DoorButtonClick();
        }
        else
        {
            throw new System.Exception("Not implemented!!");
        }
    }

    //右に移動するボタン
    private void RightButtonClick()
    {

        switch (position)
        {
            case "main":
                position = "door";
                MyCanvas.SetActive("rightButton", true);
                MyCanvas.SetActive("leftButton", true);
                MyCanvas.SetActive("underButton", false);
                MyCanvas.SetActive("wiiButton", false);
                MyCanvas.SetActive("potatoButton", false);
                MyCanvas.SetActive("trashButton", false);
                MyCanvas.SetActive("sofaButton", false);
                MyCanvas.SetActive("doorButton", true);
                break;
            case "door":
                position = "wall";
                MyCanvas.SetActive("doorButton", false);
                break;
            case "wall":
                position = "desk";
                MyCanvas.SetActive("rightButton", true);
                MyCanvas.SetActive("leftButton", true);
                MyCanvas.SetActive("underButton", false);
                MyCanvas.SetActive("monitorButton", true);
                MyCanvas.SetActive("shelfButton", true);
                MyCanvas.SetActive("3dButton", false);
                break;
            case "desk":
                position = "main";
                MyCanvas.SetActive("rightButton", true);
                MyCanvas.SetActive("leftButton", true);
                MyCanvas.SetActive("underButton", false);
                MyCanvas.SetActive("wiiButton", true);
                MyCanvas.SetActive("potatoButton", true);
                MyCanvas.SetActive("trashButton", true);
                MyCanvas.SetActive("sofaButton", true);
                MyCanvas.SetActive("monitorButton", false);
                MyCanvas.SetActive("shelfButton", false);
                MyCanvas.SetActive("3dButton", false);
                MyCanvas.SetActive("doorButton", false);
                break;
            default:
                break;
        }
    }
    
    //左へ移動するボタン
    private void LeftButtonClick()
    {
        switch (position)
        {
            case "main":
                position = "desk";
                MyCanvas.SetActive("rightButton", true);
                MyCanvas.SetActive("leftButton", true);
                MyCanvas.SetActive("underButton", false);
                MyCanvas.SetActive("wiiButton", false);
                MyCanvas.SetActive("potatoButton", false);
                MyCanvas.SetActive("trashButton", false);
                MyCanvas.SetActive("sofaButton", false);
                MyCanvas.SetActive("monitorButton", true);
                MyCanvas.SetActive("shelfButton", true);
                break;
            case "door":
                position = "main";
                MyCanvas.SetActive("rightButton", true);
                MyCanvas.SetActive("leftButton", true);
                MyCanvas.SetActive("underButton", false);
                MyCanvas.SetActive("wiiButton", false);
                MyCanvas.SetActive("potatoButton", false);
                MyCanvas.SetActive("trashButton", false);
                MyCanvas.SetActive("sofaButton", false);
                MyCanvas.SetActive("doorButton", false);
                break;
            case "wall":
                position = "door";
                MyCanvas.SetActive("doorButton", true);
                break;
            case "desk":
                position = "wall";
                MyCanvas.SetActive("monitorButton", false);
                MyCanvas.SetActive("shelfButton", false);
                break;
            default:
                break;
        }
    }
    //手前へ戻るボタン
    private void UnderButtonClick()
    {
        switch (position)
        {
            case "wii":
                position = "main";
                MyCanvas.SetActive("rightButton", true);
                MyCanvas.SetActive("leftButton", true);
                MyCanvas.SetActive("underButton", false);
                MyCanvas.SetActive("wiiButton", false);
                MyCanvas.SetActive("potatoButton", false);
                MyCanvas.SetActive("trashButton", false);
                MyCanvas.SetActive("sofaButton", false);
                break;
            case "trash":
                position = "main";
                MyCanvas.SetActive("rightButton", true);
                MyCanvas.SetActive("leftButton", true);
                MyCanvas.SetActive("underButton", false);
                MyCanvas.SetActive("wiiButton", false);
                MyCanvas.SetActive("potatoButton", false);
                MyCanvas.SetActive("trashButton", false);
                MyCanvas.SetActive("sofaButton", false);
                break;
            case "potato":
                position = "main";
                MyCanvas.SetActive("rightButton", true);
                MyCanvas.SetActive("leftButton", true);
                MyCanvas.SetActive("underButton", false);
                MyCanvas.SetActive("wiiButton", false);
                MyCanvas.SetActive("potatoButton", false);
                MyCanvas.SetActive("trashButton", false);
                MyCanvas.SetActive("sofaButton", true);
                MyCanvas.SetActive("itemPaperButton", false);
                break;
            case "pig":
                position = "desk";
                MyCanvas.SetActive("rightButton", true);
                MyCanvas.SetActive("leftButton", true);
                MyCanvas.SetActive("underButton", false);
                MyCanvas.SetActive("wiiButton", false);
                MyCanvas.SetActive("potatoButton", false);
                MyCanvas.SetActive("trashButton", false);
                MyCanvas.SetActive("sofaButton", false);
                MyCanvas.SetActive("monitorButton", true);
                MyCanvas.SetActive("shelfButton", true);
                MyCanvas.SetActive("3dButton", false);
                MyCanvas.SetActive("itemKeyButton", false);
                MyCanvas.SetActive("pigButton", false);
                break;
            case "under":
                position = "main";
                MyCanvas.SetActive("rightButton", true);
                MyCanvas.SetActive("leftButton", true);
                MyCanvas.SetActive("underButton", false);
                MyCanvas.SetActive("wiiButton", false);
                MyCanvas.SetActive("potatoButton", false);
                MyCanvas.SetActive("trashButton", false);
                MyCanvas.SetActive("sofaButton", true);
                break;
            case "monitor":
                position = "desk";
                MyCanvas.SetActive("rightButton", true);
                MyCanvas.SetActive("leftButton", true);
                MyCanvas.SetActive("underButton", false);
                MyCanvas.SetActive("wiiButton", false);
                MyCanvas.SetActive("potatoButton", false);
                MyCanvas.SetActive("trashButton", false);
                MyCanvas.SetActive("sofaButton", false);
                MyCanvas.SetActive("monitorButton", true);
                MyCanvas.SetActive("shelfButton", true);
                MyCanvas.SetActive("3dButton", false);
                break;
            default:
                break;
        }
    }
    
    //隠れ視点移動ボタン
    private void WiiButtonClick()
    {
        position = "wii";
        MyCanvas.SetActive("rightButton", false);
        MyCanvas.SetActive("leftButton", false);
        MyCanvas.SetActive("underButton", true);
        MyCanvas.SetActive("wiiButton", false);
        MyCanvas.SetActive("potatoButton", false);
        MyCanvas.SetActive("trashButton", false);
        MyCanvas.SetActive("sofaButton", false);
        MyCanvas.SetActive("monitorButton", false);
        MyCanvas.SetActive("shelfButton", false);
        MyCanvas.SetActive("3dButton", false);

        if (collectflag == 1)
        {
            item_paper.SetActive(true);
            MyCanvas.SetActive("itemPaperButton", true);
        }
    }
    private void PotatoButtonClick()
    {
        position = "potato";
        MyCanvas.SetActive("rightButton", false);
        MyCanvas.SetActive("leftButton", false);
        MyCanvas.SetActive("underButton", true);
        MyCanvas.SetActive("wiiButton", false);
        MyCanvas.SetActive("potatoButton", false);
        MyCanvas.SetActive("trashButton", false);
        MyCanvas.SetActive("sofaButton", false);
        MyCanvas.SetActive("monitorButton", false);
        MyCanvas.SetActive("shelfButton", false);
        MyCanvas.SetActive("3dButton", false);
        if (goldcoin2Flag == 0)
        {
            MyCanvas.SetActive("itemGoldCoin2Button", true);
        }
    }
    private void TrashButtonClick()
    {
        position = "trash";
        MyCanvas.SetActive("rightButton", false);
        MyCanvas.SetActive("leftButton", false);
        MyCanvas.SetActive("underButton", true);
        MyCanvas.SetActive("wiiButton", false);
        MyCanvas.SetActive("potatoButton", false);
        MyCanvas.SetActive("trashButton", false);
        MyCanvas.SetActive("sofaButton", false);
        MyCanvas.SetActive("monitorButton", false);
        MyCanvas.SetActive("shelfButton", false);
        MyCanvas.SetActive("3dButton", false);
        if (fiveyenFlag == 0)
        {
            MyCanvas.SetActive("itemFiveYenButton", true);
        }
    }
    private void SofaButtonClick()
    {
        position = "under";
        MyCanvas.SetActive("rightButton", false);
        MyCanvas.SetActive("leftButton", false);
        MyCanvas.SetActive("underButton", true);
        MyCanvas.SetActive("wiiButton", false);
        MyCanvas.SetActive("potatoButton", false);
        MyCanvas.SetActive("trashButton", false);
        MyCanvas.SetActive("sofaButton", false);
        MyCanvas.SetActive("monitorButton", false);
        MyCanvas.SetActive("shelfButton", false);
        MyCanvas.SetActive("3dButton", false);
        if (goldcoinFlag == 0)
        {
            MyCanvas.SetActive("itemGoldCoinButton", true);
        }
    }
    private void MonitorButtonClick()
    {
        position = "monitor";
        MyCanvas.SetActive("rightButton", false);
        MyCanvas.SetActive("leftButton", false);
        MyCanvas.SetActive("underButton", true);
        MyCanvas.SetActive("wiiButton", false);
        MyCanvas.SetActive("potatoButton", false);
        MyCanvas.SetActive("trashButton", false);
        MyCanvas.SetActive("sofaButton", false);
        MyCanvas.SetActive("monitorButton", false);
        MyCanvas.SetActive("shelfButton", false);
        MyCanvas.SetActive("3dButton", false);
    }
    private void ShelfButtonClick()
    {
        position = "pig";
        MyCanvas.SetActive("rightButton", false);
        MyCanvas.SetActive("leftButton", false);
        MyCanvas.SetActive("underButton", true);
        MyCanvas.SetActive("wiiButton", false);
        MyCanvas.SetActive("potatoButton", false);
        MyCanvas.SetActive("trashButton", false);
        MyCanvas.SetActive("sofaButton", false);
        MyCanvas.SetActive("monitorButton", false);
        MyCanvas.SetActive("shelfButton", false);
        MyCanvas.SetActive("3dButton", true);
        MyCanvas.SetActive("pigButton", true);

    }
    private void PrinterButtonClick()
    {
        if (paperFlag == 1 && itemflag2 == 1)
        {
            if (keyFlag != 1)
            {
                printer.PlayOneShot(printer.clip);
                MyCanvas.SetActive("itemBoxButton1", true);
                MyCanvas.SetActive("itemKeyButton", true);
                item_key.SetActive(true);
            }
        }
    }
    private void PigButtonClick()
    {
        if (goldcoinFlag == 1 && itemflag3 == 1)
        {
            money.PlayOneShot(money.clip);
            MyCanvas.SetActive("itemBoxButton3", false);
            GameObject.Find("goldcoinPlane").GetComponent<Renderer>().enabled = false;
            i = i + 1;
            goldcoinFlag = 1;
        }
        else if (goldcoin2Flag == 1 && itemflag4 == 1)
        {
            money.PlayOneShot(money.clip);
            MyCanvas.SetActive("itemBoxButton4", false);
            GameObject.Find("goldcoin2Plane").GetComponent<Renderer>().enabled = false;
            i = i + 1;
            goldcoin2Flag = 0;
        }
        else if (fiveyenFlag == 1 && itemflag5 == 1)
        {
            money.PlayOneShot(money.clip);
            MyCanvas.SetActive("itemBoxButton5", false);
            GameObject.Find("fiveyenPlane").GetComponent<Renderer>().enabled = false;
            i = i + 1;
            fiveyenFlag = 0;
        }

        if (i >= 3)
        {
            decision.PlayOneShot(decision.clip);
            collectflag = 1;
        }
    }

    //アイテムをゲットするボタン
    private void ItemPaperButtonClick()
    {
        paperFlag = 1;
        MyCanvas.SetActive("itemBoxButton2", true);
        MyCanvas.SetActive("itemPaperButton", false);
        item_paper.SetActive(false);
        itemlist_paper.SetActive(true);
        itemlist_paperkey.SetActive(true);
        ok2a.PlayOneShot(ok2a.clip);
    }
    private void ItemFiveYenButtonClick()
    {
        fiveyenFlag = 1;
        ok2a.PlayOneShot(ok2a.clip);
        MyCanvas.SetActive("itemBoxButton5", true);
        MyCanvas.SetActive("itemFiveYenButton", false);
        item_fiveyen.SetActive(false);
        itemlist_fiveyen.SetActive(true);
    }
    private void ItemGoldCoinButtonClick()
    {

        goldcoinFlag = 1;
        ok2a.PlayOneShot(ok2a.clip);
        MyCanvas.SetActive("itemBoxButton4", true);
        MyCanvas.SetActive("itemGoldCoinButton", false);
        item_goldcoin.SetActive(false);
        itemlist_goldcoin.SetActive(true);
    }
    private void ItemGoldCoin2ButtonClick()
    {
        goldcoin2Flag = 1;
        ok2a.PlayOneShot(ok2a.clip);
        MyCanvas.SetActive("itemBoxButton3", true);
        MyCanvas.SetActive("itemGoldCoin2Button", false);
        item_goldcoin2.SetActive(false);
        itemlist_goldcoin2.SetActive(true);
    }
    private void ItemKeyButtonClick()
    {
        keyFlag = 1;
        ok2a.PlayOneShot(ok2a.clip);
        MyCanvas.SetActive("itemKeyButton", false);
        item_key.SetActive(false);
        itemlist_key.SetActive(true);
    }

    //アイテムボックス内の選択ボタン
    private void ItemBoxButton1Click()
    {

        itemflag1 = 1;
        itemflag2 = 0;
        itemflag3 = 0;
        itemflag4 = 0;
        itemflag5 = 0;
        GameObject.Find("goldcoinPlane").GetComponent<Renderer>().enabled = false;
        GameObject.Find("goldcoin2Plane").GetComponent<Renderer>().enabled = false;
        GameObject.Find("fiveyenPlane").GetComponent<Renderer>().enabled = false;
        GameObject.Find("keyPlane").GetComponent<Renderer>().enabled = true;
        GameObject.Find("paperPlane").GetComponent<Renderer>().enabled = false;
    }
    private void ItemBoxButton2Click()
    {
        itemflag1 = 0;
        itemflag2 = 1;
        itemflag3 = 0;
        itemflag4 = 0;
        itemflag5 = 0;
        GameObject.Find("goldcoinPlane").GetComponent<Renderer>().enabled = false;
        GameObject.Find("goldcoin2Plane").GetComponent<Renderer>().enabled = false;
        GameObject.Find("fiveyenPlane").GetComponent<Renderer>().enabled = false;
        GameObject.Find("keyPlane").GetComponent<Renderer>().enabled = false;
        GameObject.Find("paperPlane").GetComponent<Renderer>().enabled = true;
    }
    private void ItemBoxButton3Click()
    {

        itemflag1 = 0;
        itemflag2 = 0;
        itemflag3 = 1;
        itemflag4 = 0;
        itemflag5 = 0;
        GameObject.Find("goldcoinPlane").GetComponent<Renderer>().enabled = true;
        GameObject.Find("goldcoin2Plane").GetComponent<Renderer>().enabled = false;
        GameObject.Find("fiveyenPlane").GetComponent<Renderer>().enabled = false;
        GameObject.Find("keyPlane").GetComponent<Renderer>().enabled = false;
        GameObject.Find("paperPlane").GetComponent<Renderer>().enabled = false;
    }
    private void ItemBoxButton4Click()
    {
        itemflag1 = 0;
        itemflag2 = 0;
        itemflag3 = 0;
        itemflag4 = 1;
        itemflag5 = 0;
        GameObject.Find("goldcoinPlane").GetComponent<Renderer>().enabled = false;
        GameObject.Find("goldcoin2Plane").GetComponent<Renderer>().enabled = true;
        GameObject.Find("fiveyenPlane").GetComponent<Renderer>().enabled = false;
        GameObject.Find("keyPlane").GetComponent<Renderer>().enabled = false;
        GameObject.Find("paperPlane").GetComponent<Renderer>().enabled = false;
    }
    private void ItemBoxButton5Click()
    {
        itemflag1 = 0;
        itemflag2 = 0;
        itemflag3 = 0;
        itemflag4 = 0;
        itemflag5 = 1;
        GameObject.Find("goldcoinPlane").GetComponent<Renderer>().enabled = false;
        GameObject.Find("goldcoin2Plane").GetComponent<Renderer>().enabled = false;
        GameObject.Find("fiveyenPlane").GetComponent<Renderer>().enabled = true;
        GameObject.Find("keyPlane").GetComponent<Renderer>().enabled = false;
        GameObject.Find("paperPlane").GetComponent<Renderer>().enabled = false;
    }

    //ドアが開くか開かないか判定用ボタン
    private void DoorButtonClick()
    {
        if(itemflag1 == 1)
        {
            dooropen.PlayOneShot(dooropen.clip);
            SceneManager.LoadScene("Clear");
        }
        else
        {
            doordondon.PlayOneShot(doordondon.clip);
        }
    }
}

