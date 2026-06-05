using Microsoft.AspNetCore.Mvc;
using TraineeManagement.Models;
using TraineeManagement.Dtos;

namespace TraineeManagement.Controllers;

[ApiController]
[Route("/api/trainee")]
public class TraineeController : ControllerBase
{
    private static int UniqueId = 1;
    private static List<Trainee> trainees = new List<Trainee>
    {
        new Trainee{Id = 0, FirstName = "Rheetik", LastName = "Sharma", Email = "rheetiksharma@gmail.com", TechStack = "HTML, CSS, JS", Status = "Active", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now}
    };

    [HttpGet]
    public IActionResult GetAll() 
    {
        var response =  trainees.Select(t => new TraineeResponse{
            FirstName = t.FirstName,
            LastName = t.LastName,
            Email = t.Email,
            TechStack = t.TechStack,
            Status = t.Status,
        });

        return Ok(response);
    }

    [HttpGet("{Id:int}")]
    public IActionResult GetById(int Id)
    {
        Trainee trainee = trainees.FirstOrDefault(t => t.Id == Id);
        if(trainee == null)return NotFound();
        var response = new TraineeResponse{
            FirstName = trainee.FirstName,
            LastName = trainee.LastName,
            Email = trainee.Email,
            TechStack = trainee.TechStack,
            Status = trainee.Status
        };
        return Ok(response);
    }

    [HttpPost]
    public Trainee Create(TraineeCreateRequest traineeCreateRequest)
    {
        
        Trainee trainee = new Trainee{
            Id = UniqueId,
            FirstName = traineeCreateRequest.FirstName,
            LastName = traineeCreateRequest.LastName,
            Email = traineeCreateRequest.Email,
            TechStack = traineeCreateRequest.TechStack,
            Status = traineeCreateRequest.Status,
            CreatedDate = DateTime.Now,
            UpdatedDate = DateTime.Now
        };
        UniqueId = UniqueId + 1;
        trainees.Add(trainee);
        return trainee;
    }
}
