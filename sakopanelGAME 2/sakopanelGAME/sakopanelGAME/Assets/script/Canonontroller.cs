using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
/// <summary>
/// 弾を射出するスクリプト
/// </summary>
public class Canonontroller : MonoBehaviour
{
    //4種類の大砲
    [SerializeField] List<GameObject>canonn;
    //弾
    [SerializeField]GameObject canonnball;
    int canonnspeed=1000;
    //random
    List<int> randomTime = new List<int>();
    private void Start()
    {
        randomTime.Add(1800);
        randomTime.Add(3600);
        randomTime.Add(7200);
    }

    private int count;
    int index;
    // Update is called once per frame
    void Update()
    {
        count += 1;
       
        for (int i = 0; i < canonn.Count; i++)
        {
           
            // （ポイント）
            // ６０フレームごとに砲弾を発射する
            if (count % randomTime[index] == 0)
                {

                    GameObject shell = Instantiate(canonnball, canonn[i].transform.position, Quaternion.identity);
                    Rigidbody shellRb = shell.GetComponent<Rigidbody>();
                //各々の位置から飛ばす
                    switch(i)
                {
                    case 0:
                        // 弾速は自由に設定
                        shellRb.AddForce(transform.forward * canonnspeed);
                        break;
                     case 1:
                        //shellRb.GetComponent<Transform>().Rotate(new Vector3(0, -90, 00));
                        shellRb.AddForce(transform.right * -canonnspeed);
                        break;
                    case 2:
                        //shellRb.GetComponent<Transform>().Rotate(new Vector3(0, 180, 00));
                        shellRb.AddForce(transform.forward * -canonnspeed);
                        break;
                    case 3:
                        //shellRb.GetComponent<Transform>().Rotate(new Vector3(0, 90, 00));
                        shellRb.AddForce(transform.right * canonnspeed);
                        break;
                    default:
                        break;
                }

                // ５秒後に砲弾を破壊する
                Destroy(shell, 5.0f);
                index = (int)Random.Range(0, 2);
            }
            }
    }
}
