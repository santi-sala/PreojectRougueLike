using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashSpriteFeedback : Feedback
{
    [SerializeField]
    private SpriteRenderer _spriteRenderer = null;
    [SerializeField]
    private float _flashTime = 0.1f;
    [SerializeField]
    private Material _flashMaterial = null;

    private Shader _originalMaterialShader;

    private void Start()
    {
        _originalMaterialShader = _spriteRenderer.material.shader;
    }

    public override void CompletePreviousFeedBack()
    {
        StopAllCoroutines();
        _spriteRenderer.material.shader = _originalMaterialShader;
    }

    public override void CreateFeedBack()
    {
        if (_spriteRenderer.material.HasProperty("_MakeSolidColor") == false)
        {
            _spriteRenderer.material.shader = _flashMaterial.shader;
        }

        _spriteRenderer.material.SetInt("_MakeSolidColor", 1);

        StartCoroutine(WaitBeforeChangingBack());
    }

    IEnumerator WaitBeforeChangingBack()
    {
        yield return new WaitForSeconds(_flashTime);

        if (_spriteRenderer.material.HasProperty("_MakeSolidColor"))
        {
            _spriteRenderer.material.SetInt("_MakeSolidColor", 0);
        }
        else
        {
            _spriteRenderer.material.shader = _originalMaterialShader;
        }
    }
}
