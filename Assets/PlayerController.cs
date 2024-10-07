using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    float walkForce = 30.0f; // �ړ��Ɏg����
    float maxWalkSpeed = 2.0f; // �ő�ړ����x
    Vector2 movementInput; // �ړ������̓���
    // �����ړ��Əc�ړ��̓��͂��擾
    float moveX = 0;
    float moveY = 0;
    // �X�^�[�g���\�b�h
    // Joystick �ϐ���ǉ�
    [SerializeField] private FloatingJoystick floatingJoystick;
    void Start()
    {
        Application.targetFrameRate = 60; // �t���[�����[�g�̐ݒ�
        this.rigid2D = GetComponent<Rigidbody2D>(); // Rigidbody2D�̎擾
        // Joystick ���C���X�y�N�^�[�Őݒ肳��Ă��Ȃ��ꍇ�A�V�[�������猩����
        if (floatingJoystick == null)
        {
            floatingJoystick = FindObjectOfType<FloatingJoystick>();
        }
    }

    // �A�b�v�f�[�g���\�b�h
    void Update()
    {
        // �L�[�{�[�h����̓��͂��擾
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            moveX = Input.GetAxisRaw("Horizontal");
            moveY = Input.GetAxisRaw("Vertical");
        }
        // Joystick����̓��͂��擾
        else if (floatingJoystick != null)
        {
            moveX = floatingJoystick.Horizontal;
            moveY = floatingJoystick.Vertical;
        }
        // ���͂̃��Z�b�g
        //moveX = 0;
        //moveY = 0;
        if (Input.GetKey(KeyCode.RightArrow)) moveX = 1; // �E���L�[�������ꂽ�Ƃ�
        if (Input.GetKey(KeyCode.LeftArrow)) moveX = -1; // �����L�[�������ꂽ�Ƃ�
        if (Input.GetKey(KeyCode.UpArrow)) moveY = 1; // ����L�[�������ꂽ�Ƃ�
        if (Input.GetKey(KeyCode.DownArrow)) moveY = -1; // �����L�[�������ꂽ�Ƃ�

        // �ړ������𐳋K�����Đݒ�
        movementInput = new Vector2(moveX, moveY).normalized;

        // �ړ���K�p
        ApplyMovement();
    }
    public void LButtonDown()
    {
        moveX = -1; // ���Ɉړ�
    }
    public void RButtonDown()
    {
        moveX = 1; // �E�Ɉړ�
    }
    public void UPButtonDown()
    {
        moveY = 1; // ��Ɉړ�
    }
    public void DownButtonDown()
    {
        moveY = -1; // ���Ɉړ�
    }
    // �ړ���K�p���郁�\�b�h
    void ApplyMovement()
    {
        // ���݂̑��x���擾
        Vector2 velocity = rigid2D.velocity;

        // �ړ��̗͂��v�Z���ēK�p
        if (movementInput.x != 0 || movementInput.y != 0)
        {
            Vector2 force = movementInput * walkForce; // �ړ������ɗ͂��|����
            rigid2D.AddForce(force);

            // ���x���ő呬�x�ɐ���
            if (rigid2D.velocity.magnitude > maxWalkSpeed)
            {
                rigid2D.velocity = Vector2.ClampMagnitude(rigid2D.velocity, maxWalkSpeed);
            }
        }
        
    }
}