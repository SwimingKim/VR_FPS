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

    public void Damage()
    {
        UpdatePlayerState(Random.Range(5, 8));
    }

    void UpdatePlayerState(int count)
    {
        healthCount -= count;

        if (healthCount <= 0)
        {
            GetComponentInParent<Collider>().enabled = false;
            _targetImage.enabled = false;
            _messageText.text = "다음기회에 도전하세요";
            GetComponent<Transform>().SetParent(_charcterControl);
            UpdateHealthCount(0);
            photonView.RPC("PlayStateAnimation", PhotonTargets.All, CCharacterAnimation.ANIM_TYPE.DIE, photonView.ownerId);

            Invoke("StartGame", 10);
            return;
        }

        _backAnim.Play();
        UpdateHealthCount(healthCount);
        photonView.RPC("PlayStateAnimation", PhotonTargets.All, CCharacterAnimation.ANIM_TYPE.DAMAGE, photonView.ownerId);
    }

    void UpdateHealthCount(int count)
    {
        float percentage = (float)(count * 0.01);
        _healthImage.fillAmount = percentage;
        _healthProfileImage.fillAmount = percentage;
        _healthText.text = count + "/100";
    }

    void StartGame()
    {
        PhotonNetwork.LeaveRoom();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }

    [PunRPC]
    void PlayStateAnimation(CCharacterAnimation.ANIM_TYPE anim, int viewId)
    {
        _anim.PlayAnimation(anim);
    }

}
