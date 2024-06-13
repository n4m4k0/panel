using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// 地面の制御クラス
/// </summary>
public class GrounController : MonoBehaviour
{

    //床のオブジェクト
    [SerializeField] List<GameObject> groundGameObjects;
    [SerializeField] List<TextMeshPro> groundTimeText;
    //床の数
    List<bool> isCroutine = new List<bool>();
    //床の時間
    int groundTime;
    //床の減る時間
    int decreaseTime=0;

    void Start()
    {
        //床の初期化
        for (int i = 0; i < groundGameObjects.Count; i++)
        {
            isCroutine.Add(false);
        }
    }
    private void Update()
    {
        GroundControllerUpdate();
    }

    // Update is called once per frame
    public void GroundControllerUpdate()
    {
        //どの床がどの時間に落ちるか
        for (int i = 0; i < groundGameObjects.Count; i++)
        {
            if (groundGameObjects[i].activeSelf && !isCroutine[i])
            {
                groundTime = Random.Range(1, 9);
                StartCoroutine(decreasegroundTime());
                    StartCoroutine(WaitTime(groundGameObjects[i], i, groundTime));
                StartCoroutine(WaitgroundTime(groundGameObjects[i], groundTime,groundTimeText[i]));
            }
        }  
    }
    IEnumerator decreasegroundTime()
    {
        // 1秒間待つ
        yield return new WaitForSeconds(1);
        if (groundTime > 3)
        {
            groundTime -= 1;    
        }
    }
    //床が時間で落ちる判定
    IEnumerator WaitTime(GameObject groudameObject,int croutineListIndex,int groundTime)
    {
        isCroutine[croutineListIndex] = true;
        yield return new WaitForSeconds(seconds: groundTime);

       
        ChangeActive(groudameObject,false);

        yield return new WaitForSeconds(seconds: 1f);

        isCroutine[croutineListIndex] = false;
        ChangeActive(groudameObject, true);
    }
    //床の秒数を表示する
    IEnumerator WaitgroundTime(GameObject groudameObject,  int groundTime, TextMeshPro groundTimeText)
    {
        int igroundTime = groundTime;
        groundTimeText.text = groundTime.ToString();
        for (int i = 0; i < igroundTime; i++)
        { 
        yield return new WaitForSeconds(seconds: 1);
        groundTime = groundTime - 1;
        groundTimeText.text = groundTime.ToString();
        }
    }

    void ChangeActive(GameObject groudameObject, bool active)
    {
        groudameObject.SetActive(active);
    }
}
