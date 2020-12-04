using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gestionex
{
    public static class Utils
    {
        public static bool ValidarCedula(string pCedula)
        {
            if (ValidarCedulaRazon(pCedula) == "")
                return true;
            return false;
        }

        public static string ValidarCedulaRazon(string pCedula)
        {
            int vnTotal = 0;
            string vcCedula = pCedula.Replace("-", "");
            int pLongCed = vcCedula.Trim().Length;
            int[] digitoMult = new int[11] { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1 };

            if (pLongCed < 11 || pLongCed > 11)
                return $"Debe contener 11 dígitos (tiene {pLongCed})";

            for (int vDig = 1; vDig <= pLongCed; vDig++)
            {
                int vCalculo = Int32.Parse(vcCedula.Substring(vDig - 1, 1)) * digitoMult[vDig - 1];
                if (vCalculo < 10)
                    vnTotal += vCalculo;
                else
                    vnTotal += Int32.Parse(vCalculo.ToString().Substring(0, 1)) + Int32.Parse(vCalculo.ToString().Substring(1, 1));
            }

            if (vnTotal % 10 == 0)
                return "";
            else
                return $"El digito de confirmación no es el correcto ({(Int32.Parse(vcCedula.Substring(pLongCed - 1, 1)) + 100 - vnTotal) % 10})";
        }
    }
}