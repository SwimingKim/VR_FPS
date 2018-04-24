using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CCharacterHealth : CHealth
{
    public Text _healthText;
    public Image _healthProfileImage;
    public Animation _backAnim;

    public Image _targetImage;
    public Text _messageText;
    public Transform _charcterControl;

    void Start()
    {
        _hp = 100;
        UpdateHealthCount(_hp);
    }

    protected override void Damage()
    {
		UpdatePlayerState(Random.Range(5, 8));
    }

    void UpdatePlayerState(int count)
    {
        _hp -= count;

        if (_hp <= 0)
        {
            GetComponentInParent<Collider>().enabled = false;
            _targetImage.enabled = false;
            _messageText.text = "다음기회에 도전하세요";
            GetComponent<Transform>().SetParent(_charcterControl);
            UpdateHealthCount(0);
            photonView.RPC("PlayStateAnimation", PhotonTargets.All, CAnimation.STATE.DIE, photonView.ownerId);

            Invoke("StartGame", 10);
            return;
        }

        _backAnim.Play();
        UpdateHealthCount(_hp);
        photonView.RPC("PlayStateAnimation", PhotonTargets.All, CAnimation.STATE.DAMAGE, photonView.ownerId);
    }

    void UpdateHealthCount(int count)
    {
        float percentage = (float)(count * 0.01);
        _hpProgress.fillAmount = percentage;
        _healthProfileImage.fillAmount = percentage;
        _healthText.text = count + "/100";
    }

    void StartGame()
    {
        PhotonNetwork.LeaveRoom();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }

}
