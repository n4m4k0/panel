using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.PlayerSettings;
/// <summary>
/// キャラクターのマネージャークラス
/// </summary>
public class CharacterManager : MonoBehaviour
{
    [SerializeField] Collision character;
    [SerializeField] GameObject present;
    [SerializeField] GameObject bell;
    private Rigidbody rb;
    float jumpPower = 200f;
    //地面についているかどうか
    bool isJumping = false;
    //プレゼントバフをもらっているかどうか
    bool presentbuff;
    //速度
    float speed = 5f;
    public void Start()
    {

        this.rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
     void Update()
    {

        Vector3 characterpos = transform.position;
        //前進
        if (Input.GetKey(KeyCode.W))
        {
            characterpos += transform.forward * speed * Time.deltaTime;
        }
        // 左に移動
        if (Input.GetKey(KeyCode.A))
        {
            characterpos -= transform.right * speed * Time.deltaTime;
        }
        // 右に移動
        if (Input.GetKey(KeyCode.D))
        {
            characterpos += transform.right * speed * Time.deltaTime;
        }
        // 後ろに移動
        if (Input.GetKey(KeyCode.S))
        {
            characterpos -= transform.forward * speed * Time.deltaTime;

        }
        if (Input.GetKeyDown(KeyCode.Space)&& !isJumping)
        {
            rb.AddForce(transform.up * jumpPower);
            isJumping = true;
        }
        transform.position = characterpos;  // 座標を設定
    }
    //地面についているか判定
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
 
