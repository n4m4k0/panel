using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
/// <summary>
/// �e���ˏo����X�N���v�g
/// </summary>
public class Canonontroller : MonoBehaviour
{
    //4��ނ̑�C
    [SerializeField] List<GameObject>canonn;
    //�e
    [SerializeField]List<GameObject> canonnball;
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
           
            // �i�|�C���g�j
            // �U�O�t���[�����ƂɖC�e�𔭎˂���
            if (count % randomTime[index] == 0)
                {

                    GameObject shell = Instantiate(canonnball[Random.Range(0,3)], canonn[i].transform.position, Quaternion.identity);
                    Rigidbody shellRb = shell.GetComponent<Rigidbody>();
                //�e�X�̈ʒu�����΂�
                    switch(i)
                {
                    case 0:
                        // �e���͎��R�ɐݒ�
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

                // �T�b��ɖC�e��j�󂷂�
                Destroy(shell, 5.0f);
                index = (int)Random.Range(0, 2);
            }
            }
    }
}
