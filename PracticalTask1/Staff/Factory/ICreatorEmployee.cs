using System;
using System.Collections.Generic;

namespace PracticalTask1
{
    public interface ICreatorEmployee
    {
        void Init(DataBaseEmployee dataBase);
        ICreatorEmployee SetDepartment(DepartmentBase department);
        ICreatorEmployee SetSubordinates(EmployeeBase[] subordinates);
        EmployeeBase Create();
    }

    public abstract class BaseCreatorEmployee: ICreatorEmployee
    {
        protected DataBaseEmployee DataBase { get; private set; }
        protected DepartmentBase Department { get; private set; }
        protected EmployeeBase[] Subordinates { get; private set; }
        
        public void Init(DataBaseEmployee dataBase)
        {
            DataBase = dataBase;
        }

        public ICreatorEmployee SetDepartment(DepartmentBase department)
        {
            Department = department;

            return this;
        }

        public ICreatorEmployee SetSubordinates(EmployeeBase[] subordinates)
        {
            Subordinates = subordinates;

            return this;
        }

        public abstract EmployeeBase Create();
    }

    public class ClientProgrammerCreator : BaseCreatorEmployee
    {
        public override EmployeeBase Create()
        {
            var createdEmployee = new ClientProgrammer(
                DataBase.Name,
                DataBase.Surname,
                DataBase.MiddleName,
                DataBase.Age,
                DataBase.Salary,
                DataBase.PhoneNumber
            );
            if (Department != null)
            {
                createdEmployee.SetDepartment(Department);
            }

            if (Subordinates != null)
            {
                createdEmployee.AddSubordinate(Subordinates);
            }

            return createdEmployee;
        }
    }

    public class ArtistCreator : BaseCreatorEmployee
    {
        public override EmployeeBase Create()
        {
            var createdEmployee = new Artist(
                DataBase.Name,
                DataBase.Surname,
                DataBase.MiddleName,
                DataBase.Age,
                DataBase.Salary,
                DataBase.PhoneNumber
            );
            if (Department != null)
            {
                createdEmployee.SetDepartment(Department);
            }
            
            if (Subordinates != null)
            {
                createdEmployee.AddSubordinate(Subordinates);
            }

            return createdEmployee;
        }
    }

    public class MarketingSpecialistCreator : BaseCreatorEmployee
    {
        public override EmployeeBase Create()
        {
            var createdEmployee = new MarketingSpecialist(
                DataBase.Name,
                DataBase.Surname,
                DataBase.MiddleName,
                DataBase.Age,
                DataBase.Salary,
                DataBase.PhoneNumber
            );
            if (Department != null)
            {
                createdEmployee.SetDepartment(Department);
            }
            if (Subordinates != null)
            {
                createdEmployee.AddSubordinate(Subordinates);
            }

            return createdEmployee;
        }
    }

    public class TesterCreator : BaseCreatorEmployee
    {
        public override EmployeeBase Create()
        {
            var createdEmployee = new Tester(
                DataBase.Name,
                DataBase.Surname,
                DataBase.MiddleName,
                DataBase.Age,
                DataBase.Salary,
                DataBase.PhoneNumber
            );
            if (Department != null)
            {
                createdEmployee.SetDepartment(Department);
            }
            
            if (Subordinates != null)
            {
                createdEmployee.AddSubordinate(Subordinates);
            }

            return createdEmployee;
        }
    }

    public class EmployeeWithoutDepartmentCreator : BaseCreatorEmployee
    {
        public override EmployeeBase Create()
        {
            var createdEmployee = new EmployeeWithoutDepartment(
                DataBase.Name,
                DataBase.Surname,
                DataBase.MiddleName,
                DataBase.Age,
                DataBase.Salary,
                DataBase.PhoneNumber
            );
            if (Department != null)
            {
                createdEmployee.SetDepartment(Department);
            }
            if (Subordinates != null)
            {
                createdEmployee.AddSubordinate(Subordinates);
            }

            return createdEmployee;
        }
    }

    public static class EmployeeCreator
    {
        private static readonly IDictionary<TypeDepartment, ICreatorEmployee> _creator =
            new Dictionary<TypeDepartment, ICreatorEmployee>()
            {
                { TypeDepartment.ClientProgrammer, new ClientProgrammerCreator() },
                { TypeDepartment.Artist, new ArtistCreator() },
                { TypeDepartment.MarketingSpecialist, new MarketingSpecialistCreator() },
                { TypeDepartment.Tester, new TesterCreator() },
                { TypeDepartment.None , new EmployeeWithoutDepartmentCreator()}
            };

        public static ICreatorEmployee GetCreator(TypeDepartment type)
        {
            if (_creator.ContainsKey(type) == false)
            {
                throw new Exception(); // todo отфилтровать ошибку
            }

            var selectedCreator = _creator[type];
            return selectedCreator;
        }
    }
}