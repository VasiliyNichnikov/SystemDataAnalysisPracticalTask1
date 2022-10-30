namespace PracticalTask1
{
    public class ServerProgrammer : EmployeeBase
    {
        public ServerProgrammer(
            string name,
            string surname,
            string middleName,
            int age,
            float salary,
            int phoneNumber,
            DevelopmentDepartment department) : base(name, surname, middleName, age, salary, phoneNumber)
        {
        }

        public override bool CheckDepartment(DepartmentBase department)
        {
            return department is DevelopmentDepartment;
        }
    }
}