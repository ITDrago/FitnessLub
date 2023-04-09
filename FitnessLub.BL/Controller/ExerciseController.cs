using FitnessLub.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessLub.BL.Controller
{
    public class ExerciseController : ControllerBase
    {
        private const string EXERCISES_FILE_NAME = "exercises.dat";
        private const string ACTIVITIES_FILE_NAME = "activities.dat";

        private readonly User user;

        public List<Exercise> Exercises { get; }

        public List<Activity> Activities { get; }



        public ExerciseController(User user)
        {
            this.user = user ?? throw new ArgumentNullException(nameof(user));
            Exercises = GetAllExercises();
            Activities = GetAllActivities();
        }

        public List<Activity> GetAllActivities()
        {
            return Load<List<Activity>>(ACTIVITIES_FILE_NAME) ?? new List<Activity>();
        }

        public void Add(Activity activity, DateTime begin, DateTime end)
        {
            var act = Activities.SingleOrDefault(a => a.Name == activity.Name);
            if (act == null)
            {
                Activities.Add(activity);
                var exercise = new Exercise(begin, end, activity, user);
                Exercises.Add(exercise);
            }
            else
            {
                var exercise = new Exercise(begin, end, activity, user);
                Exercises.Add(exercise);
            }
            Save();
        }

        public List<Exercise> GetAllExercises()
        {
            return Load<List<Exercise>>(EXERCISES_FILE_NAME) ?? new List<Exercise>();
        }

        private  void Save()
        {
             Save(EXERCISES_FILE_NAME, Exercises);
            Save(ACTIVITIES_FILE_NAME, Activities);

        }
    }
}
