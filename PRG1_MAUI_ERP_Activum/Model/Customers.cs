using System;
using System.Collections.Generic;
using System.Text;

namespace PRG1_MAUI_ERP_Activum.Model
{
    class Customers
    {
        public Guid Id { get; set; } = Guid.NewGuid(); 
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";
        public string Phone { get; set; } = "";
        public List<Guid> InsuranceId { get; set; } = new(); 

        public Customers(string firstName, string lastName, string email, string phone)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;

        }
    }
}
