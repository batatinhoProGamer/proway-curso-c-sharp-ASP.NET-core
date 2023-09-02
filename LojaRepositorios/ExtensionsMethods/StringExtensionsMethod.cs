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
