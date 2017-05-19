using UnityEngine;

public abstract class AbstractBootstrapper : MonoBehaviour
{
    void Awake()
    {
		Unity3dIoCContainer container = new Unity3dIoCContainer();

        container.SetSingletonGameObject(this.gameObject.name);
        MonobehaviourExtensions.SetDependencyInjector(container);
        this.Configure(container);
    }

    public abstract void Configure(IIoCContainer container);
}
