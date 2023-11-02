using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuturesArbitrage
{
    internal class BookValue
    {
        /*private string sv_myMoney = "";
        private string sv_fee_stock_buy = "";
        private string sv_fee_stock_sell = "";
        private string sv_fee_futures = "";
        private string sv_stt_rate = "";
        private string sv_norisk_interest_rate = "";
        private string sv_borrow_interest_rate = "";
        private string sv_loan_interest_rate = "";
        private string sv_formula = "";
        private string sv_filePath = "";*/
        
        //매수차익거래 이론가
        public static Double bookValue_buyArbitrage(double s, double mangi, double sv_fee_stock_buy, double sv_fee_stock_sell, double sv_fee_futures, double sv_stt_rate, double sv_norisk_interest_rate, double sv_borrow_interest_rate, double sv_loan_interest_rate)
        {
            return (s *(1 + sv_fee_stock_buy) + sv_fee_futures) * (1 + sv_borrow_interest_rate * (mangi / 365.0));
        }

        //매도차익거래 이론가
        public static Double bookValue_sellArbitrage(double s, double mangi, double sv_fee_stock_buy, double sv_fee_stock_sell, double sv_fee_futures, double sv_stt_rate, double sv_norisk_interest_rate, double sv_borrow_interest_rate, double sv_loan_interest_rate)
        {
            return (s * (1 - sv_fee_stock_buy) - sv_fee_futures) * (1 + sv_loan_interest_rate * (mangi / 365.0));
        }

        public static bool compare_buyArbitrage()
        {
            return true;
        }

        public static bool compare_sellArbitrage()
        {
            return true;
        }
    }
}
