using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Wrapper;
using Domain.Interfaces;
using DataAccess.Repositories;


namespace DataAccess.Wrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private AnimalShelterContext _repoContext;

        private IUserRepository _user;
        private IAdopterRepository _adopter;
        private IAdoptionRepository _adoption;
        private IAnimalRepository _animal;
        private IAuditLogRepository _auditLog;
        private IBreedRepository _breed;
        private IDonationRepository _donation;
        private IEventRepository _event;
        private IEventAttendanceRepository _eventAttendance;
        private IExpenseRepository _expense;
        private IIncomeRepository _income;
        private IMedicalRecordRepository _medicalRecord;
        private IRoleRepository _role;
        private ISpeciesRepository _species;
        private IStaffRepository _staff;
        private ISupplyRepository _supply;
        private ISupplyOrderRepository _supplyOrder;
        private IUserRoleRepository _userRole;
        private IVaccinationRepository _vaccination;
        private IVolunteerRepository _volunteer;

        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_repoContext);
                }
                return _user;
            }
        }

        public IAdopterRepository Adopter
        {
            get
            {
                if (_adopter == null)
                {
                    _adopter = new AdopterRepository(_repoContext);
                }
                return _adopter;
            }
        }

        public IAdoptionRepository Adoption
        {
            get
            {
                if (_adoption == null)
                {
                    _adoption = new AdoptionRepository(_repoContext);
                }
                return _adoption;
            }
        }

        public IAnimalRepository Animal
        {
            get
            {
                if (_animal == null)
                {
                    _animal = new AnimalRepository(_repoContext);
                }
                return _animal;
            }
        }

        public IAuditLogRepository AuditLog
        {
            get
            {
                if (_auditLog == null)
                {
                    _auditLog = new AuditLogRepository(_repoContext);
                }
                return _auditLog;
            }
        }

        public IBreedRepository Breed
        {
            get
            {
                if (_breed == null)
                {
                    _breed = new BreedRepository(_repoContext);
                }
                return _breed;
            }
        }

        public IDonationRepository Donation
        {
            get
            {
                if (_donation == null)
                {
                    _donation = new DonationRepository(_repoContext);
                }
                return _donation;
            }
        }

        public IEventRepository Event
        {
            get
            {
                if (_event == null)
                {
                    _event = new EventRepository(_repoContext);
                }
                return _event;
            }
        }

        public IEventAttendanceRepository EventAttendance
        {
            get
            {
                if (_eventAttendance == null)
                {
                    _eventAttendance = new EventAttendanceRepository(_repoContext);
                }
                return _eventAttendance;
            }
        }

        public IExpenseRepository Expense
        {
            get
            {
                if (_expense == null)
                {
                    _expense = new ExpenseRepository(_repoContext);
                }
                return _expense;
            }
        }

        public IIncomeRepository Income
        {
            get
            {
                if (_income == null)
                {
                    _income = new IncomeRepository(_repoContext);
                }
                return _income;
            }
        }

        public IMedicalRecordRepository MedicalRecord
        {
            get
            {
                if (_medicalRecord == null)
                {
                    _medicalRecord = new MedicalRecordRepository(_repoContext);
                }
                return _medicalRecord;
            }
        }

        public IRoleRepository Role
        {
            get
            {
                if (_role == null)
                {
                    _role = new RoleRepository(_repoContext);
                }
                return _role;
            }
        }

        public ISpeciesRepository Species
        {
            get
            {
                if (_species == null)
                {
                    _species = new SpeciesRepository(_repoContext);
                }
                return _species;
            }
        }

        public IStaffRepository Staff
        {
            get
            {
                if (_staff == null)
                {
                    _staff = new StaffRepository(_repoContext);
                }
                return _staff;
            }
        }

        public ISupplyRepository Supply
        {
            get
            {
                if (_supply == null)
                {
                    _supply = new SupplyRepository(_repoContext);
                }
                return _supply;
            }
        }

        public ISupplyOrderRepository SupplyOrder
        {
            get
            {
                if (_supplyOrder == null)
                {
                    _supplyOrder = new SupplyOrderRepository(_repoContext);
                }
                return _supplyOrder;
            }
        }

        public IUserRoleRepository UserRole
        {
            get
            {
                if (_userRole == null)
                {
                    _userRole = new UserRoleRepository(_repoContext);
                }
                return _userRole;
            }
        }

        public IVaccinationRepository Vaccination
        {
            get
            {
                if (_vaccination == null)
                {
                    _vaccination = new VaccinationRepository(_repoContext);
                }
                return _vaccination;
            }
        }

        public IVolunteerRepository Volunteer
        {
            get
            {
                if (_volunteer == null)
                {
                    _volunteer = new VolunteerRepository(_repoContext);
                }
                return _volunteer;
            }
        }

        public RepositoryWrapper(AnimalShelterContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public async Task Save()
        {
            await _repoContext.SaveChangesAsync();
        }
    }
}
