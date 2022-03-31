using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Controller
{
    public class ExerciseController: BaseController
    {
        private readonly User user;
        private const string  EXERCISES_FILE_NAME = "exercises.dat";
        private const string ACTIVITY_FILE_NAME = "activities.dat";

        public List<Exercise> Exercises { get; }  //Ienumerable  //приватный список, а публичны уже ридонли
        public List<Activity> Activities { get; }

        public ExerciseController(User user)
        {
            this.user = user ?? throw new ArgumentNullException(nameof(user));

            Exercises = GetAllExercises();
            Activities = GetAllActivities();
        }

        /// <summary>
        /// Добавить активность
        /// </summary>
        /// <param name="activity"></param>
        /// <param name="start"></param>
        /// <param name="finish"></param>
        public void Add(Activity activity, DateTime start, DateTime finish)   // 3 перегрузки (2- старт и длительность) 3- продолжительность  от момента ввода
        {
            var act = Activities.SingleOrDefault(a=>a.NameActivity == activity.NameActivity);
            if (act == null)
            {
                Activities.Add(activity);
                var exercise = new Exercise(start, finish, activity, user);
                Exercises.Add(exercise);

                Save();
            }
            else
            {
                var exercise = new Exercise(start, finish, act, user);
                Exercises.Add(exercise);
            }
            Save();

        }

        /// <summary>
        /// Список  активностей.
        /// </summary>
        /// <returns></returns>
        private List<Activity> GetAllActivities()
        {
            return Load<List<Activity>>(EXERCISES_FILE_NAME) ?? new List<Activity>();
        }

        /// <summary>
        /// Список упражнений.
        /// </summary>
        /// <returns></returns>
        private List<Exercise> GetAllExercises()
        {
            return Load<List<Exercise>>(EXERCISES_FILE_NAME) ?? new List<Exercise>();
        }

        /// <summary>
        /// Сохранить.
        /// </summary>
        private void Save()
        {
            Save(EXERCISES_FILE_NAME, Exercises);
            Save(ACTIVITY_FILE_NAME, Activities);
        }
    }
}
