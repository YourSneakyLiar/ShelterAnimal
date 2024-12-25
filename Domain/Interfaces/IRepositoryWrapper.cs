using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Domain.Wrapper
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        IAdopterRepository Adopter { get; }
        IAdoptionRepository Adoption { get; }
        IAnimalRepository Animal { get; }
        IAuditLogRepository AuditLog { get; }
        IBreedRepository Breed { get; }
        IDonationRepository Donation { get; }
        IEventRepository Event { get; }
        IEventAttendanceRepository EventAttendance { get; }
        IExpenseRepository Expense { get; }
        IIncomeRepository Income { get; }
        IMedicalRecordRepository MedicalRecord { get; }
        IRoleRepository Role { get; }
        ISpeciesRepository Species { get; }
        IStaffRepository Staff { get; }
        ISupplyRepository Supply { get; }
        ISupplyOrderRepository SupplyOrder { get; }
        IUserRoleRepository UserRole { get; }
        IVaccinationRepository Vaccination { get; }
        IVolunteerRepository Volunteer { get; }
        Task Save();
    }
}
