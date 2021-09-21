using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeSharingAPI.Models
{
    public class testUserModel
    {
        public testUserModel(string name)
        {
            this.Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
