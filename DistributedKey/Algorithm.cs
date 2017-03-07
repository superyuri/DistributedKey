using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributedKey
{
    public class Algorithm
    {
        /// <summary>
        /// 用户注册阶段
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="fingerprintFeature"></param>
        internal static void Step1()
        {
            //h(pwa||B),B
            var clienthash = CombineHash(Constants.Password, Constants.FingerprintFeature);

            //R=H(IDA||Ki)
            var R = CombineHash(Constants.Username, Constants.Privatekey);
            //Z=R+h(pwa||B)
            var Z = R + "+" + clienthash;

            Console.WriteLine("存入智能卡的值为");
            Console.WriteLine("Z={0}", Z);
            Console.WriteLine("B={0}", Constants.FingerprintFeature);
            Console.WriteLine("H(.)={0}", "???");
            Console.WriteLine("D(.)={0}", "???");
            Console.WriteLine("τ={0}", Constants.Tau);
        }
        internal static void Step2_1()
        {
            double val1 = FingerprintFeatureSimilarity(Constants.FingerprintFeature, Constants.InvalidFingerprintFeature);
            double val2 = FingerprintFeatureSimilarity(Constants.FingerprintFeature, Constants.ValidFingerprintFeature);


            Console.WriteLine("\n以上一条指纹特征值为样本，继续算法", Constants.Tau);
            
        }
        /// <summary>
        /// 计算Hash，用sha1算法
        /// </summary>
        /// <param name="string1"></param>
        /// <param name="string2"></param>
        /// <returns></returns>
        internal static string CombineHash(string string1, string string2)
        {
            var hmac = System.Security.Cryptography.HMACSHA1.Create();
            var hashbytes = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(string1 + string2));
            string strResult = BitConverter.ToString(hashbytes);
            strResult = strResult.Replace("-", "");
            return strResult;
        }
        /// <summary>
        /// 指纹特征相似度比较
        /// </summary>
        /// <returns></returns>
        internal static double FingerprintFeatureSimilarity(string source, string target)
        {
            int i, j;
            int[][] d = new int[source.Length + 1][];
            for (int k = 0; k < d.Length; k++)
            {
                d[k] = new int[target.Length + 1];
            }
            for (i = 1; i < source.Length + 1; i++)
            {/*初始化临界值*/
                d[i][0] = i;
            }
            for (j = 1; j < target.Length + 1; j++)
            {/*初始化临界值*/
                d[0][j] = j;
            }
            for (i = 1; i < source.Length + 1; i++)
            {/*动态规划填表*/
                for (j = 1; j < target.Length + 1; j++)
                {
                    if (source.Substring(i - 1, 1).Equals(target.Substring(j - 1, 1)))
                    {
                        d[i][j] = d[i - 1][j - 1];/*source的第i个和target的第j个相同时*/
                    }
                    else
                    {/*不同的时候则取三种操作最小的一个*/
                        d[i][j] = min(d[i][j - 1] + 1, d[i - 1][j] + 1, d[i - 1][j - 1] + 1);
                    }
                }
            }
            var result = 1-(d[source.Length][target.Length] + 0.0) / source.Length;
            Console.WriteLine("指纹特征值：{0}\n比对结果：匹配失败字符数：{1}   匹配程度：{2} 匹配结果：{3}",
                target, d[source.Length][target.Length], result, result >Constants.Tau?"成功":"失败");
            return result;
        }


        private static int min(int i, int j, int k)
        {
            int min = i < j ? i : j;
            min = min < k ? min : k;
            return min;
        }
    }
}