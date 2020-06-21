using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckRestService
{
    class PersonInfo
    {
        public int Id { get; set; }
        public long Iin { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Otchestvo { get; set; }
        public DateTime DateBirthday { get; set; }

        public PersonInfo()
        {
            
        }
        public PersonInfo(long iin, string firstName, string lastName, string otchestvo, DateTime dateBirthday)
        {
            this.Iin = iin;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Otchestvo = otchestvo;
            this.DateBirthday = dateBirthday;
        }
    }
}
