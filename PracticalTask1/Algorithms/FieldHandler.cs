using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace PracticalTask1.Algorithms
{
    public class FieldHandler<T> where T : class
    {
        public struct FieldExpansion
        {
            public FieldInfo FieldInfo  { get; set; }

            public object SearchValue { get; set; }
            // todo Нужно еще узнать значение поля, но для этого нужен вызываемый объект
        }
        private readonly Dictionary<string, FieldExpansion> _searchData = new();

        /// <summary>
        /// Возвращает названия полей, которые можно использовать для поиска
        /// </summary>
        /// <returns></returns>
        public string[] GetSearchFields()
        {
            var fieldsInfo = GetFieldsInfo();
            IList<string> returnNameFields = new Collection<string>();
            foreach (var field in fieldsInfo)
            {
                if (CheckFieldType(field.FieldType))
                {
                    returnNameFields.Add(field.Name);
                }
            }
            return returnNameFields.ToArray();
        }

        /// <summary>
        /// Проверям точно совпадение с конкретным объектом и собранными данными
        /// </summary>
        /// <param name="specificObject"></param>
        /// <returns></returns>
        public bool CheckSearchValueForSpecificObject(T specificObject)
        {
            var fieldsInfo = GetFieldsInfo();
            
            foreach (var field in fieldsInfo)
            {
                foreach (var kvp in _searchData)
                {
                    if (field.Name == kvp.Key)
                    {
                        if (field.GetValue(specificObject)?.Equals(kvp.Value.SearchValue) == false)
                        {
                            return false;
                        }
                    }
                    
                }
            }
            return true;
        }

        /// <summary>
        /// Выбираем поле, с помощью которого будем осуществлять поиски
        /// Кроме этого вводим значение которому нужно соответсвовать
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="searchValue"></param>
        public void SelectSearchField(string fieldName, object searchValue)
        {
            if (CheckObjectForTypeCompliance(searchValue) == false)
            {
                return; // todo наверно лучше выкидывать ошибку
            }
            
            var fieldsInfo = GetFieldsInfo();
            foreach (var field in fieldsInfo)
            {
                if (CheckFieldType(field.FieldType) && field.Name == fieldName)
                {
                    Console.WriteLine($"SearchData. Field name: {field.Name} added with search data: {searchValue}");
                    _searchData.Add(field.Name, 
                        new FieldExpansion
                        {
                            FieldInfo = field,
                            SearchValue = searchValue
                        });
                    return;
                }
            }

            throw new Exception(); // todo отфильтровать ошибку
        }
        
        private bool CheckFieldType(Type fieldType)
        {
            return fieldType == typeof(string) ||
                   fieldType == typeof(int) ||
                   fieldType == typeof(float);
        }

        private bool CheckObjectForTypeCompliance(object obj)
        {
            switch (obj)
            {
                case string:
                case int:
                case float:
                    return true;
                default:
                    return false;
            }
        }
        
        private FieldInfo[] GetFieldsInfo()
        {
            return typeof(T).GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
        }
    }
}