using System;

namespace DesafioPV.Infra
{
    public static class Utils
    {

        public static int GetAge(object value)
        {
            DateTime DtNascimento = Convert.ToDateTime(value);

            DateTime Now = DateTime.Now;
            return new DateTime(DateTime.Now.Subtract(DtNascimento).Ticks).Year - 1;
        }


    }
}
