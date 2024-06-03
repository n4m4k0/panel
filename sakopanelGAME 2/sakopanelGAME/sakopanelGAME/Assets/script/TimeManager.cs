using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ���Ԃ��Ǘ�����X�N���v�g
/// </summary>
public class TimeManager : MonoBehaviour
{
    //�n�ʂ��Ǘ�����X�N���v�g
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
    ///�ő�l������������֐�
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
