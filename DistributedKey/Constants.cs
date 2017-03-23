
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
        /// Ki 服务器i的切比雪夫混沌映射私钥
        /// </summary>
        public static int Privatekeyi = 38;
        /// <summary>
        /// Kj 服务器j的切比雪夫混沌映射私钥
        /// </summary>
        public static int Privatekeyj = 28;
        /// <summary>
        /// τ,容错率
        /// </summary>
        public static double Tau = 0.95;
        /// <summary>
        /// x，变量，取值范围[-1,1]
        /// </summary>
        public static double VariableX = -0.6252313;
        /// <summary>
        /// 最大切比雪夫计算次数
        /// </summary>
        public static int CHEBYSHEV_MAX = 40;
        /// <summary>
        /// 第i个服务器的标识符
        /// </summary>
        public static string IDSi = "IDSiValue";
        /// <summary>
        /// 第j个服务器的标识符
        /// </summary>
        public static string IDSj = "IDSjValue";
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