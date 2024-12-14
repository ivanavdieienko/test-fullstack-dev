using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField]
    private GameConfig gameConfig;

    [SerializeField]
    private UiConfig uiConfig;

    public override void InstallBindings()
    {
        Container.Bind<Item>().AsTransient();
        Container.Bind<ItemModel>().AsTransient();

        Container.Bind<GameConfig>().FromInstance(gameConfig).AsSingle();
        Container.Bind<UiConfig>().FromInstance(uiConfig).AsSingle();

        Container.Bind<PopupManager>().AsSingle();
        Container.Bind<ServerCommunicator>().AsSingle();
    }
}