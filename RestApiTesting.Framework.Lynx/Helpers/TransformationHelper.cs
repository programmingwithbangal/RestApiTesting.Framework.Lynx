using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using Gherkin.Ast;

namespace RestApiTesting.Framework.Lynx.Helpers
{
    public class TransformationHelper
    {
        public static void ModelFromDataTable(ScenarioContext scenarioContext, string modelKey, DataTable dataTable)
        {
            ExpandoObject model = GetExpandoObject(scenarioContext, dataTable);
            scenarioContext.Add(modelKey, model);
        }

        public static ExpandoObject GetExpandoObject(ScenarioContext scenarioContext, DataTable dataTable)
        {
            dynamic model = new ExpandoObject();

            foreach (TableRow row in dataTable.Rows.Skip(1))
            {
                string key = row.Cells.ElementAt(0).Value;
                string value = row.Cells.ElementAt(1).Value;
                ((IDictionary<string, object>)model).Add(key, scenarioContext.GetObjectValue<object>(value));
            }

            return model;
        }
    }
}