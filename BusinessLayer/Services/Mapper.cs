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
        public static EmailAddress destinationObject = new EmailAddress();
        public static EmailAddress MapToEmailAddressDB(object source)
        {
            Type sourceObject = source.GetType();
            Type destination = destinationObject.GetType();
            var sourceProperties = sourceObject.GetProperties();
            var destinationProperties = destination.GetProperties();
            var commonProperties = from sp in sourceProperties
                                   join dp in destinationProperties on new { sp.Name, sp.PropertyType } equals
                                       new { dp.Name, dp.PropertyType }
                                   select new { sp, dp };
            foreach (var match in commonProperties)
            {
                match.dp.SetValue(destinationObject, match.sp.GetValue(source, null), null);
            }
            return (destinationObject);

        }
        public static void MapFromObjectToObject(object sourceFrom, Object sourceTo)
        {
            Type sourceObject = sourceFrom.GetType();
            Type destinationObject = sourceTo.GetType();
            var sourceProperties = sourceObject.GetProperties();
            var destinationProperties = destinationObject.GetProperties();
            var commonProperties = from sp in sourceProperties
                                   join dp in destinationProperties on new { sp.Name, sp.PropertyType } equals
                                       new { dp.Name, dp.PropertyType }
                                   select new { sp, dp };
            foreach (var match in commonProperties)
            {
                match.dp.SetValue(sourceTo, match.sp.GetValue(sourceFrom, null), null);
            }

        }
    }

}