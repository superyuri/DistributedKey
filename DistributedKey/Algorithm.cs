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
            var R = CombineHash(Constants.Username, Constants.Privatekeyi);
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

        }
         /// <summary>
         /// 计算Hash，用sha1算法
         /// </summary>
         /// <param name="string1"></param>
         /// <param name="string2"></param>
         /// <returns></returns>
        internal static string CombineHash(string string1, string string2)
        {
            return Hash(string1 + string2);
        }
        internal static string CombineHash(string[] list)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in list)
            {
                sb.Append(item);
            }
            return Hash(sb.ToString());
        }

        internal static string CombineHash(string string1, int val2)
        {
            return CombineHash(string1, val2 + "");
        }
        internal static string CombineHash(string string1, double val2)
        {
            return CombineHash(string1, val2 + "");
        }
        private static string Hash(string value)
        {
            var hmac = System.Security.Cryptography.HMACSHA1.Create();
            var hashbytes = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(value));
            string strResult = BitConverter.ToString(hashbytes);
            strResult = strResult.Replace("-", "");
            return strResult;
        }
        /// <summary>
        /// 未完成，skey要求256bit，比如是c5d608eb97d94123
        /// </summary>
        /// <param name="sSrc"></param>
        /// <param name="sKey"></param>
        /// <returns></returns>
        private static string Encrypt(string sSrc, string sKey)
        {
            try
            {
                // if (string.IsNullOrEmpty(sKey) || string.IsNullOrEmpty(sSrc) || sKey.Length != 16) return null;
                Byte[] toEncryptArray = Encoding.UTF8.GetBytes(sSrc);

                System.Security.Cryptography.RijndaelManaged rm = new System.Security.Cryptography.RijndaelManaged
                {
                    Key = Encoding.UTF8.GetBytes(sKey),
                    Mode = System.Security.Cryptography.CipherMode.ECB,
                    Padding = System.Security.Cryptography.PaddingMode.PKCS7
                };

                System.Security.Cryptography.ICryptoTransform cTransform = rm.CreateEncryptor();
                Byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

                return Convert.ToBase64String(resultArray);
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public static string Decrypt(string sSrc, string sKey)
        {
            try
            {
                // if (string.IsNullOrEmpty(sKey) || string.IsNullOrEmpty(sSrc) || sKey.Length != 16) return null;

                Byte[] toEncryptArray = Convert.FromBase64String(sSrc);

                System.Security.Cryptography.RijndaelManaged rm = new System.Security.Cryptography.RijndaelManaged
                {
                    Key = Encoding.UTF8.GetBytes(sKey),
                    Mode = System.Security.Cryptography.CipherMode.ECB,
                    Padding = System.Security.Cryptography.PaddingMode.PKCS7
                };

                System.Security.Cryptography.ICryptoTransform cTransform = rm.CreateDecryptor();
                Byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

                return Encoding.UTF8.GetString(resultArray);
            }
            catch
            {
                return null;
            }
        }
        internal static string Step2_2()
        {
            //a
            var times = new Random().Next(Constants.CHEBYSHEV_MAX);

            //calc Ta(x)
            var tax = ChebyshevPolynomial(times, Constants.VariableX);

            //R=H(IDA||Ki)
            var R = CombineHash(Constants.Username, Constants.Privatekeyi);

            //C1=H(R||Ta(x))
            var C1 = CombineHash(R, tax);

            Console.WriteLine("经过计算，m1={IDa,Ta(x),C1}的值如下:");
            Console.WriteLine("IDa={0}", Constants.Username);
            Console.WriteLine("Ta(x)={0}", tax);
            Console.WriteLine("C1={0}", C1);

            return string.Format("{0},{1},{2}", Constants.Username, tax, C1);
        }
        internal static string Step2_3(string m1)
        {
            //Ri
            var ri = new Random().Next(Constants.CHEBYSHEV_MAX);

            //calc TRi(x)

            var trix = ChebyshevPolynomial(ri, Constants.VariableX);

            //calc KSiSj(x)=Tri(Tkj(x))
            var Ksisj = ChebyshevPolynomial(ri,ChebyshevPolynomial(Constants.Privatekeyj, Constants.VariableX));

            //Hsi = H(IDa||IDSi||TRi(x)||m1)
            var Hsi = CombineHash(new string[]
                {
                    Constants.Username,
                    Constants.IDSi,
                    trix+"",
                    m1
                });

            var C2 = Encrypt(Constants.Username + Constants.IDSi + m1 + Hsi, Ksisj+"");

            Console.WriteLine("经过计算:");
            Console.WriteLine("IDSi={0}", Constants.IDSi);
            Console.WriteLine("TRi(x)={0}", trix);
            Console.WriteLine("C2={0}", C2);

            return string.Format("{0},{1},{2}", Constants.IDSi, trix, C2);
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
        /// <summary>
        /// 切比雪夫多项式算法
        /// </summary>
        internal static double ChebyshevPolynomial(int subScript, double x)
        {
            if (subScript <=0)
            {
                return 1;
            }
            else if (subScript == 1)
            {
                return x;
            }
            else
            {
                return 2 * x * ChebyshevPolynomial(subScript - 1, x) - ChebyshevPolynomial(subScript - 2, x);
            }
        }



        private static int min(int i, int j, int k)
        {
            int min = i < j ? i : j;
            min = min < k ? min : k;
            return min;
        }
    }
}