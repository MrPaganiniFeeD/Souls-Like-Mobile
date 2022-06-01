using Infrastructure.Services;
using UnityEngine;

namespace Infrastructure.AssetsManagement
{
    public interface IAssets : IService
    {
        GameObject Instantiate(string namePrefab);
        GameObject Instantiate(string namePrefab, Vector3 position);

        GameObject InstantiateNonZenject(string namePrefab);
        GameObject InstantiateNonZenject(string namePrefab, Vector3 at);
    }   
}