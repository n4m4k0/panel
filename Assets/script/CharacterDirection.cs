using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDirection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 characterpos = transform.position;
        //�O�i
        if (Input.GetKey(KeyCode.W))
        {

            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        // ���Ɉړ�
        if (Input.GetKey(KeyCode.A))
        {
            transform.eulerAngles = new Vector3(0, 270, 0);
        }
        // �E�Ɉړ�
        if (Input.GetKey(KeyCode.D))
        {
            transform.eulerAngles = new Vector3(0, 90, 0);
        }
        // ���Ɉړ�
        if (Input.GetKey(KeyCode.S))
        {
            transform.eulerAngles = new Vector3(0, 180, 0);

        }
    }
}
