namespace PracticalTask1
{
    public class DeveloperProgrammer : EmployeeBase
    {
        public DeveloperProgrammer(
            string name,
            string surname,
            string middleName,
            int age,
            float salary,
            long phoneNumber) : base(name, surname, middleName, age, salary, phoneNumber)
        {
        }

        public override bool CheckDepartment(DepartmentBase department)
        {
            return department is DevelopmentDepartment;
        }

        protected override string GetInheritanceEmployee()
        {
            return "Сотрудник->Разработчик";
        }
    }
}