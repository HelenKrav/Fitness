using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Fitness.BL.Controller
{
    public class ExerciseController: BaseSQLController
    {
        private readonly User user;

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
        public void AddExercise(Activity activity, DateTime start, DateTime finish)   // 3 перегрузки (2- старт и длительность) 3- продолжительность  от момента ввода
        {
            var act = Activities.SingleOrDefault(a=>a.NameActivity == activity.NameActivity);
            if (act == null)
            {
                Activities.Add(activity);
                var exercise = new Exercise(start, finish, activity, user);
                Exercises.Add(exercise);
            }
            else
            {
                var exercise = new Exercise(start, finish, act, user);
                Exercises.Add(exercise);
            }
            SaveExercise();

        }

        /// <summary>
        /// Список  активностей.
        /// </summary>
        /// <returns></returns>
        private List<Activity> GetAllActivities()
        {
            return Load<Activity>() ?? new List<Activity>();
        }

        /// <summary>
        /// Список упражнений.
        /// </summary>
        /// <returns></returns>
        private List<Exercise> GetAllExercises()
        {
            return Load<Exercise>() ?? new List<Exercise>();
        }

        /// <summary>
        /// Сохранить.
        /// </summary>
        private void SaveExercise()
        {
            Save(Exercises.LastOrDefault());
            Save(Activities.LastOrDefault());
        }
    }
}
