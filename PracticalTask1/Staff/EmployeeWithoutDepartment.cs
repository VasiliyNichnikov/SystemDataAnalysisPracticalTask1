using System.Linq;

namespace PracticalTask1
{
    public class EmployeeWithoutDepartment : EmployeeBase
    {
        public EmployeeWithoutDepartment(string name, string surname, string middleName, int age, float salary, long phoneNumber) : base(name, surname, middleName, age, salary, phoneNumber)
        {
        }

        public override bool CheckDepartment(DepartmentBase department)
        {
            throw new System.NotImplementedException();
        }

        protected override string GetInheritanceEmployee()
        {
            return "Сотрудник->Нет отдела";
        }

        public EmployeeBase RecreateWithDepartment(TypeDepartment department)
        {
            if (department == TypeDepartment.None)
            {
                return this;
            }

            var creatorEmployee = EmployeeCreator.GetCreator(department);
            creatorEmployee.Init(
                    new DataBaseEmployee
                    {
                        Name = this.Name,
                        Surname = this.Surname,
                        MiddleName = this.MiddleName,
                        Age = this.Age,
                        Salary = this.Salary,
                        PhoneNumber = this.PhoneNumber
                    }
                );
            creatorEmployee.SetDepartment(Department);
            creatorEmployee.SetSubordinates(Subordinates.ToArray());
            return creatorEmployee.Create();
        }
    }
}