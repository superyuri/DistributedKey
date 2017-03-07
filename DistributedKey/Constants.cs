
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistributedKey
{
    class Constants
    {
        /// <summary>
        /// IDA
        /// </summary>
        public static string Username = "Alice";
        /// <summary>
        /// PWA
        /// </summary>
        public static string Password = "Alicepassword";
        /// <summary>
        /// Ki 切比雪夫混沌映射私钥
        /// </summary>
        public static string Privatekey = "Privatekeyvalue";
        /// <summary>
        /// τ,容错率
        /// </summary>
        public static double Tau = 0.95;
        /// <summary>
        /// B，原始特征值
        /// </summary>
        public static string FingerprintFeature = "EaU7azc+DTwYrpUQVmLjbPv41mkeG/GGjDdNjEUpZUCwxt0/lT6aZQdlJRXOC3P9tgFKc+2pluOyygsC1UpoOu+ioxrOX04D4Up9iL/W8HsNmVPh6Lk3mfO8jwHCuHGIaWnO/xZqRQ05xke2wz9ROq7aCE36YfQsuwPOzncp+PdB+lLblbnZJ6aHLv4gFR/T7pMcbK5N";
        /// <summary>
        /// 无效的特征值样例
        /// </summary>
        public static string InvalidFingerprintFeature = "xxxxxxxxxxxxrpUQVmLjbPv41mkeG/GGjDdNjEUpZUCwxt0/lT6aZQdlJRXOC3P9tgFKc+2pluOyygsC1UpoOu+ioxrOX04D4Up9iL/W8HsNmVPh6Lk3mfO8jwHCuHGIaWnO/xZqRQ05xke2wz9ROq7aCE36YfQsuwPOzncp+PdB+lLblbnZJ6aHLv4gFR/T7pMcbK5N";
        /// <summary>
        /// 有效的特征值样例
        /// </summary>
        public static string ValidFingerprintFeature = "ExUxaxcxxxwYrpUQVmLjbPv41mkeG/GGjDdNjEUpZUCwxt0/lT6aZQdlJRXOC3P9tgFKc+2pluOyygsC1UpoOu+ioxrOX04D4Up9iL/W8HsNmVPh6Lk3mfO8jwHCuHGIaWnO/xZqRQ05xke2wz9ROq7aCE36YfQsuwPOzncp+PdB+lLblbnZJ6aHLv4gFR/T7pMcbK5N";
    }
}