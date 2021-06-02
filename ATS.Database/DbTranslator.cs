using System;
using System.Collections.Generic;
using System.Text;

namespace ATS.Database
{
    public class DbTranslator
    {

        /// <summary>
        /// Retorna uma string com o campo no formato da data escolhido. SqlServer e Oracle
        /// </summary>
        /// <param name="data">Campo Data tipo DateTime</param>
        /// <param name="tipo">Número (1,2,3) que corresponde ao formato da data.
        /// 1: Somente Data,
        /// 2: Data e Hora,
        /// 3: Somente Hora.
        /// </param>
        /// <returns>string</returns>
        public static string ConverterStrParaData(DateTime data, int tipo, bool isOracle = false)
        {
            if (data == DateTime.MinValue)
                return "NULL";
            switch (tipo)
            {
                case 1://Somente Data
                    if (isOracle)
                        return "to_date('" + data.Day + '/' + data.Month + '/' + data.Year + "','DD/MM/YYYY')";
                    else
                        return "CONVERT(datetime2,'" + data.Day + '/' + data.Month + '/' + data.Year + ' ' + data.Hour + ':' + data.Minute + ':' + data.Second + "', 103)";
                case 2://Data e Hora
                    if (isOracle)
                        return "to_date('" + data.Day + '/' + data.Month + '/' + data.Year + ' ' + data.Hour + ':' + data.Minute + ':' + data.Second + "','DD/MM/YYYY hh24:mi:ss')";
                    else
                        return "CONVERT(datetime2,'" + data.Day + '/' + data.Month + '/' + data.Year + ' ' + data.Hour + ':' + data.Minute + ':' + data.Second + "', 103)";
                case 3://Somente Hora                    
                    if (isOracle)
                        return "to_date('" + data + "','hh24:mi:ss')";
                    else
                        return "CONVERT(datetime2,'" + data.Day + '/' + data.Month + '/' + data.Year + ' ' + data.Hour + ':' + data.Minute + ':' + data.Second + "', 108)";
            }
            return "";
        }

        public static String NormalizarValorComVirgula(Double pValor)
        {
            return pValor.ToString().Replace(',', '.');
        }

        public static string ReplaceNullValue(string pColumn, string pValue, bool isOracle = false)
        {
            return isOracle ? $"NVL({pColumn},{pValue})" : $"ISNULL({pColumn},{pValue})";
        }
        public static string ConverterDatetimeParaData(String pColuna, bool isOracle = false)
        {
            return isOracle ? "to_date(" + pColuna + ",'DD/MM/YYYY')" : " CONVERT(date, " + pColuna + ") ";
        }


        public static string ClearSqlString(string oldValue)
        {
            //oldValue = RemoveHtmlChars(oldValue);
            if (!String.IsNullOrEmpty(oldValue))
                return oldValue.Replace("'", "''");
            else
                return "";
        }

        private static String RemoveHtmlChars(String str)
        {
            foreach (string specialChar in specialHtmlChars)
            {
                str = str.Replace(specialChar, "");
            }
            return str;
        }

        private static string[] specialHtmlChars = { "<", ">", "#", "<%", "%>" };
    }
}
