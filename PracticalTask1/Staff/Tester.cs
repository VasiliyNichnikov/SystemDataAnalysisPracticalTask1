namespace PracticalTask1
{
    public class Tester : EmployeeBase
    {
        public Tester(
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
            return department is TestingDepartment;
        }
    }
}