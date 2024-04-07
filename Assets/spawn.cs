using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] objectsToRespawn; // ���X�|�[��������GameObject�̃��X�g
    public Vector3 initialPosition; // �����ʒu

    void Start()
    {
        initialPosition = transform.position; // �����ʒu��ۑ�
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("top")) // ���ʂƂ̐ڐG���`�F�b�N
        {
            RespawnRandom(); // �����_���ȃI�u�W�F�N�g�����X�|�[��
        }
    }

    void RespawnRandom()
    {
        if (objectsToRespawn.Length > 0)
        {
            int randomIndex = Random.Range(0, objectsToRespawn.Length); // �����_���ȃC���f�b�N�X��I��
            GameObject objectToRespawnPrefab = objectsToRespawn[randomIndex]; // �����_���ɑI������Prefab

            // �����ʒu��Prefab�𐶐����ă��X�|�[��
            GameObject spawnedObject = Instantiate(objectToRespawnPrefab, initialPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("No objects to respawn."); // ���X�|�[������I�u�W�F�N�g���Ȃ��ꍇ�͌x����\��
        }
    }
}