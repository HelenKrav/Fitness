using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Model
{
    [Serializable]
    public class Exercise
    {
        /// <summary>
        /// Начало упражнения.
        /// </summary>
        public DateTime Start { get;  }
        /// <summary>
        /// Окончание активности.
        /// </summary>
        public DateTime Finish { get;  }
        /// <summary>
        /// Активность.
        /// </summary>
        public Activity Activity { get;  }
        /// <summary>
        /// Текущий пользователь.
        /// </summary>
        public User User { get;  }
       
        
        /// <summary>
        /// Упражнение.
        /// </summary>
        /// <param name="start"> Начало упражнения. </param>
        /// <param name="finish"> Окончание упражнения.</param>
        /// <param name="activity">Вид активности. </param>
        /// <param name="user"> Пользователь. </param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public Exercise(DateTime start, 
                        DateTime finish, 
                        Activity activity, 
                        User user)
        {

            if(start == null && start> DateTime.Now)
            {
                throw new ArgumentException("Время начала упражнения не может быть больше текущего времени или пустым", nameof(start));
            }
            if (finish == null && finish>DateTime.Now)
            {
                throw new ArgumentException("Время окончания упражнения не может быть больше текущего времени или пустым", nameof(finish));
            }

            Start = start;
            Finish = finish;
            Activity = activity ?? throw new ArgumentNullException("Активность не может быть пустым", nameof(activity));
            User = user ?? throw new ArgumentNullException("Пользователь не может быть пустым", nameof(user));
        }
    }
}
