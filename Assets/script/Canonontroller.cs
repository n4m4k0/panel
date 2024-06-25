using System.Collections.Generic;
using UnityEngine;
using System;
using Cysharp.Threading.Tasks;

/// <summary>
/// 弾を射出するスクリプト
/// </summary>
public class Canonontroller : MonoBehaviour
{
    //4種類の大砲
    [SerializeField] List<GameObject>canonn;
    //弾
    [SerializeField] List<GameObject> canonnball;
    int canonnspeed=1000;
    //random
    List<int> randomTime = new List<int>();

    bool isCreate = false; // 生成フラグ
    float nowCreateIntarval;

    const float LV1Interval = 5.0f;
    const float LV2Interval = 3.0f;
    const float LV3Interval = 1.0f;

    private void Start()
    {

        nowCreateIntarval = LV1Interval;
        // 生成インターバル開始
        StartCreateInterval();
    }
    private int index;
    // Update is called once per frame
    void Update()
    {
        if (isCreate)
        {
            CreateShell(); // 球生成

            isCreate = false; // 生成フラグを下す
            // 生成インターバル開始
            StartCreateInterval();
        }
    }

    async void StartCreateInterval()
    {
        // CreateIntarval秒待機後生成フラグ切り替え
        await UniTask.Delay(TimeSpan.FromSeconds(nowCreateIntarval));
        isCreate = true;
    }

    void CreateShell()
    {
        for (int i = 0; i < canonn.Count; i++)
        {
            GameObject shell = Instantiate(canonnball[UnityEngine.Random.Range(0, 3)], canonn[i].transform.position, Quaternion.identity);
            Rigidbody shellRb = shell.GetComponent<Rigidbody>();
            //各々の位置から飛ばす
            switch (i)
            {
                case 0:
                    // 弾速は自由に設定
                    shellRb.AddForce(transform.forward * canonnspeed);

                    break;
                case 1:
                    shellRb.AddForce(transform.right * -canonnspeed);

                    break;
                case 2:
                    shellRb.AddForce(transform.forward * -canonnspeed);

                    break;

                case 3:
                    shellRb.AddForce(transform.right * canonnspeed);

                    break;

                default:
                    break;
            }
            // ５秒後に砲弾を破壊する
            Destroy(shell, 5.0f);
            index = (int)UnityEngine.Random.Range(0, 2);
        }
    }
}
