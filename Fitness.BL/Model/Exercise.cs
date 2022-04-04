using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Fitness.BL.Model
{
    [Serializable]
    public class Exercise
    {
        public int Id { get; set; }

        /// <summary>
        /// Начало упражнения.
        /// </summary>
        public DateTime Start { get; set; }

        /// <summary>
        /// Окончание активности.
        /// </summary>
        public DateTime Finish { get; set; }

        /// <summary>
        /// Активность.
        /// </summary>
        [XmlIgnoreAttribute]
        public virtual Activity Activity { get; set; }        

        public int ActivityId { get; set; }

        public int UserId { get; set; }

        /// <summary>
        /// Текущий пользователь.
        /// </summary>
        [XmlIgnoreAttribute]
        public virtual User User { get; set; }


        public Exercise()
        {

        }

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
