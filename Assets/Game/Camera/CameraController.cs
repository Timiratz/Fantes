using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoSingleton<CameraController>
{
    [SerializeField] private GameObject player;                    // �v���C���[�I�u�W�F�N�g
    [SerializeField] private float distance = 5.0f;    // �v���C���[�Ƃ̏�������
    [SerializeField] private float zoomSpeed = 5.0f;    // �Y�[�����x
    [SerializeField] private float minDistance = 2.0f;    // �ŏ�����
    [SerializeField] private float maxDistance = 10.0f;   // �ő勗��
    [SerializeField] private float rotationSpeed = 5.0f;    // ��]���x
    [SerializeField] private float interpolationSpeed = 20.0f;   // ��ԑ��x�i�Œ�l�j

    private Vector3 offset;                                        // �v���C���[�Ƃ̑��ΓI�Ȉʒu�i�I�t�Z�b�g�j
    private GameObject enemy;                                      // ����I�u�W�F�N�g

    protected override void Awake()
    {
        // �����̃C���X�^���X������ꍇ�͔j��
        base.Awake();
        // �����I�t�Z�b�g���v�Z
        offset = transform.position - player.transform.position;
        // �����𐳋K�����ď��������ɍ��킹��
        offset = offset.normalized * distance;
    }

    void Update()
    {
        // ------�J�����̃Y�[������------ //
        HandleZoom();

        // ------�J�����̈ړ�����------ //
        if (!InputManager.Instance.IsCameraTarget)
        {
            HandleMovement();
        }

        // ------�J�����̉�]����------ //
        HandleRotation();
    }

    // �J�����̃Y�[������
    private void HandleZoom()
    {
        // �}�E�X�z�C�[�����͂��擾
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        // �����𒲐��i�Y�[�����x���|���ĉ����Z�j
        distance -= scroll * zoomSpeed;

        // �������ŏ��l�E�ő�l�ŃN�����v�i�͈͐����j
        distance = Mathf.Clamp(distance, minDistance, maxDistance);

        // �I�t�Z�b�g���X�V�i���݂̋����Ɋ�Â��j
        offset = offset.normalized * distance;
    }

    // �J�����̈ړ�����
    private void HandleMovement()
    {
        // �v���C���[�ʒu�ɃI�t�Z�b�g��������ނ����ʒu�ɃJ������z�u
        Vector3 targetPosition = player.transform.position + offset;


        // �J�����ʒu���X���[�Y�ɕ�Ԃ��Ĉړ�
        transform.position = Vector3.Lerp(transform.position, targetPosition, interpolationSpeed * Time.unscaledDeltaTime);
    }

    // �J�����̉�]����
    private void HandleRotation()
    {
        float mx = 0f;
        float my = 0f;
        // �R���g���[���[���ڑ�����Ă���ꍇ
        if (Gamepad.current != null)
        {
            // �E�X�e�B�b�N�̓��͒l���擾
            Vector2 rightStickInput = Gamepad.current.rightStick.ReadValue();

            mx += rightStickInput.x * rotationSpeed * 0.1f;  // �������iX���j�̉�]��
            my += rightStickInput.y * rotationSpeed * 0.1f;  // �c�����iY���j�̉�]��
        }

        // �}�E�X���͂�������ꍇ�i�I�v�V�����j
        mx += Input.GetAxis("Mouse X") * rotationSpeed;
        my += Input.GetAxis("Mouse Y") * rotationSpeed;

        // ����]�iY������j
        if (Mathf.Abs(mx) > 0.01f)
        {
            Quaternion rotationY = Quaternion.AngleAxis(mx, Vector3.up);
            offset = rotationY * offset;
        }

        // �c��]�iX������j
        if (Mathf.Abs(my) > 0.01f)
        {
            Quaternion rotationX = Quaternion.AngleAxis(-my, transform.right);
            Vector3 newOffset = rotationX * offset;

            float angleBetweenUpAndOffset = Vector3.Angle(Vector3.up, newOffset);
            if (angleBetweenUpAndOffset > 10.0f && angleBetweenUpAndOffset < 170.0f)
            {
                offset = newOffset;
            }
        }

        transform.LookAt(player.transform.position);
    }

    // �J�����̃^�[�Q�b�g����
    public void SetTarget(GameObject target)
    {
        enemy = target;

        if (enemy != null)
        {
            // �v���C���[�̌��ɃJ������z�u
            Vector3 playerPosition = player.transform.position;
            Vector3 directionToEnemy = (enemy.transform.position - playerPosition).normalized;

            // �v���C���[�̌��Ɉ�苗���ŃJ������z�u
            Vector3 cameraPosition = playerPosition - directionToEnemy * distance;

            // �J�����ʒu��ݒ�
            transform.position = cameraPosition;

            // �J�������G�̕���������悤�ɉ�]
            transform.LookAt(enemy.transform.position);
        }
    }

}
