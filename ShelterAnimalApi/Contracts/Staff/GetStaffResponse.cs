﻿namespace ShelterAnimalApi.Contracts.Staff
{
    public class GetStaffResponse
    {
        public int StaffId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
