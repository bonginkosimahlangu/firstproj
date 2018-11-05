using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace dvt_template.Shared.Core.Usecases.Data.General
{
    public class QueryBase
    {
        public QueryBase()
        {

        }
        public string ValidateModel()
        {
            var context = new ValidationContext(this, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(this, context, results);
            if (!isValid)
                return "Model is not valid because " + string.Join(", ", results.Select(s => s.ErrorMessage));
            else
                return string.Empty;
        }
        public string ValidateModelThrowExcWhenNotValid()
        {
            string errorMessges = string.Empty;
            var context = new ValidationContext(this, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(this, context, results);
            if (!isValid)
            {
                errorMessges = "Model is not valid because " + string.Join(", ", results.Select(s => s.ErrorMessage));
                throw new ArgumentException(errorMessges);
            }

            else
                return string.Empty;

        }
        public string GetTraceInformation()
        {
            return "_class=" + this.GetType().ToString();
        }
    }
}
