using System;
using System.Collections.Generic;
using System.Linq;
using Arnold_Web_GraphAPI.Models;
using Neo4j.Driver;

namespace Arnold_Web_GraphAPI
{
    public class Util
    {
        public List<WorkoutRoutine> MapToWorkout(List<IDictionary<string, object>>? workouts)
        {
            if (workouts != null)
                return workouts.Select(workout => new WorkoutRoutine(
                    workout["name"].As<string>(),
                    workout["duration"].As<string>(),
                    workout["difficulty"].As<int?>(),
                    workout["createdate"].As<DateTime?>(),
                    workout["creator"].As<string?>(),
                    MapToExercise(workout["exercises"].As<List<IDictionary<string, object>>?>())
                )).ToList();
            return new List<WorkoutRoutine>();
        }

        public List<Exercise> MapToExercise(List<IDictionary<string, object>>? exercises)
        {
            if (exercises != null)
                return exercises.Select(exercise => new Exercise(
                    exercise["name"].As<string>(),
                    exercise["category"].As<string>(),
                    exercise["compound"].As<bool?>()
                )).ToList();
            return new List<Exercise>();
        }
    }
}