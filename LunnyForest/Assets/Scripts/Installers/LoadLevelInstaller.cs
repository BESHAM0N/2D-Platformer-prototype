using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class LoadLevelInstaller : MonoInstaller
{
    [SerializeField] private Button _levelOne;

    public override void InstallBindings()
    {
        this.Container.BindInterfacesTo<LoadingOneLevelButton>().AsSingle().WithArguments(this._levelOne).NonLazy();
    }
}
