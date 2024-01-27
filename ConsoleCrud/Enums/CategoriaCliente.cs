using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCrud.Enums
{
    public enum CategoriaCliente : int
    {
        [Description("Classic")]
        Classic = 0,
        [Description("VIP")]
        VIP = 1,
        [Description("Diamond")]
        Diamond = 2
    }
    public static class CategoriaClienteExtensions
    {
        public static string GetDescription(this CategoriaCliente value)
        {
            var campo = value.GetType().GetField(value.ToString());
            
            var atributo = (DescriptionAttribute)Attribute.GetCustomAttribute(campo, typeof(DescriptionAttribute));
            
            return atributo == null ? value.ToString() : atributo.Description;
        }
    }


}
