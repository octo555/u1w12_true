using SingularityGroup.HotReload;
using UnityEngine;

public class HorizontalDynamicImageRotation : MonoBehaviour
{
    [SerializeField] Transform _cameraTransform;
    // ���[�e�[�V��������Ƃ���1���̉摜�̕�
    [SerializeField] float _imageWidth;

    Transform _parentLayer;
    Transform _transformCache;

    private void Awake()
    {
        _parentLayer = this.GetParent().transform;
        _transformCache = transform;

        if (!_cameraTransform)
        {
            this.enabled = false;
        }
    }

    private void Update()
    {
        // 3���Ń��[�e�[�V��������̂ŃJ�����̕`��͈͂���1.5�������ꂽ�炻�̕����Ɉړ�����
        var distance = _cameraTransform.position - _transformCache.position;
        if (Mathf.Abs(distance.x) > _imageWidth * 1.5f)
        {
            float amount = _imageWidth * 3 * (distance.x < 0 ? -1.0f : 1.0f);
            _transformCache.AddLocalPosX(amount);
        }
    }
}

// ���[�e�B���e�B
public static class HorizontalDynamicImageRotationExtensions
{
    // �e���擾
    public static GameObject GetParent(this Component self)
    {
        return self.transform.parent.gameObject;
    }
    // X�����ɒl�𑫂�
    public static void AddLocalPosX(this Transform self, float x)
    {
        Vector3 vec3 = self.localPosition;
        vec3.x += x;
        self.localPosition = vec3;
    }
}