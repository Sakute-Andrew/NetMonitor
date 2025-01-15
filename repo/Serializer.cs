using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace NetMonitor.repo;

public class Serializer
{
    public string Serialize(object obj)
    {
        if (obj == null) return "null";
        var type = obj.GetType();
        
        if (type.IsPrimitive || obj is string || obj is decimal || obj is DateTime || obj is bool)
        {
            return GetJsonValue(obj);
        }

        if (obj is IEnumerable<object> collection) 
        {
            return SerializeCollection(collection);
        }

        var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
        var jsonBuilder = new StringBuilder();
        jsonBuilder.Append("{");

        bool first = true;
        foreach (var property in properties)
        {
            if (!first) jsonBuilder.Append(", ");
            first = false;

            var value = property.GetValue(obj);
            var jsonValue = GetJsonValue(value);
            jsonBuilder.Append($"\"{property.Name}\": {jsonValue}");
        }

        jsonBuilder.Append("}");
        return jsonBuilder.ToString();
    }

    private string GetJsonValue(object value)
    {
        if (value == null) return "null";
        if (value is string) return $"\"{value}\"";
        if (value is bool) return value.ToString().ToLower();
        if (value is DateTime) return $"\"{((DateTime)value):yyyy-MM-ddTHH:mm:ss}\"";

        // Якщо значення - об'єкт, то викликаємо серіалізацію рекурсивно
        if (!value.GetType().IsPrimitive && value.GetType() != typeof(string))
        {
            return Serialize(value); // Рекурсивний виклик для об'єктів
        }

        return value.ToString(); // Для чисел і інших типів
    }

    private string SerializeCollection(IEnumerable<object> collection)
    {
        var jsonBuilder = new StringBuilder();
        jsonBuilder.Append("[");

        bool first = true;
        foreach (var item in collection)
        {
            if (!first) jsonBuilder.Append(", ");
            first = false;

            jsonBuilder.Append(GetJsonValue(item));
        }

        jsonBuilder.Append("]");
        return jsonBuilder.ToString();
    }
}

