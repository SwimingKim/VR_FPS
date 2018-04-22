using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CCharacterHealth : Photon.MonoBehaviour
{
    public Text _healthText;
    public Image _healthImage;
    public Image _healthProfileImage;
    public Animation _backAnim;
    
    public Image _targetImage;
    public Text _messageText;
    public Transform _charcterControl;

    CCharacterAnimation _anim;
    int healthCount = 100;

    void Awake()
    {
        _anim = GetComponent<CCharacterAnimation>();
    }

    void Start()
    {
        UpdateHealthCount(100);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            takeDamage(Random.Range(3, 8));
        }
    }

    public void takeDamage(int count)
    {
        healthCount -= count;

        if (healthCount <= 0)
        {
            _targetImage.enabled = false;
            _messageText.text = "다음기회에 도전하세요";
            photonView.RPC("Die", PhotonTargets.All, photonView.ownerId);
            return;
        }

        _backAnim.Play();
        photonView.RPC("Damage", PhotonTargets.All, healthCount, photonView.ownerId);
    }

    [PunRPC]
    public void Die(int viewId)
    {
        GetComponent<Transform>().SetParent(_charcterControl);
        UpdateHealthCount(0);
        _anim.PlayAnimation(CCharacterAnimation.ANIM_TYPE.DIE);
    }

    [PunRPC]
    void Damage(int count, int viewId)
    {
        _anim.PlayAnimation(CCharacterAnimation.ANIM_TYPE.DAMAGE);
        UpdateHealthCount(count);
    }

    void UpdateHealthCount(int count)
    {
        float percentage = (float)(count * 0.01);
        _healthImage.fillAmount = percentage;
        _healthProfileImage.fillAmount = percentage;
        _healthText.text = count + "/100";
    }

}
