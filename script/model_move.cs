using UnityEngine;

public class model_move : MonoBehaviour
{
    public float speed = 0.3f; // 移動速度
    public Vector3 movementRange = new Vector3(2f, 2f, 2f); // 隨機移動範圍
    public Vector3 rotationSpeedRange = new Vector3(10f, 10f, 10f); // 隨機旋轉速度範圍

    private Vector3 targetPosition; // 當前目標位置
    private Vector3 rotationSpeed; // 當前旋轉速度

    void Start()
    {
        // 初始化隨機目標位置和旋轉速度
        SetRandomTargetPosition();
        SetRandomRotationSpeed();
    }

    void Update()
    {
        // 獨立移動到目標位置
        MoveToTarget();

        // 獨立旋轉
        ContinuousRotation();

        // 如果接近目標位置，重新生成目標
        if (Vector3.Distance(transform.position, targetPosition) < 0.05f)
        {
            SetRandomTargetPosition();
        }
    }

    void SetRandomTargetPosition()
    {
        // 為每個物件生成獨立的隨機目標位置
        float randomX = Random.Range(-movementRange.x, movementRange.x);
        float randomY = Random.Range(movementRange.y, movementRange.y + 2);
        float randomZ = Random.Range(-movementRange.z, movementRange.z);

        targetPosition = new Vector3(randomX, randomY, randomZ);
    }

    void SetRandomRotationSpeed()
    {
        // 為每個物件生成獨立的旋轉速度
        float randomX = Random.Range(-rotationSpeedRange.x, rotationSpeedRange.x);
        float randomY = Random.Range(-rotationSpeedRange.y, rotationSpeedRange.y);
        float randomZ = Random.Range(-rotationSpeedRange.z, rotationSpeedRange.z);

        rotationSpeed = new Vector3(randomX, randomY, randomZ);
    }

    void MoveToTarget()
    {
        // 獨立移動到目標位置
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

    void ContinuousRotation()
    {
        // 獨立旋轉
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
