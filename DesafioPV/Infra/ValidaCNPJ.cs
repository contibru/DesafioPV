﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioPV.Infra
{
    public static class ValidaCNPJ
    {

        /// <summary>
        /// Informar um CNPJ completo para validação do digito verificador
        /// </summary>
        /// <param name="cnpj">Int64 com o numero CNPJ completo com Digito</param>
        /// <returns>Boolean True/False onde True=Digito CNPJ Valido</returns>
        public static Boolean CNPJIsValid(Int64 cnpj)
        {
            return CNPJIsValid(cnpj.ToString("D14"));
        }

        /// <summary>
        /// Informar um CNPJ completo para validação do digito verificador
        /// </summary>
        /// <param name="cnpj">string com o numero CNPJ completo com Digito</param>
        /// <returns>Boolean True/False onde True=Digito CNPJ Valido</returns>
        public static Boolean CNPJIsValid(string cnpj)
        {

            if (cnpj == null || cnpj.Length == 0)
                return false;

            // Declara variaveis para uso
            string new_cnpj = "";

            // Retira carcteres invalidos não numericos da string
            for (int i = 0; i < cnpj.Length; i++)
            {
                if (isDigito(cnpj.Substring(i, 1)))
                {
                    new_cnpj += cnpj.Substring(i, 1);
                }
            }
            if (new_cnpj == null || new_cnpj.Length == 0)
                return false;


            // Ajusta o Tamanho do CNPJ para 14 digitos considerando o digito verificador e completando com zeros a esquerda
            new_cnpj = Convert.ToInt64(new_cnpj).ToString("D14");

            // Verifica se o CNPJ informado tem os 14 digitos 
            if (new_cnpj.Length > 14)
            {
                return false;
            }

            // Calcula o digito do CNPJ e compara com o digito informado
            if (CalculaDigCNPJ(new_cnpj.Substring(0, 12)) == new_cnpj.Substring(12, 2))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Calcula o Digito verificador de um CNPJ informado  
        /// </summary>
        /// <param name="cnpj">int64 com o CNPJ contendo 12 digitos e sem o digito verificador</param>
        /// <returns>string com o digito calculado do CNPJ ou null caso o CNPJ informado for maior que 12 digitos</returns>
        public static string CalculaDigCNPJ(Int64 cnpj)
        {
            return CalculaDigCNPJ(cnpj.ToString("D12"));
        }

        /// <summary>
        /// Calcula o Digito verificador de um CNPJ informado  
        /// </summary>
        /// <param name="cnpj">string com o CNPJ contendo 12 digitos e sem o digito verificador</param>
        /// <returns>string com o digito calculado do CNPJ ou null caso o CNPJ informado for maior que 12 digitos</returns>
        public static string CalculaDigCNPJ(string cnpj)
        {
            // Declara variaveis para uso
            string new_cnpj = "";
            string digito = "";
            int[] calculo = new int[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            Int32 Aux1 = 0;
            Int32 Aux2 = 0;

            // Retira carcteres invalidos não numericos da string
            for (int i = 0; i < cnpj.Length; i++)
            {
                if (isDigito(cnpj.Substring(i, 1)))
                {
                    new_cnpj += cnpj.Substring(i, 1);
                }
            }

            // Ajusta o Tamanho do CNPJ para 12 digitos completando com zeros a esquerda
            new_cnpj = Convert.ToInt64(new_cnpj).ToString("D12");

            // Caso o tamanho do CNPJ informado for maior que 12 digitos retorna nulo
            if (new_cnpj.Length > 12)
            {
                return null;
            }

            // Calcula o primeiro digito do CNPJ
            Aux1 = 0;

            for (int i = 0; i < new_cnpj.Length; i++)
            {
                Aux1 += Convert.ToInt32(new_cnpj.Substring(i, 1)) * calculo[i];
            }

            Aux2 = (Aux1 % 11);

            // Carrega o primeiro digito na variavel digito
            if (Aux2 < 2)
            {
                digito += "0";
            }
            else
            {
                digito += (11 - Aux2).ToString();
            }

            // Adiciona o primeiro digito ao final do CNPJ para calculo do segundo digito
            new_cnpj += digito;

            // Calcula o segundo digito do CNPJ
            calculo = new int[] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            Aux1 = 0;

            for (int i = 0; i < new_cnpj.Length; i++)
            {
                Aux1 += Convert.ToInt32(new_cnpj.Substring(i, 1)) * calculo[i];
            }

            Aux2 = (Aux1 % 11);

            // Carrega o segundo digito na variavel digito
            if (Aux2 < 2)
            {
                digito += "0";
            }
            else
            {
                digito += (11 - Aux2).ToString();
            }

            return digito;
        }

        /// <summary>
        /// Verifica se um digito informado é um numero
        /// </summary>
        /// <param name="digito">string com um caracter para verificar se é um numero</param>
        /// <returns>Boolean True/False</returns>
        private static Boolean isDigito(string digito)
        {
            int n;
            return Int32.TryParse(digito, out n);
        }
    }

}

