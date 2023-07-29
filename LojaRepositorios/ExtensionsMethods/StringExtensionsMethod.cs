using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaRepositorios.ExtensionsMethods
{
    public static class StringExtensionsMethod
    {
        public static string ObterCpfLimpo(this string texto)
        {
            return texto.Replace("-", "").Replace(".", "");
        }
    }
}
