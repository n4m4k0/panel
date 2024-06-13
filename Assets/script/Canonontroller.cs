using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
/// <summary>
/// ’e‚ğËo‚·‚éƒXƒNƒŠƒvƒg
/// </summary>
public class Canonontroller : MonoBehaviour
{
    //4í—Ş‚Ì‘å–C
    [SerializeField] List<GameObject>canonn;
    //’e
    [SerializeField] List<GameObject> canonnball;
    int canonnspeed=1000;
    //random
    List<int> randomTime = new List<int>();
    private void Start()
    {
        randomTime.Add(1800);
        randomTime.Add(3600);
        randomTime.Add(7200);
    }

    int count;
    private int index;
    // Update is called once per frame
    void Update()
    {
        //
        int rand = (int)Random.Range(1,10000);

        for (int i = 0; i < canonn.Count; i++)
        {
            if (rand  <= 5)
            {
                    GameObject shell = Instantiate(canonnball[Random.Range(0,3)], canonn[i].transform.position, Quaternion.identity);
                    Rigidbody shellRb = shell.GetComponent<Rigidbody>();
                //ŠeX‚ÌˆÊ’u‚©‚ç”ò‚Î‚·
                switch(i)
                {

                    case 0:
                            // ’e‘¬‚Í©—R‚Éİ’è
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

                // ‚T•bŒã‚É–C’e‚ğ”j‰ó‚·‚é
                Destroy(shell, 5.0f);
                index = (int)Random.Range(0, 2);
            }
        }count += 1;
    }
}
