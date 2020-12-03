using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Gestionex
{
    public static class Role
    {
        public static string Administrador { get => "Administrador"; }
        public static string Empleado { get => "Empleado"; }
        public static string Proveedor { get => "Proveedor"; }
        public static string Observador { get => ""; }

        public static Dictionary<string, string> ToDict()
        {
            var t = typeof(Role);
            var props = t.GetProperties();
            var dict = props.ToDictionary(prop => (string)prop.GetValue(null), prop => prop.Name);
            return dict;
        }

        public static SelectList ToSelectionList()
        {
            return new SelectList(ToDict(), "Key", "Value");
        }

        public static readonly string NonObserver = $"{Administrador}, {Empleado}, {Proveedor}";
    }
}