using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    float walkForce = 30.0f; // 移動に使う力
    float maxWalkSpeed = 2.0f; // 最大移動速度
    Vector2 movementInput; // 移動方向の入力
    // 水平移動と縦移動の入力を取得
    float moveX = 0;
    float moveY = 0;
    // スタートメソッド
    // Joystick 変数を追加
    [SerializeField] private FloatingJoystick floatingJoystick;
    void Start()
    {
        Application.targetFrameRate = 60; // フレームレートの設定
        this.rigid2D = GetComponent<Rigidbody2D>(); // Rigidbody2Dの取得
        // Joystick がインスペクターで設定されていない場合、シーン内から見つける
        if (floatingJoystick == null)
        {
            floatingJoystick = FindObjectOfType<FloatingJoystick>();
        }
    }

    // アップデートメソッド
    void Update()
    {
        // キーボード操作の入力を取得
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            moveX = Input.GetAxisRaw("Horizontal");
            moveY = Input.GetAxisRaw("Vertical");
        }
        // Joystick操作の入力を取得
        else if (floatingJoystick != null)
        {
            moveX = floatingJoystick.Horizontal;
            moveY = floatingJoystick.Vertical;
        }
        // 入力のリセット
        //moveX = 0;
        //moveY = 0;
        if (Input.GetKey(KeyCode.RightArrow)) moveX = 1; // 右矢印キーが押されたとき
        if (Input.GetKey(KeyCode.LeftArrow)) moveX = -1; // 左矢印キーが押されたとき
        if (Input.GetKey(KeyCode.UpArrow)) moveY = 1; // 上矢印キーが押されたとき
        if (Input.GetKey(KeyCode.DownArrow)) moveY = -1; // 下矢印キーが押されたとき

        // 移動方向を正規化して設定
        movementInput = new Vector2(moveX, moveY).normalized;

        // 移動を適用
        ApplyMovement();
    }
    public void LButtonDown()
    {
        moveX = -1; // 左に移動
    }
    public void RButtonDown()
    {
        moveX = 1; // 右に移動
    }
    public void UPButtonDown()
    {
        moveY = 1; // 上に移動
    }
    public void DownButtonDown()
    {
        moveY = -1; // 下に移動
    }
    // 移動を適用するメソッド
    void ApplyMovement()
    {
        // 現在の速度を取得
        Vector2 velocity = rigid2D.velocity;

        // 移動の力を計算して適用
        if (movementInput.x != 0 || movementInput.y != 0)
        {
            Vector2 force = movementInput * walkForce; // 移動方向に力を掛ける
            rigid2D.AddForce(force);

            // 速度を最大速度に制限
            if (rigid2D.velocity.magnitude > maxWalkSpeed)
            {
                rigid2D.velocity = Vector2.ClampMagnitude(rigid2D.velocity, maxWalkSpeed);
            }
        }
        
    }
}