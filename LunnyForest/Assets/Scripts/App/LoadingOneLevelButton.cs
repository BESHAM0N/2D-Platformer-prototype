using System;
using UnityEngine.UI;
using Zenject;

public class LoadingOneLevelButton : IInitializable, IDisposable
{
    private readonly Button _button;
    private readonly LoadingLevel _loadingLevel;

    public LoadingOneLevelButton(Button button, LoadingLevel loadingLevel)
    {
        this._button = button;
        this._loadingLevel = loadingLevel;
    }

    void IInitializable.Initialize()
    {
        this._button.onClick.AddListener(this.OnButtonClicked);
    }

    void IDisposable.Dispose()
    {
        this._button.onClick.RemoveListener(this.OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        this._loadingLevel.LoadLevel();
    }
}
