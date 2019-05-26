using System.Runtime.Serialization.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace XML_Cycles
{
    class Program
    {
        static void Main(string[] args)
        {
            //获取服务器绝对路径
            //string serverPath = AppDomain.CurrentDomain.BaseDirectory;
            string serverPath = Environment.CurrentDirectory;//D:\天美联盟\vsTest2\vsTest2\KongZhiTai\XML\XML_Cycles\bin\Debug
            string path = serverPath.Substring(0, serverPath.Length - 9);
            XDocument document = XDocument.Load(path + "/交易流水查询.xml");
            string xmlStr = document.ToString();

            




            //读取txt文件
            string txtStr;
            using (StreamReader sr = new StreamReader(path + "/交易流水查询.txt", Encoding.Default, false))
            {
                txtStr = sr.ReadToEnd();
            }

            //string txtStr;
            //using (StreamReader sr = new StreamReader(path + "/交易流水查询.json",  false))
            //{
            //    txtStr = sr.ReadToEnd();
            //}






            //字符串赋值给xml         
            var result = XMLParseToObj<FuncSubAccTransFlowInquiryResponse>(xmlStr);
        }

        /// <summary>
        /// 华夏银行返回报文
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xmlStrResponse"></param>
        /// <param name="tradesCodeId"></param>
        /// <param name="tradeCode"></param>
        /// <returns></returns>
        public static BaseResponse<T> XMLParseToObj<T>(string xmlStrResponse,
            string tradesCodeId = null, string tradeCode = null)
        {
            //string currentMethodLog = "[XMLParseToObj]华夏银行返回报文，";
            BaseResponse<T> response = new BaseResponse<T>();
            XmlDocument xmlDocCycle = new XmlDocument();
            //字符串赋值给xml
            xmlDocCycle.LoadXml(xmlStrResponse);
            
            //using (StringReader reader = new StringReader(xmlStrResponse.ToString()))
            //{                
            //    string xmlRead = reader.ReadToEnd();
            //    //将xml文本转换为json，但是含有根节点。
            //    XDocument xdoc = XDocument.Parse(xmlRead);
            //    string jsonStr = JsonConvert.SerializeXNode(xdoc);                
            //}


            T responseEntity;
            //将xml文档转换为json，可以去掉根节点。
            string jsonNoRoot = JsonConvert.SerializeXmlNode(xmlDocCycle, Newtonsoft.Json.Formatting.None, true);

            responseEntity = JsonConvert.DeserializeObject<T>(jsonNoRoot);
            response.Status = BaseResponseStatusEnum.Success;
            response.Msg = "返回成功";
            response.Result = responseEntity;
            return response;
        }

    }

}
public class BaseResponse<T>
{
    public BaseResponse()
    {
        Status = BaseResponseStatusEnum.Error;   //默认失败
        Msg = "查无数据";
    }
    public string Msg { get; set; }
    public BaseResponseStatusEnum Status { get; set; }
    //public string 
    public T Result { get; set; }
}
public enum BaseResponseStatusEnum
{
    /// <summary>
    /// 无数据
    /// </summary>
    Default = 0,
    /// <summary>
    /// 成功
    /// </summary>
    Success = 1,
    /// <summary>
    /// 失败
    /// </summary>
    Error = -1,
    /// <summary>
    /// 其他
    /// </summary>
    Other = 2
}

/// <summary>
/// 101020子账户信息查询，应答报文
/// </summary>
public class BusSubAccountInfoInquiryResponse
{
    /// <summary>
    /// 记录条数 8 是
    /// 循环体中满足条件的子账号数目
    /// </summary>
    public string Count { get; set; }

    /// <summary>
    /// 循环体 否
    /// 详细见范例报文
    /// </summary>
    public CyclesResponse Cycles { get; set; }

    /// <summary>
    /// 备注1 40 否
    /// </summary>
    public string Remark1 { get; set; }

    /// <summary>
    /// 备注2 40 否
    /// </summary>
    public string Remark2 { get; set; }
}


public class CyclesResponse
{
    public List<CycleResponse> Cycle { get; set; }
}

/// <summary>
/// 循环体
/// </summary>
public class CycleResponse
{
    /// <summary>
    /// 序号 8 是
    /// </summary>
    public string Orders { get; set; }

    /// <summary>
    /// 子账号 20 是
    /// </summary>
    public string SubAccount { get; set; }

    /// <summary>
    /// 交易会员名称 60 是
    /// </summary>
    public string TradeMemBerName { get; set; }

    /// <summary>
    /// 交易会员代码 10 否
    /// </summary>
    public string MemBerCode { get; set; }

    /// <summary>
    /// 交易会员级别 1 否
    /// </summary>
    public string TradeMemBerGrade { get; set; }

    /// <summary>
    /// 上级会员代码 10 否
    /// </summary>
    public string GradeCode { get; set; }

    /// <summary>
    /// 商户代码 8 是
    /// </summary>
    public string MerchantNo { get; set; }

    /// <summary>
    /// 子账号开户时间 14 是
    /// 子账户开户时B2B 系统时间
    /// </summary>
    public string SubAccountTime { get; set; }

    /// <summary>
    /// 子账户当前状态 1 是
    /// 0:正常 1:禁用 2:销户
    /// </summary>
    public string SubAccountState { get; set; }

    /// <summary>
    /// 联系人 30 否
    /// </summary>
    public string Contact { get; set; }

    /// <summary>
    /// 联系电话 20 否
    /// </summary>
    public string ContactPhone { get; set; }

    /// <summary>
    /// 手机号码 20 否
    /// </summary>
    public string Phone { get; set; }

    /// <summary>
    /// 联系地址 128 否
    /// </summary>
    public string ContactAddr { get; set; }

    /// <summary>
    /// 法人姓名 64 否
    /// </summary>
    public string BusinessName { get; set; }

    /// <summary>
    /// 证件类型 2 是
    /// </summary>
    public string PapersType { get; set; }

    /// <summary>
    /// 证件代码 30 是
    /// </summary>
    public string PapersCode { get; set; }

    /// <summary>
    /// 是否需要短信通知 1 是
    /// </summary>
    public string IsMessager { get; set; }

    /// <summary>
    /// 短信通知手机号码 20 否       
    /// </summary>
    public string MessagePhone { get; set; }

    /// <summary>
    /// Email 40 否
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// 备注1 40 否
    /// </summary>
    public string Remark1 { get; set; }

    /// <summary>
    /// 备注2 40 否
    /// </summary>
    public string Remark2 { get; set; }

    /// <summary>
    /// 备注3 40 否
    /// </summary>
    public string Remark3 { get; set; }

    /// <summary>
    /// 备注4 40 否
    /// </summary>
    public string Remark4 { get; set; }

    /// <summary>
    /// 备注5 40 否
    /// </summary>
    public string Remark5 { get; set; }
}


