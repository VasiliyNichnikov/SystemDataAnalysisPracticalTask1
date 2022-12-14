namespace PracticalTask1
{
    public class MarketingSpecialist : EmployeeBase
    {
        public MarketingSpecialist(
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
            return department is MarketingDepartment;
        }

        protected override string GetInheritanceEmployee()
        {
            return $"{Department.Name}->Маркетолог";
        }
    }
}