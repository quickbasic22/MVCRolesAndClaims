using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using System.Threading.Tasks.Dataflow;

namespace MVCRolesAndClaims.Models
{
    public class RemoteServerCilentAttribute : RemoteAttribute
    {
        public override bool IsValid(object? value)
        {
            Type controller = Assembly.GetExecutingAssembly()
                                      .GetTypes()
                                      .FirstOrDefault(type => type.Name.ToLower() == string.Format("{0}Contoller", this.RouteData["contoller"].ToString().ToLower()));
            if (controller != null)
            {
                MethodInfo action = controller.GetMethods().FirstOrDefault(method => method.Name.ToLower() == this.RouteData["action"].ToString().ToLower());
                if (action != null)
                {
                    object instance = Activator.CreateInstance(controller);
                    object response = action.Invoke(instance, new object[] { value });
                    if (response is JsonResult)
                    {
                        object jsonData = (response as JsonResult).Value;
                        if (jsonData is bool)
                        {
                            return (bool)jsonData ? ValidationResult.Success : new ValidationResult(this.ErrorMessage);
                        }
                    }
                }
            }
            return false;
        }

        public RemoteServerCilentAttribute(string routeName) 
            : base(routeName)
        {

        }
        public RemoteServerCilentAttribute(string action, string controller)
           : base(action, controller)
        {

        }
        public RemoteServerCilentAttribute(string action, string controller, string areaName)
           : base(action, controller, areaName)
        {

        }
    }
}
