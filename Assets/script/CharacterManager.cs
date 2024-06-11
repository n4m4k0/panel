using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.PlayerSettings;
/// <summary>
/// �L�����N�^�[�̃}�l�[�W���[�N���X
/// </summary>
public class CharacterManager : MonoBehaviour
{
    [SerializeField] Collision character;
    [SerializeField] GameObject present;
    [SerializeField] GameObject bell;
    private Rigidbody rb;
    float jumpPower = 200f;
    //�n�ʂɂ��Ă��邩�ǂ���
    bool isJumping = false;
    //�v���[���g�o�t��������Ă��邩�ǂ���
    bool presentbuff;
    //���x
    float speed = 5f;
    public void Start()
    {

        this.rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
     void Update()
    {

        Vector3 characterpos = transform.position;
        //�O�i
        if (Input.GetKey(KeyCode.W))
        {
            characterpos += transform.forward * speed * Time.deltaTime;
        }
        // ���Ɉړ�
        if (Input.GetKey(KeyCode.A))
        {
            characterpos -= transform.right * speed * Time.deltaTime;
        }
        // �E�Ɉړ�
        if (Input.GetKey(KeyCode.D))
        {
            characterpos += transform.right * speed * Time.deltaTime;
        }
        // ���Ɉړ�
        if (Input.GetKey(KeyCode.S))
        {
            characterpos -= transform.forward * speed * Time.deltaTime;

        }
        if (Input.GetKeyDown(KeyCode.Space)&& !isJumping)
        {
            rb.AddForce(transform.up * jumpPower);
            isJumping = true;
        }
        transform.position = characterpos;  // ���W��ݒ�
    }
    //�n�ʂɂ��Ă��邩����
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isJumping = false;
        }
        if(collision.gameObject.CompareTag("presentbuff"))
        {
            Destroy(present.gameObject);
            StartCoroutine("ChangeColor");
        }
    }
    IEnumerator ChangeColor()
    {
        yield return new WaitForSeconds(5.0f);

    }
}
 
