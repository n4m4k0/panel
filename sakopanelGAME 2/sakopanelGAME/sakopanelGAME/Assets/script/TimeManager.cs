using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 時間を管理するスクリプト
/// </summary>
public class TimeManager : MonoBehaviour
{
    //地面を管理するスクリプト
    [SerializeField] GrounController grounController;
    private int GroundDecreaseTime = 0;
    public int GetSetGround
    {
        get { return GroundDecreaseTime; }
        set { GroundDecreaseTime = value; }
    }

    void Update()
    {
        StartCoroutine("MaxValueDecreaseTime");
    }
    /// <summary>
    ///最大値を減少させる関数
    /// </summary>
    public IEnumerator MaxValueDecreaseTime()
    {
        GrounController GroundTime = GetComponent<GrounController>();
        yield return new WaitForSeconds(20);
        if (GroundDecreaseTime < 3)
        {
            GroundDecreaseTime++;
        }
    }
}
