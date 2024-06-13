using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// �n�ʂ̐���N���X
/// </summary>
public class GrounController : MonoBehaviour
{

    //���̃I�u�W�F�N�g
    [SerializeField] List<GameObject> groundGameObjects;
    [SerializeField] List<TextMeshPro> groundTimeText;
    //���̐�
    List<bool> isCroutine = new List<bool>();
    //���̎���
    int groundTime;
    //���̌��鎞��
    int decreaseTime=0;

    void Start()
    {
        //���̏�����
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
        //�ǂ̏����ǂ̎��Ԃɗ����邩
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
        // 1�b�ԑ҂�
        yield return new WaitForSeconds(1);
        if (groundTime > 3)
        {
            groundTime -= 1;    
        }
    }
    //�������Ԃŗ����锻��
    IEnumerator WaitTime(GameObject groudameObject,int croutineListIndex,int groundTime)
    {
        isCroutine[croutineListIndex] = true;
        yield return new WaitForSeconds(seconds: groundTime);

       
        ChangeActive(groudameObject,false);

        yield return new WaitForSeconds(seconds: 1f);

        isCroutine[croutineListIndex] = false;
        ChangeActive(groudameObject, true);
    }
    //���̕b����\������
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
