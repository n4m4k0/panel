using System.Collections.Generic;
using UnityEngine;
using System;
using Cysharp.Threading.Tasks;

/// <summary>
/// �e���ˏo����X�N���v�g
/// </summary>
public class Canonontroller : MonoBehaviour
{
    //4��ނ̑�C
    [SerializeField] List<GameObject>canonn;
    //�e
    [SerializeField] List<GameObject> canonnball;
    int canonnspeed=1000;
    //random
    List<int> randomTime = new List<int>();

    bool isCreate = false; // �����t���O
    float nowCreateIntarval;

    const float LV1Interval = 5.0f;
    const float LV2Interval = 3.0f;
    const float LV3Interval = 1.0f;

    private void Start()
    {

        nowCreateIntarval = LV1Interval;
        // �����C���^�[�o���J�n
        StartCreateInterval();
    }
    private int index;
    // Update is called once per frame
    void Update()
    {
        if (isCreate)
        {
            CreateShell(); // ������

            isCreate = false; // �����t���O������
            // �����C���^�[�o���J�n
            StartCreateInterval();
        }
    }

    async void StartCreateInterval()
    {
        // CreateIntarval�b�ҋ@�㐶���t���O�؂�ւ�
        await UniTask.Delay(TimeSpan.FromSeconds(nowCreateIntarval));
        isCreate = true;
    }

    void CreateShell()
    {
        for (int i = 0; i < canonn.Count; i++)
        {
            GameObject shell = Instantiate(canonnball[UnityEngine.Random.Range(0, 3)], canonn[i].transform.position, Quaternion.identity);
            Rigidbody shellRb = shell.GetComponent<Rigidbody>();
            //�e�X�̈ʒu�����΂�
            switch (i)
            {
                case 0:
                    // �e���͎��R�ɐݒ�
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
            // �T�b��ɖC�e��j�󂷂�
            Destroy(shell, 5.0f);
            index = (int)UnityEngine.Random.Range(0, 2);
        }
    }
}
