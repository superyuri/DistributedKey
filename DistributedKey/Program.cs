using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributedKey
{
    class Program
    {


        static void Main(string[] args)
        {
            Console.WriteLine("论文题目:基于双因素的分布式认证密钥协商方案研究\n");
            Console.WriteLine("算法仿真Part1：用户注册阶段\n");
            Console.ReadLine();

            Console.WriteLine("输入参数");
            Console.WriteLine("用户名：{0}", Constants.Username);
            Console.WriteLine("密码：{0}", Constants.Password);
            Console.WriteLine("指纹特征值：{0}", Constants.FingerprintFeature);
            Console.WriteLine("服务器i的切比雪夫混沌映射私钥：{0}", Constants.Privatekeyi);
            Console.WriteLine("指纹数据容错率：{0}", Constants.Tau);
            Console.ReadLine();

            Algorithm.Step1();
            Console.ReadLine();

            Console.WriteLine("算法仿真Part2：互换认证阶段");
            Console.ReadLine();

            Console.WriteLine("输入参数");
            Console.WriteLine("用户名：{0}", Constants.Username);
            Console.WriteLine("密码：{0}", Constants.Password);
            Console.WriteLine("指纹特征值：{0}", Constants.FingerprintFeature);
            Console.WriteLine("某一无效指纹特征值：{0}", Constants.InvalidFingerprintFeature);
            Console.WriteLine("某一有效指纹特征值：{0}", Constants.ValidFingerprintFeature);
            Console.WriteLine("服务器i的切比雪夫混沌映射私钥：{0}", Constants.Privatekeyi);
            Console.WriteLine("指纹数据容错率：{0}", Constants.Tau);
            Console.WriteLine("变量X：{0}", Constants.VariableX);
            Console.ReadLine();

            Console.WriteLine("算法仿真Part2.1：用户登录服务器阶段,扫描特征值\n");
            Algorithm.Step2_1();
            Console.ReadLine();

            Console.WriteLine("算法仿真Part2.2：m1={IDa,Ta(x),C1}\n");
            string m1 = Algorithm.Step2_2();
            Console.ReadLine();

            Console.WriteLine("算法仿真Part2.3：m2={IDsj,TRi(x),C2}");
            string m2 = Algorithm.Step2_3(m1);
            Console.ReadLine();
        }
    }
}
