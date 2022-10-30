using System;
using System.Collections.Generic;

namespace PracticalTask1
{
    public interface ICreatorDepartment
    {
        void Init(string name);
        DepartmentBase Create();
    }

    public class DesignDepartmentCreator : ICreatorDepartment
    {
        private string _name;

        public void Init(string name)
        {
            _name = name;
        }

        public DepartmentBase Create()
        {
            return new DesignDepartment(_name);
        }
    }

    public class DevelopmentDepartmentCreator : ICreatorDepartment
    {
        private string _name;

        public void Init(string name)
        {
            _name = name;
        }

        public DepartmentBase Create()
        {
            return new DevelopmentDepartment(_name);
        }
    }

    public class MarketingDepartmentCreator : ICreatorDepartment
    {
        private string _name;

        public void Init(string name)
        {
            _name = name;
        }

        public DepartmentBase Create()
        {
            return new MarketingDepartment(_name);
        }
    }

    public class TestingDepartmentCreator : ICreatorDepartment
    {
        private string _name;

        public void Init(string name)
        {
            _name = name;
        }

        public DepartmentBase Create()
        {
            return new TestingDepartment(_name);
        }
    }
    
    public static class DepartmentCreator
    {
        private static readonly IDictionary<TypeDepartment, ICreatorDepartment> _creator = new Dictionary<TypeDepartment, ICreatorDepartment>()
        {
            { TypeDepartment.MarketingSpecialist, new MarketingDepartmentCreator() },
            { TypeDepartment.ClientProgrammer, new DevelopmentDepartmentCreator() },
            { TypeDepartment.Tester, new TestingDepartmentCreator()},
            { TypeDepartment.Artist, new DesignDepartmentCreator()}
        };

        public static ICreatorDepartment GetCreator(TypeDepartment type)
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