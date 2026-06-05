using TraineeManagement.Models;
using TraineeManagement.Dtos;

namespace TraineeManagement.Services;

public class TraineeService : ITraineeService
{
    private static List<Trainee> trainees = new List<Trainee>();

    public List<TraineeResponse> GetAll() 
    {
        List<TraineeResponse> traineeResponseList =  trainees.Select(t => new TraineeResponse(t)).ToList();
        return traineeResponseList;
    }

    public TraineeResponse? GetById(int Id)
    {
        Trainee? trainee = trainees.FirstOrDefault(t => t.Id == Id);
        if(trainee == null)return null;
        return new TraineeResponse(trainee);
    }

    public TraineeResponse Create(TraineeCreateRequest traineeCreateRequest)
    {
        Trainee trainee = new Trainee(traineeCreateRequest);
        trainees.Add(trainee);
        return new TraineeResponse(trainee);
    }

    public TraineeResponse? Update(int Id, TraineeUpdateRequest traineeUpdateRequest)
    {
        Trainee? trainee = trainees.FirstOrDefault(t => t.Id == Id);
        if(trainee == null) return null;
        trainee.FirstName = traineeUpdateRequest.FirstName;
        trainee.LastName = traineeUpdateRequest.LastName;
        trainee.Email = traineeUpdateRequest.Email;
        trainee.TechStack = traineeUpdateRequest.TechStack;
        trainee.Status = traineeUpdateRequest.Status;
        trainee.UpdatedDate = DateTime.UtcNow;
        return new TraineeResponse(trainee);
    }

    public bool Delete(int Id)
    {
        Trainee? trainee = trainees.FirstOrDefault(t => t.Id == Id);
        if(trainee == null) return false;
        trainees.Remove(trainee);
        return true;
    }
}