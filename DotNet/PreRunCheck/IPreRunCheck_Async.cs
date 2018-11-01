using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TP_DotNet.PreRunCheck
{
    interface IPreRunCheck_Async
    {
        /// <summary>
        /// Führt den Check aus. 
        /// Ist gedacht für einen Check Prozess länger als 1 Frame
        /// Dieser Returned True -> gültig
        /// oder False -> ungültig
        /// </summary>
        /// <returns></returns>
        Task<bool> Check();

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
