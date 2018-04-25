using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CCharacterHealth : CHealth
{
    public int _hp = 100;
    public Text _healthText;
    public Image _healthProfileImage;
    public Animation _backAnim;

    public Image _targetImage;
    public Text _messageText;
    public Transform _charcterControl;

    public override void Damage(int viewId)
    {
        _hp -= Random.Range(5, 8);

        if (_hp <= 0)
        {
            _hp = 0;
            UpdateHealthCount();
            GetComponentInParent<Collider>().enabled = false;
            _targetImage.enabled = false;
            _messageText.text = "다음기회에 도전하세요";
            GetComponent<Transform>().SetParent(_charcterControl);
            photonView.RPC("PlayStateAnimation", PhotonTargets.All, CAnimation.STATE.DIE, photonView.ownerId);

            Invoke("StartGame", 10);
            return;
        }

        UpdateHealthCount();
        _backAnim.Play();
        photonView.RPC("PlayStateAnimation", PhotonTargets.All, CAnimation.STATE.DAMAGE, photonView.ownerId);
    }

    void UpdateHealthCount()
    {
        float percentage = (float)(_hp * 0.01);
        _hpProgress.fillAmount = percentage;
        _healthProfileImage.fillAmount = percentage;
        _healthText.text = _hp + " / 100";
    }

    void StartGame()
    {
        PhotonNetwork.LeaveRoom();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }

}
