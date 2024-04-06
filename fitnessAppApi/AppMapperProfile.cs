using AutoMapper;
using fitnessAppApi.DTO;
using fitnessAppApi.Models;

namespace fitnessAppApi
{
    public class AppMapperProfile: Profile
    {
        public AppMapperProfile()
        {
            CreateMap<DTOProgram, Models.Program>();
            CreateMap<DTOProgramMove, ProgramMove>();
            CreateMap<Models.Program, DTOProgram>();
            CreateMap<ProgramMove, DTOProgramMove>();
            CreateMap<Workout, DTOWorkout>();
            CreateMap<WorkoutMove, DTOWorkoutMove>();
            CreateMap<DTOWorkout, Workout>();
            CreateMap<DTOWorkoutMove, WorkoutMove>();
        }
    }
}
