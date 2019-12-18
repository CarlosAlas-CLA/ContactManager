using DataLayer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace BusinessLayer.Services
{
    public static class Mapper
    {
        public static EmailAddress destination1 = new EmailAddress();
        public static EmailAddress MapToDB(object source1)
        {
            Type sourceObject1 = source1.GetType();
            Type destinationtype1 = destination1.GetType();
            var source1Properties = sourceObject1.GetProperties();
            var destinationProperties1 = destinationtype1.GetProperties();
            var commonproperties1 = from sp in source1Properties
                                    join dp in destinationProperties1 on new { sp.Name, sp.PropertyType } equals
                                        new { dp.Name, dp.PropertyType }
                                    select new { sp, dp };
            foreach (var match in commonproperties1)
            {
                match.dp.SetValue(destination1, match.sp.GetValue(source1, null), null);
            }
            return (destination1);
        }
    }
}
