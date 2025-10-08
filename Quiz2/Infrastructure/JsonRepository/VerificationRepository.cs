using Domain.Entities;
using Newtonsoft.Json;
using Quiz2.Contracts.Repository_Interfaces;

namespace Infrastructure.Json_Repository;

public class VerificationRepository(string path) : IVerificationRepository
{
    private readonly string _path = path;


    private void SaveCodeToFile(VerificationCode verificationCode)
    {
        var json = JsonConvert.SerializeObject(verificationCode);
        File.WriteAllText(path, json);
    }


    public VerificationCode Create()
    {
        var verificationCode = new VerificationCode();
        var json = JsonConvert.SerializeObject(verificationCode);
        File.WriteAllText(path, json);
        return verificationCode;
    }

    public VerificationCode GetVerificationCode()
    {
        string json = File.ReadAllText(path);
        return JsonConvert.DeserializeObject<VerificationCode>(json)!;
    }
}