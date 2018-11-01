using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TP_DotNet.PreRunCheck
{
    interface IPreRunCheck
    {
        /// <summary>
        /// Führt den Check aus. 
        /// Dieser Returned True -> gültig
        /// oder False -> ungültig
        /// </summary>
        /// <returns></returns>
        bool Check();

        /// <summary>
        /// Diese Action wird performed wenn der Check
        /// ungültig ergeben hat
        /// </summary>
        void PerformAction_Unvalid();

        /// <summary>
        /// Diese Action wird performed wenn der Check
        /// gültig ergeben hat
        /// </summary>
        void PerformAction_Valid();
    }
}
