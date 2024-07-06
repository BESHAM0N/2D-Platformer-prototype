using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _damageTextPrefab;
    [SerializeField] private GameObject _healthTextPrefab;
    [SerializeField] private Canvas _canvas;

    private void Awake()
    {
        _canvas = FindObjectOfType<Canvas>();
    }

    private void OnEnable()
    {
        CharacterEvents.characterDamaged += CharacterTookDamage;
        CharacterEvents.characterHealed += CharacterHealed;
    }

    private void OnDisable()
    {
        CharacterEvents.characterDamaged -= CharacterTookDamage;
        CharacterEvents.characterHealed -= CharacterHealed;
    }

    public void CharacterTookDamage(GameObject character, int damageReceived)
    {
        Vector3 spawnPosition = Camera.main.WorldToScreenPoint(character.transform.position);
        TMP_Text tmpText = Instantiate(_damageTextPrefab, spawnPosition, Quaternion.identity, _canvas.transform)
            .GetComponent<TMP_Text>();

        tmpText.text = damageReceived.ToString();
    }

    public void CharacterHealed(GameObject character, int healthRestored)
    {
        Vector3 spawnPosition = Camera.main.WorldToScreenPoint(character.transform.position);
        TMP_Text tmpText = Instantiate(_healthTextPrefab, spawnPosition, Quaternion.identity, _canvas.transform)
            .GetComponent<TMP_Text>();

        tmpText.text = healthRestored.ToString();
    }

    public void OnExit(InputAction.CallbackContext context)
    {
#if(UNITY_EDITOR || DEVELOPMENT_BUILD)
        Debug.Log($"{this.name}:{GetType()}:{System.Reflection.MethodBase.GetCurrentMethod().Name}");
#endif

#if(UNITY_EDITOR)
        UnityEditor.EditorApplication.isPlaying = false;
#elif (UNITY_STANDALONE)
        Application.Quit();
#elif (UNITY_WEBGL)
        SceneManager.LoadScene("QuitScene");
#endif
    }
}