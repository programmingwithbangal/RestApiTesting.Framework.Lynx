using System;
using System.Collections.Generic;
using System.Dynamic;
using RestApiTesting.Framework.Lynx.Models;

namespace RestApiTesting.Framework.Lynx.Helpers
{
    public class ScenarioContext
    {
        private const string KeyString = "key";

        private const string OfSplitter = " of ";

        private const string RefString = "ref";

        public const string StrString = "str";

        private const string IntString = "int ";

        private readonly Dictionary<string, object> m_scenarioContext = new Dictionary<string, object>();

        private static readonly string[] s_splitter =
        {
            OfSplitter
        };

        public void Add(string key, object value)
        {
            if (m_scenarioContext.ContainsKey(key))
            {
                throw new ArgumentException($"The key: {key} already exists!");
            }

            m_scenarioContext[key] = value;
        }

        public T GetObjectValue<T>(string expression)
        {
            T returnValue;

            if (expression.StartsWith(StrString))
            {
                expression = TrimExpression(expression, StrString);
                returnValue = (T)(object)expression;
            }
            else if (expression.StartsWith(IntString))
            {
                expression = TrimExpression(expression, IntString);
                returnValue = (T)(object)Convert.ToInt32(expression);
            }
            else
            {
                if (expression.StartsWith(KeyString))
                {
                    expression = TrimExpression(expression, KeyString);
                }
                else if (expression.StartsWith(RefString))
                {
                    expression = TrimExpression(expression, RefString);
                }

                if (ParseExpression(expression, out ExpressionModel accessorModel))
                {
                    returnValue = GetAccessorValueFromModel<T>(accessorModel);
                }
                else
                {
                    returnValue = GetObjectValueFromContext<T>(expression);
                }
            }

            return returnValue;
        }

        private static string TrimExpression(string expression, string phrase)
        {
            return expression.Substring(phrase.Length, expression.Length - phrase.Length).Trim();
        }

        private static bool ParseExpression(string expression, out ExpressionModel expressionModel)
        {
            string[] tokens = expression.Split(s_splitter, StringSplitOptions.RemoveEmptyEntries);

            string modelName;
            string accessorName;

            switch (tokens.Length)
            {
                case 2:
                    // "ref id of postsModel"
                    accessorName = tokens[0];
                    modelName = tokens[1];
                    break;
                default:
                    // "postsModel"
                    expressionModel = null;
                    return false;
            }

            expressionModel = new ExpressionModel
            {
                FieldName = accessorName,
                ModelName = modelName
            };

            return true;
        }

        private T GetObjectValueFromContext<T>(string key)
        {
            if (!m_scenarioContext.TryGetValue(key, out object value))
            {
                throw new KeyNotFoundException($"The key {key} does not exist");
            }

            return (T)value;
        }

        public T GetAccessorValueFromModel<T>(ExpressionModel expressionModel)
        {
            var model = GetObjectValue<object>(expressionModel.ModelName);

            IDictionary<string, object> valueDict = (ExpandoObject)model;

            if (!valueDict.ContainsKey(expressionModel.FieldName))
            {
                throw new KeyNotFoundException($"The accessor {expressionModel.FieldName} does not exist");
            }

            valueDict.TryGetValue(expressionModel.FieldName, out object value);

            if (typeof(T) == typeof(string))
            {
                value = value?.ToString();
            }
            return (T)value;
        }

        public Dictionary<string, object>.ValueCollection GetValues()
        {
            return m_scenarioContext.Values;
        }
    }
}