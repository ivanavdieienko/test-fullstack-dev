using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class ServerCommunicator
{
    private const string ServerAddress = "https://wadahub.manerai.com/api/inventory/status";
    private const string AuthToken = "kPERnYcWAY46xaSy8CEzanosAgsWM84Nx7SKM4QBSqPq6c7StWfGxzhxPfDh8MaP";

    public async Task<string> SendRequest(string jsonData)
    {
        using UnityWebRequest request = new UnityWebRequest(ServerAddress, MethodType.POST);

        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonData);

        // define handlers for data upload/download
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();

        // Setting up headers
        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("Authorization", $"Bearer {AuthToken}");

        var operation = request.SendWebRequest();

        while (!operation.isDone)
        {
            await Task.Yield(); // wait for complete until next frame
        }

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError($"Error: {request.error}");
            return null;
        }
        else
        {
            return request.downloadHandler.text;
        }
    }
}