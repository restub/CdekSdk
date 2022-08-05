using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using RestSharp;

namespace CdekApi.Toolbox
{
    public static class ParameterHelper
    {
        /// <summary>
        /// Adds all dataContract properties to the given request as QueryString parameters.
        /// </summary>
        /// <param name="request">Request to populate parameters.</param>
        /// <param name="dataContract">Data contract to get the parameters from.</param>
        public static void AddQueryString(this IRestRequest request, object dataContract) =>
            request.AddParameters(dataContract, ParameterType.QueryString);

        /// <summary>
        /// Adds all dataContract properties to the given request.
        /// </summary>
        /// <param name="request">Request to populate parameters.</param>
        /// <param name="dataContract">Data contract to get the parameters from.</param>
        /// <param name="type">Parameter type.</param>
        public static IRestRequest AddParameters(this IRestRequest request, object dataContract, ParameterType type = ParameterType.GetOrPost)
        {
            if (dataContract == null || dataContract.GetType().IsPrimitive)
            {
                return request;
            }

            var props = dataContract.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (var p in props)
            {
                var value = p.GetValue(dataContract);
                var defaultValue = p.PropertyType.GetDefaultValue();
                var isNonDefault = !Equals(value, defaultValue);
                var dataMember = p.GetCustomAttribute<DataMemberAttribute>();
                var isRequired = dataMember?.IsRequired ?? false;

                if (isNonDefault || isRequired)
                {
                    var parameterName = dataMember?.Name ?? p.Name;
                    if (value == null || value is string)
                    {
                        request.AddParameter(parameterName, value, type);
                        continue;
                    }

                    if (value.GetType().IsPrimitive)
                    {
                        request.AddParameter(parameterName, value, type);
                        continue;
                    }

                    if (value is IEnumerable enumerable)
                    {
                        value = string.Join(",", enumerable.OfType<object>());
                        request.AddParameter(parameterName, value, type);
                        continue;
                    }

                    request.AddParameter(parameterName, value, type);
                }
            }

            return request;
        }

        /// <summary>
        /// Gets the default value of the given type.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        public static T GetDefaultValue<T>() => default(T);

        /// <summary>
        /// Gets the default value of the given type.
        /// </summary>
        /// <param name="type">The type.</param>
        public static object GetDefaultValue(this Type type)
        {
            Func<int> getDefault = GetDefaultValue<int>;
            var getDefaultMethod = getDefault.Method.GetGenericMethodDefinition();
            return getDefaultMethod.MakeGenericMethod(type).Invoke(null, null);
        }
    }
}
