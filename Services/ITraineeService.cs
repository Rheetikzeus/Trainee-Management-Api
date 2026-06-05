using TraineeManagement.Models;
using TraineeManagement.Dtos;

namespace TraineeManagement.Services;


public interface ITraineeService
{
    public List<TraineeResponse> GetAll();

    public TraineeResponse? GetById(int id);

    public TraineeResponse Create(TraineeCreateRequest traineeCreateRequest);

    public TraineeResponse? Update(int Id, TraineeUpdateRequest traineeUpdateRequest);

    public bool Delete(int Id);


}