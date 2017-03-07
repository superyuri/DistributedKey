using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributedKey
{
    class Program
    {
        /// <summary>
        /// IDA
        /// </summary>
        static string Username = "Alice";

        /// <summary>
        /// PWA
        /// </summary>
        static string Password = "Alicepassword";
        /// <summary>
        /// Ki 切比雪夫混沌映射私钥
        /// </summary>
        static string Privatekey = "Privatekeyvalue";
        /// <summary>
        /// τ,容错率
        /// </summary>
        public static double Tau = 0.95;

        /// <summary>
        /// B
        /// </summary>
        static string FingerprintFeature = "EaU7azc+DTwYrpUQVmLjbPv41mkeG/GGjDdNjEUpZUCwxt0/lT6aZQdlJRXOC3P9tgFKc+2pluOyygsC1UpoOu+ioxrOX04D4Up9iL/W8HsNmVPh6Lk3mfO8jwHCuHGIaWnO/xZqRQ05xke2wz9ROq7aCE36YfQsuwPOzncp+PdB+lLblbnZJ6aHLv4gFR/T7pMcbK5N";

        static string InvalidFingerprintFeature = "xxxxxxxxxxxxrpUQVmLjbPv41mkeG/GGjDdNjEUpZUCwxt0/lT6aZQdlJRXOC3P9tgFKc+2pluOyygsC1UpoOu+ioxrOX04D4Up9iL/W8HsNmVPh6Lk3mfO8jwHCuHGIaWnO/xZqRQ05xke2wz9ROq7aCE36YfQsuwPOzncp+PdB+lLblbnZJ6aHLv4gFR/T7pMcbK5N";
        static string ValidFingerprintFeature = "ExUxaxcxxxwYrpUQVmLjbPv41mkeG/GGjDdNjEUpZUCwxt0/lT6aZQdlJRXOC3P9tgFKc+2pluOyygsC1UpoOu+ioxrOX04D4Up9iL/W8HsNmVPh6Lk3mfO8jwHCuHGIaWnO/xZqRQ05xke2wz9ROq7aCE36YfQsuwPOzncp+PdB+lLblbnZJ6aHLv4gFR/T7pMcbK5N";

        static void Main(string[] args)
        {
            Console.WriteLine("论文题目:基于双因素的分布式认证密钥协商方案研究\n");
            Console.WriteLine("算法仿真Part1：用户注册阶段\n");
            Console.ReadLine();

            Console.WriteLine("输入参数");
            Console.WriteLine("用户名：{0}", Username);
            Console.WriteLine("密码：{0}", Password);
            Console.WriteLine("指纹特征值：{0}",FingerprintFeature);
            Console.WriteLine("切比雪夫混沌映射私钥：{0}",Privatekey);
            Console.WriteLine("指纹数据容错率：{0}", Tau);
            Console.ReadLine();

            Algorithm.Step1(Username, Password, FingerprintFeature, Privatekey, Tau);
            Console.ReadLine();

            Console.WriteLine("算法仿真Part2：互换认证阶段\n");
            Console.WriteLine("算法仿真Part2.1：用户登录服务器阶段\n");
            Console.ReadLine();

            Console.WriteLine("输入参数");
            Console.WriteLine("用户名：{0}", Username);
            Console.WriteLine("密码：{0}", Password);
            Console.WriteLine("指纹特征值：{0}", FingerprintFeature);
            Console.WriteLine("某一无效指纹特征值：{0}", InvalidFingerprintFeature);
            Console.WriteLine("某一有效指纹特征值：{0}", ValidFingerprintFeature);
            Console.WriteLine("切比雪夫混沌映射私钥：{0}", Privatekey);
            Console.WriteLine("指纹数据容错率：{0}", Tau);
            Console.ReadLine();
            Algorithm.Step2(Username, Password, FingerprintFeature, InvalidFingerprintFeature, ValidFingerprintFeature, Privatekey, Tau);
        }
    }
}
