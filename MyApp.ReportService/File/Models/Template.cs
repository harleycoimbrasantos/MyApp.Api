using MyApp.ReportService.File.Pdf;
using System.Reflection;

namespace MyApp.ReportService.File.Models
{
    public abstract class Template : ITemplate
    {
        public string Build()
        {
            string templateName = GetTemplateName();

            string template = Properties.Resource.ResourceManager.GetString(templateName);

            if (string.IsNullOrEmpty(template))
                throw new Exception($"Template '{templateName}' não encontrado. Verifique se o mesmo existe e se o nome do HTML é o mesmo do .cs");

            PropertyInfo[] propertiesInfo = GetType().GetProperties();

            foreach (PropertyInfo propertyInfo in propertiesInfo)
            {
                string name = propertyInfo.Name;
                string value = GetValue(propertyInfo);

                template = template.Replace($"[{name}]", value);
            }

            return template;
        }

        public virtual string GetTemplateName()
        {
            return GetType().Name;
        }

        private string GetValue(PropertyInfo propertyInfo)
        {
            if (typeof(IEnumerable<ITemplate>).IsAssignableFrom(propertyInfo.PropertyType))
                return GetValueFromTemplateList(propertyInfo);

            if (typeof(ITemplate).IsAssignableFrom(propertyInfo.PropertyType))
                return GetValueFromTemplate(propertyInfo);

            return propertyInfo.GetValue(this)?.ToString();
        }

        private string GetValueFromTemplate(PropertyInfo propertyInfo)
        {
            ITemplate template = (ITemplate)propertyInfo.GetValue(this);

            return template.Build();
        }

        private string GetValueFromTemplateList(PropertyInfo propertyInfo)
        {
            IEnumerable<ITemplate> templates = (IEnumerable<ITemplate>)propertyInfo.GetValue(this);

            return string.Join("", templates.Select(s => s.Build()));
        }
    }
}
