using System;

namespace AlazomEstoque.SharedKernel
{
    public class HorasSK
    {
        public TimeSpan CalcularHoras(DateTime dt1) => DateTime.Now - dt1;

      
    }
}
