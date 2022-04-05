using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Controller
{
    public class GenderController:BaseSQLController
    {
        List<Gender> Genders { get; set; }

        public Gender CurrentGender { get; set; }

        public bool IsNewGender { get; } = false;

        public GenderController(string genderName)
        {
            if (string.IsNullOrEmpty(genderName))
            {
                throw new ArgumentNullException("Пол не может быть пустым", nameof(genderName));
            }

            Genders = GetGendersData();

            CurrentGender = Genders.SingleOrDefault(g => g.Name == genderName);
            if (CurrentGender == null)
            {
                CurrentGender = new Gender(genderName);
                Genders.Add(CurrentGender);
                IsNewGender = true;
                Save();
            }

        }

        private void Save()
        {
            Save(CurrentGender);
        }

        private List<Gender> GetGendersData()
        {
            return Load<Gender>() ?? new List<Gender>();
        }
    }
}
