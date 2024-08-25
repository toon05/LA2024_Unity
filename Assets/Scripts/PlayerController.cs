using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // �I�u�W�F�N�g�̕ϐ�
    public Camera playerCamera; // �J����
    public Transform viewPoint; // �J�����̈ʒu�I�u�W�F�N�g

    public Transform groundCheckPoint; // �n�ʂɌ�����Ray���΂��I�u�W�F�N�g
    public LayerMask groundLayers; // �n�ʂ��ƔF�����郌�C���[
    public Rigidbody playerRigidbody; // Rigidbody


    // ���͕ϐ�
    Vector2 mouseInput; // �}�E�X����
    float horizontalMouseInput; // x���̉�]
    float verticalMouseInput; // y���̉�]

    Vector3 movekeyInput; // �ړ��L�[�̓���
    Vector3 moveDirection; // �i�ޕ���

    // �X�e�[�^�X�ϐ�
    public float mouseSensitivity = 1f; // ���_�̈ړ����x
    public float moveSpeed = 4f; // �v���C���[�̈ړ����x
    public float walkSpeed = 4f, runSpeed = 8f; // �v���C���[�̕������x�Ƒ��鑬�x
    public float jumpForce = 6f; // �v���C���[�̃W�����v��

    // ���ʉ��ϐ�
    AudioSource landAudioSource;
    AudioSource jumpAudioSource;
    bool isWalking; // �����Ă��邩����
    public AudioClip jumpSound; // �W�����v��
    public AudioClip landSound; // ����

    // �J�����̏㉺���Ɋւ���ϐ�
    float stepCounter; // �����J�E���^�[
    public float bobSpeed = 10f; // �㉺���̑��x
    public float bobAmount = 0.1f; // �㉺���̗�
    Vector3 viewPointStartPosition; // �J�����̏����ʒu
    float bobbingOffset; // ���݂̏㉺���̃I�t�Z�b�g

    void Start()
    {
        playerCamera = Camera.main; // �J������ϐ��ɑ��
        viewPointStartPosition = viewPoint.transform.localPosition; // �v���C���[�̎��_�����߂�I�u�W�F�N�g��ϐ��ɑ��
        playerRigidbody = GetComponent<Rigidbody>(); // Rigidbody��ϐ��ɑ��
        landAudioSource = GetComponent<AudioSource>(); // ������ϐ��ɑ��
        jumpAudioSource = GetComponent<AudioSource>(); // �W�����v����ϐ��ɑ��
    }

    void Update()
    {
        RotatePlayer(); // ���_�̈ړ��֐�
        MovePlayer(); // �v���C���[�̈ړ��֐�
        ControlPlayerSpeed(); // �v���C���[�̈ړ����x����֐�
        JumpPlayer(); // �v���C���[�̃W�����v�֐�
        UpdateWalkingSound(); // �������Đ�����֐�

        // �����ɍ��킹�Ď��_�J���������炩�ɏ㉺�����鏈��
        if (IsGround() && moveDirection.magnitude > 0)
        {
            // ���s���n�߂Ă���̎��ԁ~�㉺���̑��x����s�J�E���^�[�ɑ��
            stepCounter += Time.deltaTime * bobSpeed;

            // sin�g���g����Player�̎��_�̍���(y��)�����炩�ɏ㉺�ɓ���������
            bobbingOffset = Mathf.Sin(stepCounter) * bobAmount;
            viewPoint.transform.localPosition = viewPointStartPosition + new Vector3(0, bobbingOffset, 0);
        }
        else
        {
            stepCounter = 0; // ���s���Ă��Ȃ��ꍇ�̓J�E���^�[�����Z�b�g
            viewPoint.transform.localPosition = Vector3.Lerp(viewPoint.transform.localPosition, viewPointStartPosition, Time.deltaTime * bobSpeed); //�����ʒu�Ɋ��炩�ɖ߂�
        }
    }

    // �v���C���[�̎��_���ړ���̈ʒu�ƌ����ɔ��f�����鏈��
    void LateUpdate()
    {
        playerCamera.transform.position = viewPoint.position;
        playerCamera.transform.rotation = viewPoint.rotation;
    }

    // �v���C���[�̒��n����֐�
    public bool IsGround()
    { 
        // �����̑������牺��25cm��Raycast���΂��āA�n�ʂ̃��C�A�[�ɓ������True��Ԃ�
        return Physics.Raycast(groundCheckPoint.position, Vector3.down, 0.25f, groundLayers); 
    }

    // ���_�̈ړ��֐�
    public void RotatePlayer()
    {
        // �ϐ��Ƀ}�E�X�̓�����������
        mouseInput = new Vector2(Input.GetAxisRaw("Mouse X") * mouseSensitivity,Input.GetAxisRaw("Mouse Y") * mouseSensitivity);

        // �ϐ���x���̃}�E�X���͕��̐��l�𑫂�
        horizontalMouseInput += mouseInput.x;

        // �ϐ���y���̃}�E�X���͕��̐��l�𑫂�
        verticalMouseInput += mouseInput.y;

        // �ϐ��̐��l���ۂ߂�i�㉺�̎��_����j
        verticalMouseInput = Mathf.Clamp(verticalMouseInput, -60f, 60f);

        // ���_�̉���]
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, horizontalMouseInput, transform.eulerAngles.z);

        // ���_�̏c��]
        viewPoint.rotation = Quaternion.Euler(-verticalMouseInput, viewPoint.transform.rotation.eulerAngles.y, viewPoint.transform.rotation.eulerAngles.z);
    }

    // �v���C���[�̈ړ��֐�
    public void MovePlayer()
    {
        // �ϐ��ɐ��������̈ړ��L�[(WASD+���L�[)�̓�����������
        movekeyInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        // �v���C���[�̈ړ�������������
        moveDirection = ((transform.forward * movekeyInput.z) + (transform.right * movekeyInput.x)).normalized;

        // ���̈ʒu�Ɉړ������ƈړ��X�s�[�h�ƑO��̈ړ�����̎��Ԃ��|�����킹���l��������
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    // �v���C���[�̈ړ����x����֐�
    public void ControlPlayerSpeed()
    {
        // Shift�L�[��������Ă���Ƃ��͑����Ă����Ԃɂ���
        if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            moveSpeed = runSpeed; // �ړ��X�s�[�h�ɑ����Ă���Ƃ��̃X�s�[�h����
            landAudioSource.pitch = 1.2f; // �����̃s�b�`��1.2�{�ɂ���
        }
        // Shift�L�[��������Ă��Ȃ��Ƃ��͕����Ă����Ԃɂ���
        else
        {
            moveSpeed = walkSpeed; // �ړ��X�s�[�h�ɕ����Ă���Ƃ��̃X�s�[�h����
            landAudioSource.pitch = 1.0f; // �����̃s�b�`��1.0�{�ɂ���
        }
    }

    // �������Đ�����֐�
    private void UpdateWalkingSound()
    {
        // �����Ă��邩�ǂ����𔻒f���A�������Đ�
        if (IsGround() && moveDirection.magnitude > 0 && !landAudioSource.isPlaying)
        {
            landAudioSource.PlayOneShot(landSound);
        }
    }

    // �v���C���[�̃W�����v�֐�
    public void JumpPlayer()
    {
        // �n�ʂւ̒��n���肪����ASpace�L�[�������ꂽ�Ƃ�
        if (IsGround() && Input.GetKeyDown(KeyCode.Space))
        {
            // �W�����v�����Đ�����
            jumpAudioSource.PlayOneShot(jumpSound);
            // �u�ԓI�Ȑ^��ւ̗͂�������
            playerRigidbody.AddForce(0, jumpForce, 0, ForceMode.Impulse);
        }
    }

}
